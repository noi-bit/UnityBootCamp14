using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;
    
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public Text noteCheck; //NOICanvas
    
    void Start()
    {
        instance = this;
        scoreText.text = "Score : 0";
        currentMultiplier = 1;

    }

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
                    
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");
        noteCheck.text = "Hit!";
        multiText.text = $"Multiplier : {currentMultiplier}";

        if (currentMultiplier - 1 < multiplierThresholds.Length)//�� if���� ������ current�� �����µ� 
        {
            //��Ʈ ������ Ư�� ������ �Ѿ ������ ������ n�辿 ������ ����
            multiplierTracker++; //��Ʈ�� �ɶ����� multiplierTracker �� �ø���
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker) //���� thresholds�� �Էµ� int���� tracker�� int�� ��������
            {
                multiplierTracker = 0; //��Ƽ�ö��̾�� �ʱ�ȭ�ǰ�
                currentMultiplier++; //currentmultiplier�� �� �ȴ� -> ������Ȧ��[0]���� ������Ȧ��[1]�� �Ǵ°��� �׸���
            }
        }
        //currentScore += scorePerNote * currentMultiplier; //���ھ currentmultiplier�� ��ŭ �� �ްԵ�
        scoreText.text = $"Score : {currentScore}";
    }

    public void NormalHits()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHits()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHits()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        noteCheck.text = "Missed!";
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = $"Multiplier : {currentMultiplier}";
    }
}
