using UnityEngine;
using UnityEngine.UI;

public class MyScoreUI : MonoBehaviour
{
    public Text text;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void NormalHits()
    {

    }

    public void GoodHits()
    {

    }

    public void PerfectHits()
    {

    }

    void Judge()
    {
        //switch(Input.GetKeyUp(KeyCode.Escape)) -> 스위치(노트와 버튼 콜라이더의 오차에 따라?)
        //{
        //    case 1: (오차 <0.05f)
        //        text.text = "Perfect!";
        //        break;
        //    case 2: (오차 <0.1f)
        //        text.text = "Great!";
        //        break;
        //    case 3: (오차 <0.5f) 
        //        text.text = "Good";
        //        break;
        //    case 4: (오차 <0.7f)
        //        text.text = "Oops";
        //        break;
        //    default: (오차 >=0.7f)
        //        text.text = "Miss..";
        //        break;
        //}
    }
}
