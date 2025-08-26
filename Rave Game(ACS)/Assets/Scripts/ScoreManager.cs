using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //현재 스코어 텍스트
    public Text scoretext;

    //게임 종료 시
    public Text EndText;

    //콤보 시 나타나는 UI
    public int comboScore = 10;
    public Image ComboImage;
    public Slider slider;
    public float scrolldownspeed;

    public bool gameEnd = false;
    public int score = 0;


    void Start()
    {
        ComboImage.gameObject.SetActive(false);
        EndText.gameObject.SetActive(false);
        scoretext.text = $"Score : {score}";
    }
    
    void Update()
    {
        if (gameEnd)
            return;
        ScrollValuedown();
        scoretext.text = $"Score : {score}";
        
    }

    public void Scoreup(int a)
    {
        score += a;
    }
    
    public void ScoreCombo(int a)
    {
        slider.value += a;
    }

    public void ScrollValuedown()
    {
        if (slider.value == slider.maxValue)
        {
            Scoreup(100);
            GameEnd();
            
        }
        slider.value -= scrolldownspeed * Time.deltaTime;
    }

    public void GameEnd()
    {
        gameEnd = true;
        EndText.gameObject.SetActive(true);
        ComboImage.gameObject.SetActive(false);
        EndText.text = $"Game End\nScore : {score}";
    }

}

//구현하고 싶은 것, GameEnd()가 되면 버튼을 눌러서 다시하기를 할 수 있다
//문제점 : GameEnd상태에 들어가도, 다시 방향키의 입력이 받아져서 ComboImage 창이 떠버린다 - 해결 ! MoveScript에서 inputAction이 돌아가는걸 bool로 함

