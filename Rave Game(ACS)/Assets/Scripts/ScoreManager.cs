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

    //���� ���� ��
    [Header("GameEnd")]
    public EndUIScript gameEndUI;
    public bool gameEnd = false;

    //�޺� �� ��Ÿ���� UI
    [Header("Combo")]
    public int comboScore = 10;
    public Image ComboImage;
    public Slider slider;
    public float scrolldownspeed;

    //Ÿ�̸� ��Ʈ��
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

//�����ϰ� ���� ��, GameEnd()�� �Ǹ� ��ư�� ������ �ٽ��ϱ⸦ �� �� �ִ�
//������ : GameEnd���¿� ����, �ٽ� ����Ű�� �Է��� �޾����� ComboImage â�� �������� - �ذ� ! MoveScript���� inputAction�� ���ư��°� bool�� ��

