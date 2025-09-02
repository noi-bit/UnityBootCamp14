using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    [Header("Combo")]
    public int comboScore = 10;
    public Image ComboImage;
    public Slider slider;
    public float scrolldownspeed;

    public void Combo(int a)
    {
        ComboUP(a);
        ScrollValuedown();
    }

    public void ComboUP(int a)
    {
        slider.value += a;
    }

    public void ScrollValuedown()
    {
        //if (slider.value >= slider.maxValue)
        //{
           // ScoreUP(100);
           // GameEnd();
           // return;
        //}
        slider.value -= scrolldownspeed * Time.deltaTime;
    }
}
