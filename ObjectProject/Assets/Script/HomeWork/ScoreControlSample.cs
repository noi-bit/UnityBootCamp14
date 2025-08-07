using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreControlSample : MonoBehaviour
{
    public  int score;
    public Text scoreText;
    public Text Gameover;
    public PlayerRotationSample playerLife;

    public void AddScore(int amount)
    {
        
        score += amount;
        scoreText.text = "Score: " + score;
    }
    
}
