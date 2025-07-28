using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text text;
    float spawnTime = 2.0f;
    float time = 0.0f;
    private int a = 0;

    void Start()
    {

        text.text = "Score : " + a; 

    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            a += 10;
            text.text = "Score :" + a;
            time = 0.0f;
        }
    }
}
