using UnityEngine;
using UnityEngine.UI;

public class TimeCountSample : MonoBehaviour
{
    public Text TimeCounter;
    private float timecount;

    void Start()
    {
        timecount = 60.0f;
        Time.timeScale = 1;
        TimeCounter.text = "Time : 60";
        //timecount = timecount * Time.deltaTime;
    }

    void Update()
    {
        timecount -= Time.deltaTime;
        TimeCounter.text = $"Time : {Mathf.CeilToInt(timecount)}";
        if (timecount <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
