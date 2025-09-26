using System;
using UnityEngine;
using UnityEngine.UI;

public class GameoverUI : MonoBehaviour
{
    public Button onemoretime;
    public Button backtotitle;
    public SongController SC;
    public PADcontroller[] pad;

    void Start()
    {
        backtotitle.onClick.AddListener(GoTitle); 
        onemoretime.onClick.AddListener(Resume);
    }

    private void Resume()
    {
        for (int i = 0; i < pad.Length; i++)
        { pad[i]._gamegetstart = true; }
        SC.Resume();

    }

    private void GoTitle()
    {
        GameManager.MoveScene.LoadScene((int)EnumData.GameStatus.Lobby);
    }

   
}
