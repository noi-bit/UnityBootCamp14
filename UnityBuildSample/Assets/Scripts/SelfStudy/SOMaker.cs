using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "createQuiz", menuName = "QuizMenu")]
public class SOMaker : ScriptableObject
{
    public enum QuizType
    { 수학, 영어, 음악}
    public QuizType quiztype; //퀴즈의 타입을 보여준다 (수학, 영어, 음악)
    public int level; //퀴즈의 레벨을 보여준다
    public string description; //퀴즈 내용~
    public string hint; //누르면 힌트를 볼수 있게?
    public string answer;
    public string 정답시;
    public string 오답시조롱;
}
