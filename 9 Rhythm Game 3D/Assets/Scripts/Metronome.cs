using System;
using System.Collections;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource Song;
    public AudioSource tik;

    public Action create;

    public float bpm;
    //public float level;
    public float second = 60;
    public float temp1 = 4f;
    public float temp2 = 4f;
    float time = 0;
    float temp;

    public bool SongOn;

    #region
    double nextBeatDSP;
    double beatDur;          // = 60.0 / bpm * (temp1 / temp2)
    double songStartDSP;
    public float songOffsetSec = 0f;
    #endregion

    private void Start()
    {
        #region
        beatDur = 60.0 / bpm * (temp1 / temp2);
        songStartDSP = AudioSettings.dspTime + 0.05; // 50ms 후 정확히 시작
        Song.PlayScheduled(songStartDSP + songOffsetSec);
        nextBeatDSP = songStartDSP + songOffsetSec;  // 첫 박자 기준
        SongOn = true;
        #endregion

       

        temp = (second / bpm) * (temp1 / temp2);

        //Metronum 을 GameManager에 구독
        GameManager.instance.start += Metronum;
    }

    void Update()
    {
        #region
        while (AudioSettings.dspTime >= nextBeatDSP)
        {
            // 틱 사운드도 DSP 시계로 정확히 스케줄
            tik.PlayScheduled(nextBeatDSP);
            create?.Invoke();

            nextBeatDSP += beatDur;
        }
        #endregion
    }

    //구독하기 위한 함수
    void Metronum()
    {
        Metronum(temp);
        //SongPlay(temp);
    }
    //박자& 곡 재생 함수
    public void Metronum(float temp)
    {
        if (!SongOn)
        {
            
            Song.Play();
            SongOn = true;
            time = 0;
        }

        time += Time.deltaTime;

        if (time > temp)
        {
            StartCoroutine(PlayTik(temp));
            time = 0;
        }
    }
    IEnumerator PlayTik(float temp)
    {
        Debug.Log(time);
        if (create != null)
            create.Invoke();
        tik.Play();
        yield return new WaitForSeconds(temp);
    }
}
