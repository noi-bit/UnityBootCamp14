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
            bestscore.text = $"�����մϴ�! ��� ����! : {bestscorevalue}";
        }
        else if(scorevalue.score <= bestscorevalue)
        {
            bestscore.text = $"�ְ� �����.. {bestscorevalue}";
        }
    }
}
