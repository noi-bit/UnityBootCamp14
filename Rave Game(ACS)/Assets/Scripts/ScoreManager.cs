using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //���� ���ھ� �ؽ�Ʈ
    public Text scoretext;

    //���� ���� ��
    public Text EndText;

    //�޺� �� ��Ÿ���� UI
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

//�����ϰ� ���� ��, GameEnd()�� �Ǹ� ��ư�� ������ �ٽ��ϱ⸦ �� �� �ִ�
//������ : GameEnd���¿� ����, �ٽ� ����Ű�� �Է��� �޾����� ComboImage â�� �������� - �ذ� ! MoveScript���� inputAction�� ���ư��°� bool�� ��

