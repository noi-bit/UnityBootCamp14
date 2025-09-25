using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class SongController : MonoBehaviour
{
    //private int beatsPerMeasure = 4; //마디 계산에 쓰고 싶을 때
    //[SerializeField] private float _lastSongTime = 0;
    public AudioSource musicSource;//음악을 재생할 이 게임오브젝트에 첨부된 AudioSource

    SO_data sodata;

    [Tooltip("한 비트 길이(초). 60/BPM 자동 계산")]
    public float secPerBeat;//한 비트의 길이
    public double dspSongTime; //dspSongTime = _scheduledDspStart , 일시정지.재개 때 += 등으로 싱크 맞추는 용도
    public float bpmValue = 1;

    [Tooltip("현재 곡 진행 시간(초, DSP 기준)")]
    [SerializeField] private float songPosition;//현재 노래위치

    public double nowDspTime;
    private double _scheduledDspStart;  //샘플-정확도 시작 시각 - DSPTime 저장, PlayScheduled로 예약된 시간/“처음 언제 틀기로 했나”라는 불변 레퍼런스
    private float songPositioninBeats;//박자 단위의 현재 노래위치 - float값으로
    [SerializeField] private int _lastMetronomeBeat; //마지막으로 발행한 정수 비트 인덱스 for 메트로눔
    [SerializeField] private int _lastCubeBeat; //마지막으로 발행한 정수 비트 인덱스 for 큐브

    [SerializeField] private bool _isPaused; //일시정지 상태

    [Tooltip("일시정지 시작 DSP 시각")]
    [SerializeField] private double _PausedAtDsp;    //일시정지 시작 DSP 시각

    [Tooltip("큐브 나오는 오프셋 시간")]
    [Range(0f,5f)]public float nowCubetime;
    public float metronomoffset;

    public Action<int> OnBeat;  //비트 바뀔 때 알림(선택사항)
    public Action<int> createCube;
    bool _metronomePrimed;
    //bool _CubePrimed;

    [SerializeField] private bool _running = false; //gamemanager가 호출하기 전까지는 update를 잠그는 변수

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _running = false;
        _metronomePrimed = false;
        //_CubePrimed = false;
        dspSongTime = 0;
    }

    void Start()
    {
        sodata = SongSelectUI.UIinstance.list[SongSelectUI.UIinstance.cur];
        GameManager.Instance.start += BeginSong;
        LevelLoad();

        if (sodata != null)
        {
            musicSource = GetComponent<AudioSource>();
            musicSource.clip = sodata.music;
            musicSource.volume = sodata.volume;
            musicSource.loop = sodata.loop;
            secPerBeat = 60f / sodata.BPM * bpmValue;
        }

    }

    void BeginSong()
    {
        _running = true;

        double now = AudioSettings.dspTime;
        double safety = 0.1; // 예약 여유
        double wantDelay = nowCubetime - sodata.firstBeatOffset; // "큐브 피크 = 첫 박" 정렬
        double delay = Math.Max(safety, wantDelay);              // 과거로 예약 못하니 최소 safety 확보

        _scheduledDspStart = now + delay;
        dspSongTime = _scheduledDspStart; // 이 시점을 '노래 0초'로 본다

        _lastMetronomeBeat = -1;
        _lastCubeBeat = -1;
        _metronomePrimed = false;

        musicSource.PlayScheduled(_scheduledDspStart);
    }

    void Update()
    {
        if (!_running) return;

        double now = AudioSettings.dspTime;
        double songPositionInSeconds = now - dspSongTime - sodata.firstBeatOffset-0.01f; // 첫 박 기준 위치(초)
        nowDspTime = songPositionInSeconds;

        // 메트로놈은 첫 박 이전엔 울리면 안 됨 → 내부에서 음수면 리턴
        CreateMetronome(songPositionInSeconds);

        // 큐브는 첫 박 이전에도 '미리' 나와야 함 → 음수라도 호출해야 함
        CreateCube(songPositionInSeconds);
    }

    private void CreateMetronome(double songPositionInSeconds)
    {
        if(songPositionInSeconds < 0) { _metronomePrimed = false; return; }

        float songPositioninBeats = ((float)songPositionInSeconds/*- metronomoffset*/) / secPerBeat;
        int currentBeat = Mathf.FloorToInt(songPositioninBeats);

        if(!_metronomePrimed)
        {
            _metronomePrimed= true;
            _lastMetronomeBeat = currentBeat;
            return;
        }
        while(currentBeat > _lastMetronomeBeat)
        {
            _lastMetronomeBeat++;
            OnBeat?.Invoke(_lastMetronomeBeat);
        }
    }

    private void CreateCube(double songPositionInSeconds)
    {
        double adjustedSongPosition = songPositionInSeconds;
        float nextCubeBeatTime = (_lastCubeBeat + 1) * secPerBeat;
        float spawnTime = nextCubeBeatTime - nowCubetime;


        while(adjustedSongPosition >= spawnTime)
        {
            _lastCubeBeat++;
            createCube?.Invoke(_lastCubeBeat); //이때 큐브 생성 이벤트 호출

            //다음 루프를 위해 다음 큐브의 스폰 시간을 다시 계산한다?
            nextCubeBeatTime = (_lastCubeBeat + 1) * secPerBeat;
            spawnTime = nextCubeBeatTime - nowCubetime;
        }
    }

    public void LevelLoad()
    {
        switch (SongSelectUI.UIinstance.dropdownlevel)
        {
            case EnumData.LV.supereasy:
                bpmValue = 4f;
                break;
            case EnumData.LV.easy:
                bpmValue = 2f;
                break;
            case EnumData.LV.normal:
                bpmValue = 1;
                break;
            case EnumData.LV.hard:
                bpmValue = 0.5f;
                break;
        }
    }

    // [추가] 씬 전환/파괴 시 구독 해제 (중복/누수 방지)
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.start -= BeginSong;
    }

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
