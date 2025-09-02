using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text timeText;
    public float MaxTime;
    float  currentTime;

    public void Timer()
    {
        //currentTime = MaxTime;
        if (currentTime <= 0) return;

        else
        {   
            currentTime -= Time.deltaTime;
            timeText.text = $"Time : {Mathf.FloorToInt(currentTime)}";
        }
        
    }

    public void TimerReset()
    { 
         currentTime = MaxTime;
         timeText.text = $"Time : {Mathf.FloorToInt(currentTime)}";
    }

}
