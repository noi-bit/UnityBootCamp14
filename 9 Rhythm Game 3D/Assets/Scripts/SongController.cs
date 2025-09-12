using System;
using UnityEngine;

public class SongController : MonoBehaviour
{
    //sodata ��� --> [Tooltip("��� ���� ����")]
    //public float songBpm;//BPM - ��� ����

    //sodata ��� --> [Tooltip("�뷡 ������ - ù��° ���ڿ� ���� ��ŸƮ ���� ����(��). +�� �ʰ�, -�� ������")]
    //public float firstBeatOffset;//�뷡�� ù ���۱����� ������

    #region
    [Header("���� ����")]
    public SO_data sodata;
    public AudioSource musicSource;//������ ����� �� ���ӿ�����Ʈ�� ÷�ε� AudioSource

    //[Tooltip("�� ��Ʈ ����(��). 60/BPM���� �ڵ� ���")]
    private float secPerBeat;//�� ��Ʈ�� ����

    [Tooltip("���� �� ���� �ð�(��, DSP ����)")]
    [SerializeField] private float songPosition;//���� �뷡��ġ(DSP?)

    [Tooltip("����� ���� DSP �ð�(����). Pause/Resume ������ ���")]
    [SerializeField] private double dspSongTime;

    [Tooltip("���� �� ����(��Ʈ ����, ��: 12.37)")]
    [SerializeField] private float songPositioninBeats;//��Ʈ ������ ���� �뷡��ġ 0-1-2-3

    [Header("�߰� ����")]

    //private int beatsPerMeasure = 4; //���� ��꿡 ���� ���� ��
    [Tooltip("���������� ������ ���� ��Ʈ �ε���")]
    [SerializeField] private int _lastBeat = -1; //��Ʈ ��� ������

    [Tooltip("PlayScheduled�� ����� DSP ���� �ð�")]
    [SerializeField] private double _scheduledDspStart;  //����-��Ȯ�� ���� �ð�


    [SerializeField] private bool _isPaused; //�Ͻ����� ����

    [Tooltip("�Ͻ����� ���� DSP �ð�")]
    [SerializeField] private double _PausedAtDsp;    //�Ͻ����� ���� DSP �ð�

    public Action<int> OnBeat;  //��Ʈ �ٲ� �� �˸�(���û���)
    bool _primed;

    [SerializeField] private bool _running = false; //gamemanager�� ȣ���ϱ� �������� update�� ��״� ����

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
        GameManager.instance.start += BeginSong; //�Լ��� ���� �޸𸮸� ��� �־���ϴϱ� �÷��̸� ���������� ������ �Ǵ°���(�޸� ����)
        secPerBeat = 60f / sodata.BPM;
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
        songPositioninBeats = posSec / secPerBeat; //��->��Ʈ�� ��ȯ
        int currentBeat = Mathf.FloorToInt(songPositioninBeats); //���� ���� ����� ���� ��
        if (!_primed)
        {
            _primed = true;
            _lastBeat = currentBeat;  // �ٷ� ���� ��Ʈ�� ���� ���� �����硱�� ��Ŀ
            return;
        }
        while (currentBeat > _lastBeat) //��Ʈ ��� ��� ����
        {
            _lastBeat++; //������ ��Ʈ ����
            OnBeat?.Invoke(currentBeat); //�ܺη� �ݹ�
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
        double pausedDur = AudioSettings.dspTime - _PausedAtDsp; //���� �ð� ���� ��Ȯ�ϰ� ���
        dspSongTime += (float)pausedDur; //���� ���� �ð��� += �� �ڷ� �о� ��ũ�� ����
        musicSource.UnPause();
    }
    
}
