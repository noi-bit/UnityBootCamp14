using UnityEngine;
using UnityEngine.UI;

public class ComboTimeRule : MonoBehaviour
{
    public MoveScript move;
    public Slider comboSlider; //슬라이더
    public int score;
    public Text scoreText; //콤보스코어를 실시간 업데이트 해줄 텍스트
    public float slidertime; //슬라이더가 몇초에 "걸쳐" 내려가는지


    void Start()
    {
            
    }

    void Update()
    {
        
    }

    //스코어가 하나씩 올라간다
    public void Scoreinput()
    {
        score++;
    }

    
}
