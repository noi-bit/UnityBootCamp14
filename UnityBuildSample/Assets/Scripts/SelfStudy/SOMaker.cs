using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "createQuiz", menuName = "QuizMenu")]
public class SOMaker : ScriptableObject
{
    public enum QuizType
    { ����, ����, ����}
    public QuizType quiztype; //������ Ÿ���� �����ش� (����, ����, ����)
    public int level; //������ ������ �����ش�
    public string description; //���� ����~
    public string hint; //������ ��Ʈ�� ���� �ְ�?
    public string answer;
    public string �����;
    public string ���������;
}
