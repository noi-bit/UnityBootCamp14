using UnityEngine;

public class SongController : MonoBehaviour
{
    public AudioSource Song;
    public float Songdelay;

    #region
    public AudioSource musicSource;//������ ����� �� ���ӿ�����Ʈ�� ÷�ε� AudioSource
    
    public float songBpm;//BPM
    public float secPerBeat;//�� ��Ʈ�� �� ��
    public float songPosition;//���� �뷡��ġ(DSP?)
    public float dspSongTime;//�뷡�� ���۵� �� �� �ʰ� �����°�
    public float songPositioninBeats;//��Ʈ ������ ���� �뷡��ġ 0-1-2-3

    public float firstBeatOffset;//�뷡�� ù ���۱����� ������
    #endregion

    

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f/songBpm;//60�� �� ��
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPositioninBeats = songPosition / secPerBeat;
    }

    
}
