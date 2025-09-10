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
        songStartDSP = AudioSettings.dspTime + 0.05; // 50ms �� ��Ȯ�� ����
        Song.PlayScheduled(songStartDSP + songOffsetSec);
        nextBeatDSP = songStartDSP + songOffsetSec;  // ù ���� ����
        SongOn = true;
        #endregion

       

        temp = (second / bpm) * (temp1 / temp2);

        //Metronum �� GameManager�� ����
        GameManager.instance.start += Metronum;
    }

    void Update()
    {
        #region
        while (AudioSettings.dspTime >= nextBeatDSP)
        {
            // ƽ ���嵵 DSP �ð�� ��Ȯ�� ������
            tik.PlayScheduled(nextBeatDSP);
            create?.Invoke();

            nextBeatDSP += beatDur;
        }
        #endregion
    }

    //�����ϱ� ���� �Լ�
    void Metronum()
    {
        Metronum(temp);
        //SongPlay(temp);
    }
    //����& �� ��� �Լ�
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
