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
        //switch(Input.GetKeyUp(KeyCode.Escape)) -> ����ġ(��Ʈ�� ��ư �ݶ��̴��� ������ ����?)
        //{
        //    case 1: (���� <0.05f)
        //        text.text = "Perfect!";
        //        break;
        //    case 2: (���� <0.1f)
        //        text.text = "Great!";
        //        break;
        //    case 3: (���� <0.5f) 
        //        text.text = "Good";
        //        break;
        //    case 4: (���� <0.7f)
        //        text.text = "Oops";
        //        break;
        //    default: (���� >=0.7f)
        //        text.text = "Miss..";
        //        break;
        //}
    }
}
