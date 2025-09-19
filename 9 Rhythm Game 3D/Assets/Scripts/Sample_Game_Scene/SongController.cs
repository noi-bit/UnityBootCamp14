using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class SongController : MonoBehaviour
{
    //private int beatsPerMeasure = 4; //���� ��꿡 ���� ���� ��
    //[SerializeField] private float _lastSongTime = 0;
    public AudioSource musicSource;//������ ����� �� ���ӿ�����Ʈ�� ÷�ε� AudioSource

    SO_data sodata;
    public int sodatanum;

    [Tooltip("�� ��Ʈ ����(��). 60/BPM �ڵ� ���")]
    public float secPerBeat;//�� ��Ʈ�� ����
    public double dspSongTime; //dspSongTime = _scheduledDspStart , �Ͻ�����.�簳 �� += ������ ��ũ ���ߴ� �뵵

    [Tooltip("���� �� ���� �ð�(��, DSP ����)")]
    [SerializeField] private float songPosition;//���� �뷡��ġ

   
    private double _scheduledDspStart;  //����-��Ȯ�� ���� �ð� - DSPTime ����, PlayScheduled�� ����� �ð�/��ó�� ���� Ʋ��� �߳������ �Һ� ���۷���
    private float songPositioninBeats;//���� ������ ���� �뷡��ġ - float������
    [SerializeField] private int _lastMetronomeBeat; //���������� ������ ���� ��Ʈ �ε��� for ��Ʈ�δ�
    [SerializeField] private int _lastCubeBeat; //���������� ������ ���� ��Ʈ �ε��� for ť��

    [SerializeField] private bool _isPaused; //�Ͻ����� ����

    [Tooltip("�Ͻ����� ���� DSP �ð�")]
    [SerializeField] private double _PausedAtDsp;    //�Ͻ����� ���� DSP �ð�

    [Tooltip("ť�� ������ ������ �ð�")]
    [Range(0f,5f)]public float nowCubetime;

    public Action<int> OnBeat;  //��Ʈ �ٲ� �� �˸�(���û���)
    public Action<int> createCube;
    bool _metronomePrimed;
    bool _CubePrimed;

    [SerializeField] private bool _running = false; //gamemanager�� ȣ���ϱ� �������� update�� ��״� ����

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
        double now = AudioSettings.dspTime;//�� ���� ��� Ŀ��(�ð��� �����ϱ�)
                    double posD = now - dspSongTime - sodata.firstBeatOffset;
                    //�ᱹ ���� dsptime - beginsong�� �ҷ������� dsptime - offset�� 0�� �̻��� �� ������ ���ڰ� ����
        
        if (posD < 0) { _metronomePrimed = false; return; }

        float posSec = (float)posD; //posSec���� �ð��� �����鼭 �����Ѵ� - �÷���Ÿ�Ӱ���?
        songPosition = posSec;

        songPositioninBeats = posSec / secPerBeat; //��->��Ʈ�� ��ȯ
        int currentBeat = Mathf.FloorToInt(songPositioninBeats); //���� ���� ����� ���� ��

        if (!_metronomePrimed)
        {
            _metronomePrimed = true;
            _lastMetronomeBeat = currentBeat;  // �ٷ� ���� ��Ʈ�� ���� ���� �����硱�� ��Ŀ
            return;
        }
        while (currentBeat > _lastMetronomeBeat) //��Ʈ ��� ��� ����
        {
            _lastMetronomeBeat++; //������ ��Ʈ ����
            OnBeat?.Invoke(_lastMetronomeBeat); //�ܺη� �ݹ� -> ��Ʈ�δ� ����
        }
    }

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!���� �Լ� üũ�ϱ�!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public void CreateCube()
    {
        if (!_running) return;
        double now = AudioSettings.dspTime;//�� ���� ��� Ŀ��(�ð��� �����ϱ�)
                    double posD = now - dspSongTime - sodata.firstBeatOffset - nowCubetime;
                    //�ᱹ ���� dsptime - beginsong�� �ҷ������� dsptime - offset�� 0�� �̻��� �� ������ ���ڰ� ����
        
        if (posD < 0) { _CubePrimed = false; return; }

        float posSec = (float)posD; //posSec���� �ð��� �����鼭 �����Ѵ� - �÷���Ÿ�Ӱ���?
        float cubesongPosition = posSec;
        //songPosition = (float)posD;
        float cubesongPositioninBeats = posSec / secPerBeat; //��->��Ʈ�� ��ȯ
        int currentBeat = Mathf.FloorToInt(cubesongPositioninBeats); //���� ���� ����� ���� ��

        if (!_CubePrimed)
        {
            _CubePrimed = true;
            _lastCubeBeat = currentBeat;  // �ٷ� ���� ��Ʈ�� ���� ���� �����硱�� ��Ŀ
            return;
        }
        while (currentBeat > _lastCubeBeat) //��Ʈ ��� ��� ����
        {
            _lastCubeBeat++; //������ ��Ʈ ����
                                createCube?.Invoke(_lastCubeBeat);
        }
    }

    // [�߰�] �� ��ȯ/�ı� �� ���� ���� (�ߺ�/���� ����)
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
        double pausedDur = AudioSettings.dspTime - _PausedAtDsp; //���� �ð� ���� ��Ȯ�ϰ� ���
        dspSongTime += (float)pausedDur; //���� ���� �ð��� += �� �ڷ� �о� ��ũ�� ����
        musicSource.UnPause();
    }
}
