using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class SongController : MonoBehaviour
{
    //private int beatsPerMeasure = 4; //마디 계산에 쓰고 싶을 때
    //[SerializeField] private float _lastSongTime = 0;
    public AudioSource musicSource;//음악을 재생할 이 게임오브젝트에 첨부된 AudioSource

    SO_data sodata;
    public int sodatanum;

    [Tooltip("한 비트 길이(초). 60/BPM 자동 계산")]
    public float secPerBeat;//한 비트의 길이
    public double dspSongTime; //dspSongTime = _scheduledDspStart , 일시정지.재개 때 += 등으로 싱크 맞추는 용도

    [Tooltip("현재 곡 진행 시간(초, DSP 기준)")]
    [SerializeField] private float songPosition;//현재 노래위치

   
    private double _scheduledDspStart;  //샘플-정확도 시작 시각 - DSPTime 저장, PlayScheduled로 예약된 시간/“처음 언제 틀기로 했나”라는 불변 레퍼런스
    private float songPositioninBeats;//박자 단위의 현재 노래위치 - float값으로
    [SerializeField] private int _lastMetronomeBeat; //마지막으로 발행한 정수 비트 인덱스 for 메트로눔
    [SerializeField] private int _lastCubeBeat; //마지막으로 발행한 정수 비트 인덱스 for 큐브

    [SerializeField] private bool _isPaused; //일시정지 상태

    [Tooltip("일시정지 시작 DSP 시각")]
    [SerializeField] private double _PausedAtDsp;    //일시정지 시작 DSP 시각

    [Tooltip("큐브 나오는 오프셋 시간")]
    [Range(0f,5f)]public float nowCubetime;

    public Action<int> OnBeat;  //비트 바뀔 때 알림(선택사항)
    public Action<int> createCube;
    bool _metronomePrimed;
    bool _CubePrimed;

    [SerializeField] private bool _running = false; //gamemanager가 호출하기 전까지는 update를 잠그는 변수

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        sodata = SongSelectUI.UIinstance.list[SongSelectUI.UIinstance.cur];
        musicSource.clip = sodata.music;
        musicSource.volume = sodata.volume;
        musicSource.loop = sodata.loop;
        secPerBeat = 60f / sodata.BPM;
    }

    void Start()
    {
        GameManager.instance.start += BeginSong;
                secPerBeat = 60f / sodata.BPM;
    }

    void BeginSong()
    {
        _running = true;
        _scheduledDspStart = AudioSettings.dspTime + 0.05f;
        dspSongTime = _scheduledDspStart;
        //_lastMetronomeBeat = -1;
        //_lastCubeBeat = -1;
        musicSource.PlayScheduled(_scheduledDspStart);
    }

    void Update()
    {
        CreateCube();
        CreateMetronome();
    }

    public void CreateMetronome()
    {
        if (!_running) return;
        double now = AudioSettings.dspTime;//이 값은 계속 커짐(시간이 지나니까)
                    double posD = now - dspSongTime - sodata.firstBeatOffset;
                    //결국 현재 dsptime - beginsong이 불려질때의 dsptime - offset이 0이 이상이 될 때부터 박자가 계산됨
        
        if (posD < 0) { _metronomePrimed = false; return; }

        float posSec = (float)posD; //posSec값은 시간이 지나면서 증가한다 - 플레이타임같은?
        songPosition = posSec;

        songPositioninBeats = posSec / secPerBeat; //초->비트로 변환
        int currentBeat = Mathf.FloorToInt(songPositioninBeats); //현재 곡이 진행된 박자 수

        if (!_metronomePrimed)
        {
            _metronomePrimed = true;
            _lastMetronomeBeat = currentBeat;  // 바로 이전 비트로 두지 말고 “현재”로 앵커
            return;
        }
        while (currentBeat > _lastMetronomeBeat) //비트 경계 통과 시점
        {
            _lastMetronomeBeat++; //마지막 비트 갱신
            OnBeat?.Invoke(_lastMetronomeBeat); //외부로 콜백 -> 메트로눔 사운드
        }
    }

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!여기 함수 체크하기!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public void CreateCube()
    {
        if (!_running) return;
        double now = AudioSettings.dspTime;//이 값은 계속 커짐(시간이 지나니까)
                    double posD = now - dspSongTime - sodata.firstBeatOffset - nowCubetime;
                    //결국 현재 dsptime - beginsong이 불려질때의 dsptime - offset이 0이 이상이 될 때부터 박자가 계산됨
        
        if (posD < 0) { _CubePrimed = false; return; }

        float posSec = (float)posD; //posSec값은 시간이 지나면서 증가한다 - 플레이타임같은?
        float cubesongPosition = posSec;
        //songPosition = (float)posD;
        float cubesongPositioninBeats = posSec / secPerBeat; //초->비트로 변환
        int currentBeat = Mathf.FloorToInt(cubesongPositioninBeats); //현재 곡이 진행된 박자 수

        if (!_CubePrimed)
        {
            _CubePrimed = true;
            _lastCubeBeat = currentBeat;  // 바로 이전 비트로 두지 말고 “현재”로 앵커
            return;
        }
        while (currentBeat > _lastCubeBeat) //비트 경계 통과 시점
        {
            _lastCubeBeat++; //마지막 비트 갱신
                                createCube?.Invoke(_lastCubeBeat);
        }
    }

    // [추가] 씬 전환/파괴 시 구독 해제 (중복/누수 방지)
    private void OnDestroy()
    {
        if (GameManager.instance != null)
            GameManager.instance.start -= BeginSong;
    }
    //public void SeekToBeat(float beat)
    //{
    //    float targetTime = beat * secPerBeat + sodata.firstBeatOffset;
    //    musicSource.time = Mathf.Max(0f, targetTime);
    //    dspSongTime = (float)AudioSettings.dspTime - (musicSource.time - sodata.firstBeatOffset);
    //    _lastBeat = Mathf.FloorToInt(beat) - 1;
    //}
    public void Pause()
    {
        if (_isPaused) return;
        _isPaused = true;
        _PausedAtDsp = AudioSettings.dspTime;
        musicSource.Pause();
    }
    public void Resume()
    {
        if (!_isPaused) return;
        _isPaused = false;
        double pausedDur = AudioSettings.dspTime - _PausedAtDsp; //멈춘 시간 길이 정확하게 기록
        dspSongTime += (float)pausedDur; //기준 시작 시간에 += 로 뒤로 밀어 싱크를 유지
        musicSource.UnPause();
    }
}
