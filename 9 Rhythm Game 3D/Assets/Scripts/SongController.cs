using UnityEngine;

public class SongController : MonoBehaviour
{
    public AudioSource Song;
    public float Songdelay;

    #region
    public AudioSource musicSource;//음악을 재생할 이 게임오브젝트에 첨부된 AudioSource
    
    public float songBpm;//BPM
    public float secPerBeat;//한 비트당 초 수
    public float songPosition;//현재 노래위치(DSP?)
    public float dspSongTime;//노래가 시작된 후 몇 초가 지났는가
    public float songPositioninBeats;//비트 단위의 현재 노래위치 0-1-2-3

    public float firstBeatOffset;//노래의 첫 시작까지의 오프셋
    #endregion

    

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f/songBpm;//60은 초 수
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPositioninBeats = songPosition / secPerBeat;
    }

    
}
