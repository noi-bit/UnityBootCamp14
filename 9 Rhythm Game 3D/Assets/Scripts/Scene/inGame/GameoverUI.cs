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
        GameManager._isGameStart = false;
        SC.Resume();

    }

    private void GoTitle()
    {
        GameManager.MoveScene.LoadScene((int)EnumData.Scene.Title);
    }

   
}
