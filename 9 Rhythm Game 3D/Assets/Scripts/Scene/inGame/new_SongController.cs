using UnityEngine;
using System;

public class new_SongController : MonoBehaviour
{
    public AudioSource musicSource;
    SO_data song;

    private float songLevel;
    private float secPerBeat;
            private float cubeCreateTiming; //ť�갡 ������ �������� �ð�

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

    void BeginSong() //�긦 ����� �׼ǿ� �������Ѿ߰���? 
    {
        _isPlaying = true;
        double now = AudioSettings.dspTime;
        double safety = 0.1; // ���� ����
        double wantDelay = cubeCreateTiming - song.firstBeatOffset;
        double delay = Math.Max(safety, wantDelay);
    }

    void Update()
    {
        if(_isPlaying == false) return;
    }

}
