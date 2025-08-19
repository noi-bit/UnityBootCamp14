using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MaxScoreCounter : MonoBehaviour
{
    public ClickScoreupSample scorevalue;
    public Text bestscore;
    private int bestscorevalue;

    private void Start()
    {
        bestscorevalue = 0;
    }

    private void Update()
    {
        if(scorevalue.score > bestscorevalue)
        {
            bestscorevalue = scorevalue.score;
            bestscore.text = $"축하합니다! 기록 갱신! : {bestscorevalue}";
        }
        else if(scorevalue.score <= bestscorevalue)
        {
            bestscore.text = $"최고 기록은.. {bestscorevalue}";
        }
    }
}
