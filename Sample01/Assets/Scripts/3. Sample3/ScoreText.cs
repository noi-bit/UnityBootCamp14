using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject sphere;
    public Text scoreText;
    private int score = 00;

    void Start()
    {
        score = 00;
        scoreText.text = "Score : " + score;

    }

    void Update()
    {
        
    }
}
