using UnityEngine;
using UnityEngine.UI;

public class ComboTimeRule : MonoBehaviour
{
    public MoveScript move;
    public Slider comboSlider; //�����̴�
    public int score;
    public Text scoreText; //�޺����ھ �ǽð� ������Ʈ ���� �ؽ�Ʈ
    public float slidertime; //�����̴��� ���ʿ� "����" ����������


    void Start()
    {
            
    }

    void Update()
    {
        
    }

    //���ھ �ϳ��� �ö󰣴�
    public void Scoreinput()
    {
        score++;
    }

    
}
