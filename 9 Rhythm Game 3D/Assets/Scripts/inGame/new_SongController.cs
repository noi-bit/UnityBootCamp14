using UnityEngine;
using System;

public class new_SongController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    private SO_data song;
    private float secPerBeat;
            private float songLevel; //<- 얘는 레벨을 관리하는거니까 노트 관련한 스크립트?
            private float cubeCreateTiming; //큐브가 나오는 오프셋의 시간

    private bool _isPlaying = false;


    void Start()
    {
        song = GameManager.Song.currentSOdata;
                    songLevel = GameManager.Song.GetLevelValue(); //레벨 관리임!

        if (song != null)
        {
            musicSource.clip = song.music;
            //musicSource.volume = sodata.volume;
            //musicSource.loop = sodata.loop;
            secPerBeat = 60f / song.BPM/* * songLevel*/;
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
