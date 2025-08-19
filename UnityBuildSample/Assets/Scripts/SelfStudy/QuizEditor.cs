using System;
using UnityEngine;
using UnityEngine.UI;

public class QuizEditor : MonoBehaviour
{
    public SOMaker[] SOMaker;
    private int i;
    public Text quiztext; //퀴즈 텍스트
    public Text correctincorrect; //정답인지 틀렸는지
    public Text hint;
    public InputField answerfield; //답을 적는 공간
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
            correctincorrect.text = $"정답입니다!\n{SOMaker[i].정답시}";
            nextQuiz.gameObject.SetActive(true);
        }
        else
        {
            correctincorrect.text = $"오답입니다!\n{SOMaker[i].오답시조롱}";
        }
        i ++;
    }
}
