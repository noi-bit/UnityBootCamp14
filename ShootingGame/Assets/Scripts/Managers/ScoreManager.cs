using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    public Text scoreText;
    //public Text bestText;

    private int score;
    private static int best;
    public int bestcheck;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetScore(int value)
    {
        score += value; //전달받은 값 만큼 점수를 증가시킨다
        SetScoreText(score);

        if(score>best)
        {
            best = score;
            bestcheck = best;
            //SetBestScore(best);
        }
    }

    public int GetScore() => score; //return score; 

    private void SetScoreText(int score) => scoreText.text = $"Score : {score}";
   // private void SetBestScore(int best) => bestText.text = $"Best Score : {best}";
    //public void updateScore()
    //{

    //}
}
