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

        if (currentMultiplier - 1 < multiplierThresholds.Length)//이 if문이 없으면 current가 오르는데 
        {
            //히트 판정이 특정 갯수를 넘어갈 때마다 점수가 n배씩 오르는 로직
            multiplierTracker++; //히트가 될때마다 multiplierTracker 을 올린다
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker) //만약 thresholds에 입력된 int보다 tracker의 int가 높아지면
            {
                multiplierTracker = 0; //멀티플라이어는 초기화되고
                currentMultiplier++; //currentmultiplier는 업 된다 -> 쓰레쉬홀드[0]에서 쓰레쉬홀드[1]이 되는거임 그리고
            }
        }
        //currentScore += scorePerNote * currentMultiplier; //스코어가 currentmultiplier배 만큼 더 받게됨
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
