using System;
using UnityEngine;
using UnityEngine.UI;

public class QuizEditor : MonoBehaviour
{
    public SOMaker[] SOMaker;
    private int i;
    public Text quiztext; //���� �ؽ�Ʈ
    public Text correctincorrect; //�������� Ʋ�ȴ���
    public Text hint;
    public InputField answerfield; //���� ���� ����
    public Button nextQuiz;

    void Start()
    {
        i = 0;
        nextQuiz.gameObject.SetActive(false);
    
        quiztext.text = $"{SOMaker[i].description}";
        correctincorrect.text = "";
        hint.text = $"{SOMaker[i].hint}";


        if (nextQuiz)
        {
            i++;
            quiztext.text = $"{SOMaker[i].description}";
            correctincorrect.text = "";
            nextQuiz.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            isAnswerCorrect();
            hint.gameObject.SetActive(false);
        }
    }

   

    public void isAnswerCorrect()
    {
        if(answerfield.text == SOMaker[i].answer)
        {
            correctincorrect.text = $"�����Դϴ�!\n{SOMaker[i].�����}";
            nextQuiz.gameObject.SetActive(true);
        }
        else
        {
            correctincorrect.text = $"�����Դϴ�!\n{SOMaker[i].���������}";
        }
        i ++;
    }
}
