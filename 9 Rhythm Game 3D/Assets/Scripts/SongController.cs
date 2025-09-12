using System;
using UnityEngine;

public class SongController : MonoBehaviour
{
    //sodata 사용 --> [Tooltip("곡마다 별개 설정")]
    //public float songBpm;//BPM - 곡마다 별개

    //sodata 사용 --> [Tooltip("노래 내에서 - 첫번째 박자에 대한 스타트 판정 보정(초). +는 늦게, -는 빠르게")]
    //public float firstBeatOffset;//노래의 첫 시작까지의 오프셋

    #region
    [Header("메인 변수")]
    public SO_data sodata;
    public AudioSource musicSource;//음악을 재생할 이 게임오브젝트에 첨부된 AudioSource

    //[Tooltip("한 비트 길이(초). 60/BPM에서 자동 계산")]
    private float secPerBeat;//한 비트의 길이

    [Tooltip("현재 곡 진행 시간(초, DSP 기준)")]
    [SerializeField] private float songPosition;//현재 노래위치(DSP?)

    [Tooltip("예약된 시작 DSP 시각(기준). Pause/Resume 보정에 사용")]
    [SerializeField] private double dspSongTime;

    [Tooltip("현재 곡 진행(비트 단위, 예: 12.37)")]
    [SerializeField] private float songPositioninBeats;//비트 단위의 현재 노래위치 0-1-2-3

    [Header("추가 변수")]

    //private int beatsPerMeasure = 4; //마디 계산에 쓰고 싶을 때
    [Tooltip("마지막으로 발행한 정수 비트 인덱스")]
    [SerializeField] private int _lastBeat = -1; //비트 경계 감지용

    [Tooltip("PlayScheduled로 예약된 DSP 시작 시각")]
    [SerializeField] private double _scheduledDspStart;  //샘플-정확도 시작 시각


    [SerializeField] private bool _isPaused; //일시정지 상태

    [Tooltip("일시정지 시작 DSP 시각")]
    [SerializeField] private double _PausedAtDsp;    //일시정지 시작 DSP 시각

    public Action<int> OnBeat;  //비트 바뀔 때 알림(선택사항)
    bool _primed;

    [SerializeField] private bool _running = false; //gamemanager가 호출하기 전까지는 update를 잠그는 변수

    #endregion

    private void Awake()
    {
        //if (sodata != null) FindAnyObjectByType<SO_data>();
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = sodata.music;
        musicSource.volume = sodata.volume;
        musicSource.loop = sodata.loop;
    }

    void Start()
    {
        GameManager.instance.start += BeginSong; //함수에 대한 메모리를 들고 있어야하니까 플레이를 누를때마다 구독이 되는거임(메모리 낭비)
        secPerBeat = 60f / sodata.BPM;
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

    void BeginSong()
    {
        _running = true;
        _scheduledDspStart = AudioSettings.dspTime;
        dspSongTime = _scheduledDspStart;
        _lastBeat = -1;
        musicSource.PlayScheduled(_scheduledDspStart);
    }

    void Update()
    {
        if (!_running) return;

        double now = AudioSettings.dspTime;
        double posD = now - dspSongTime - sodata.firstBeatOffset;

        if (posD < 0) { _primed = false; return; }
        //if (posD < 0) return;

        float posSec = (float)posD;
        songPosition = posSec;
        //songPosition = (float)posD;
        songPositioninBeats = posSec / secPerBeat; //초->비트로 변환
        int currentBeat = Mathf.FloorToInt(songPositioninBeats); //현재 곡이 진행된 박자 수
        if (!_primed)
        {
            _primed = true;
            _lastBeat = currentBeat;  // 바로 이전 비트로 두지 말고 “현재”로 앵커
            return;
        }
        while (currentBeat > _lastBeat) //비트 경계 통과 시점
        {
            _lastBeat++; //마지막 비트 갱신
            OnBeat?.Invoke(currentBeat); //외부로 콜백
        }
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
