using UnityEngine;
using System;

public class new_SongController : MonoBehaviour
{
    public AudioSource musicSource;
    SO_data song;

    private float songLevel;
    private float secPerBeat;
            private float cubeCreateTiming; //큐브가 나오는 오프셋의 시간

    private bool _isPlaying = false;


    void Start()
    {
        song = GameManager.Song.currentSOdata;
        songLevel = GameManager.Song.GetLevelValue();

        if (song != null)
        {
            musicSource.clip = song.music;
            //musicSource.volume = sodata.volume;
            //musicSource.loop = sodata.loop;
            secPerBeat = 60f / song.BPM * songLevel;
        }
    }

    void BeginSong() //얘를 어딘가의 액션에 구독시켜야겠지? 
    {
        _isPlaying = true;
        double now = AudioSettings.dspTime;
        double safety = 0.1; // 예약 여유
        double wantDelay = cubeCreateTiming - song.firstBeatOffset;
        double delay = Math.Max(safety, wantDelay);
    }

    void Update()
    {
        if(_isPlaying == false) return;
    }

}
