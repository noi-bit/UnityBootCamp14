using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //---> 얘는 매니저가 아니라 게임씬에 붙어야할듯?


    public Text TimerText;
    public Text ScoreText;
    public TextMeshProUGUI JudgeText;
    public Slider ScoreSlider;
    public Canvas GameOverCanvas;
    public PADcontroller[] pad;
    public SongController SongController;

    private float defalutdown = 1f;
    float scoreV = 0;
    private bool _start;

     void Start()
     {
                //StartCoroutine(CountDownFunc((int)GameManager.Instance.Globaldelay));
        ScoreSlider.maxValue = 100f;
        ScoreSlider.minValue = 0f;
        ScoreSlider.value = 70f;
        _start = false;
     }

     private IEnumerator CountDownFunc(int count)
     {
        for(int i = count; i>=0; i--)
        {
            TimerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
            if(i == 1)
            {
                TimerText.gameObject.SetActive(false);
                _start = true;
            }
        }
     }

    private void Update()
    {
        if(_start == true)
        Sliderdefault();

        if(ScoreSlider.value == ScoreSlider.minValue)
        {
            //GameManager.Instance.nowstats = EnumData.Scene.GameOver;
            for (int i = 0; i < pad.Length; i++)
            { pad[i]._gamegetstart = false; }
            GameOverCanvas.gameObject.SetActive(true);
            SongController.Pause();
        }
    }

    public void Sliderdefault()
    {
        ScoreSlider.value -= Time.deltaTime * defalutdown;
    }

    public void SliderScore(float score)
    {
        scoreV += score;
        ScoreSlider.value += score;
        ScoreText.text = $"{scoreV}";
    }

    public void SeterrorMsText(EnumData.NotePressMode pressMode)
    {
        JudgeText.text =$"{pressMode.ToString()}!!";
    }
}
