using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    public Text scoretext;
    public int score = 0;

    [Header("GameStart")]
    public Action gameStart;

    //게임 종료 시
    [Header("GameEnd")]
    public EndUIScript gameEndUI;
    public bool gameEnd = false;

    //콤보 시 나타나는 UI
    [Header("Combo")]
    public int comboScore = 10;
    public Image ComboImage;
    public Slider slider;
    public float scrolldownspeed;

    //타이머 컨트롤
    [Header("Timer")]
    public TimerScript timer;

    void Start()
    {
        timer.TimerReset();
        GameStart();
        gameStart += ScrollValuedown;
        gameStart += ScrollImageOn;
    }
    
    void Update()
    {
        gameStart.Invoke();
        //scoretext.text = $"Score : {score}";
        if (gameEnd == false)
        {
            timer.Timer();
        }
        //ScrollValuedown();
        scoretext.text = $"Score : {score}";
        if (gameEnd==true)
            return;
    }

    public void ScoreUP(int a)
    {
        score += a;
    }
    
    public void ScrollImageOn()
    {
        if (score > comboScore)
        {
            ComboImage.gameObject.SetActive(true);
        }
    }

    public void ComboUP(int a)
    {
        slider.value += a;
    }

    public void ScrollValuedown()
    {
        if (slider.value >= slider.maxValue)
        {
            ScoreUP(100);
            GameEnd();
            return;
        }
        slider.value -= scrolldownspeed * Time.deltaTime;
    }

    public void GameStart()
    {
        gameEnd = false;
        gameEndUI.GameEndPannel.gameObject.SetActive(false);
        ComboImage.gameObject.SetActive(false);
        //scoretext.text = $"Score : {score}";
    }

    public void GameEnd()
    {
        gameEnd = true;
        gameEndUI.GameEndPannel.gameObject.SetActive(true);
        //timer.TimerOff();
        timer.TimerReset();
        gameEndUI.GameEndtext.text = $"Game End\nScore : {score}";
        score = 0;
        slider.value = 0;
    }
}

//구현하고 싶은 것, GameEnd()가 되면 버튼을 눌러서 다시하기를 할 수 있다
//문제점 : GameEnd상태에 들어가도, 다시 방향키의 입력이 받아져서 ComboImage 창이 떠버린다 - 해결 ! MoveScript에서 inputAction이 돌아가는걸 bool로 함

