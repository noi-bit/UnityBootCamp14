using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text timeText;
    public float MaxTime = 60f;
    int currentTime;

    void Start()
    {
        timeText.text = $"Time : {MaxTime}";
    }

    
    void Update()
    {
        TimerOn();
    }

    void TimerOn()
    {
        if (!scoreManager.gameEnd)
        {
            MaxTime -= Time.deltaTime;
            currentTime = Mathf.FloorToInt(MaxTime);
        }

        else if (currentTime <= 0)
        {
            currentTime = 0;
            scoreManager.GameEnd();
        }

        timeText.text = $"Time : {currentTime}";
    }
}
