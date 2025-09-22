using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Metronome : MonoBehaviour
    //-->�̰� ���߿� ������ ���� �Ҹ��� ����ǰ�?
{
    [Header("Audio")]
    public AudioSource tik;
    public SongController songcontroller;
    public NoteController NoteController;


    private void Start()
    {
        if (songcontroller != null)
            songcontroller.OnBeat += Metronum;
    }

    private void OnDisable()
    {
        if (songcontroller != null)
            songcontroller.OnBeat -= Metronum;
    }

    void Metronum(int beatIndex)
    {
        float beat = beatIndex - NoteController.beatOffset;
        if (!Mathf.Approximately(beat % NoteController.spawnEveryNBeats, 0f)) return;

        tik.Play();
    }

}
