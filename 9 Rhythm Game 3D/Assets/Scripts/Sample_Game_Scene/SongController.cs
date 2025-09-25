using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class SongController : MonoBehaviour
{
    //private int beatsPerMeasure = 4; //���� ��꿡 ���� ���� ��
    //[SerializeField] private float _lastSongTime = 0;
    public AudioSource musicSource;//������ ����� �� ���ӿ�����Ʈ�� ÷�ε� AudioSource

    SO_data sodata;

    [Tooltip("�� ��Ʈ ����(��). 60/BPM �ڵ� ���")]
    public float secPerBeat;//�� ��Ʈ�� ����
    public double dspSongTime; //dspSongTime = _scheduledDspStart , �Ͻ�����.�簳 �� += ������ ��ũ ���ߴ� �뵵
    public float bpmValue = 1;

    [Tooltip("���� �� ���� �ð�(��, DSP ����)")]
    [SerializeField] private float songPosition;//���� �뷡��ġ

    public double nowDspTime;
    private double _scheduledDspStart;  //����-��Ȯ�� ���� �ð� - DSPTime ����, PlayScheduled�� ����� �ð�/��ó�� ���� Ʋ��� �߳������ �Һ� ���۷���
    private float songPositioninBeats;//���� ������ ���� �뷡��ġ - float������
    [SerializeField] private int _lastMetronomeBeat; //���������� ������ ���� ��Ʈ �ε��� for ��Ʈ�δ�
    [SerializeField] private int _lastCubeBeat; //���������� ������ ���� ��Ʈ �ε��� for ť��

    [SerializeField] private bool _isPaused; //�Ͻ����� ����

    [Tooltip("�Ͻ����� ���� DSP �ð�")]
    [SerializeField] private double _PausedAtDsp;    //�Ͻ����� ���� DSP �ð�

    [Tooltip("ť�� ������ ������ �ð�")]
    [Range(0f,5f)]public float nowCubetime;
    public float metronomoffset;

    public Action<int> OnBeat;  //��Ʈ �ٲ� �� �˸�(���û���)
    public Action<int> createCube;
    bool _metronomePrimed;
    //bool _CubePrimed;

    [SerializeField] private bool _running = false; //gamemanager�� ȣ���ϱ� �������� update�� ��״� ����

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
        _scheduledDspStart = AudioSettings.dspTime + 0.05f;
        dspSongTime = _scheduledDspStart;
        _lastMetronomeBeat = -1;
        _lastCubeBeat = -1;
        _metronomePrimed = false;
        //_CubePrimed = false;
        musicSource.PlayScheduled(_scheduledDspStart);
    }

    void Update()
    {
        if (!_running) return;

        double now = AudioSettings.dspTime;
        double songPositionInSeconds = now - dspSongTime - sodata.firstBeatOffset;
        nowDspTime = songPositionInSeconds;

        if (songPositionInSeconds < 0) return;

        //CreateCube();
        //CreateMetronome(); 
        CreateMetronome(songPositionInSeconds);
        CreateCube(songPositionInSeconds);
    }

    private void CreateMetronome(double songPositionInSeconds)
    {
        if(songPositionInSeconds < 0) { _metronomePrimed = false; return; }

        float songPositioninBeats = ((float)songPositionInSeconds- metronomoffset) / secPerBeat;
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
            createCube?.Invoke(_lastCubeBeat); //�̶� ť�� ���� �̺�Ʈ ȣ��

            //���� ������ ���� ���� ť���� ���� �ð��� �ٽ� ����Ѵ�?
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

    // [�߰�] �� ��ȯ/�ı� �� ���� ���� (�ߺ�/���� ����)
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
        double pausedDur = AudioSettings.dspTime - _PausedAtDsp; //���� �ð� ���� ��Ȯ�ϰ� ���
        dspSongTime += (float)pausedDur; //���� ���� �ð��� += �� �ڷ� �о� ��ũ�� ����
        musicSource.UnPause();
    }
}
