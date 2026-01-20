using System;
using Unity.Mathematics;
using UnityEngine;

public class ScoreJudgeManger : MonoBehaviour
{

                        //--> 얘도 게임씬 내에서 작동하는거니까 게임씬 내로
    public SongController songcontroller;

    //판정 길이 밀리초
    public float perfectMs = 30f;
    public float greatMs = 60f;
    public float goodMs = 100f;

    public (EnumData.NotePressMode notemode, double errorMs) EvaluateHit(double hitDspSec)
    {
        //// metronomoffset을 고려한 히트 시간 계산
        //double adjustedHitSec = hitDspSec - songcontroller.metronomoffset;

        //// 조정된 시간으로 비트 계산
        //double hitBeat = adjustedHitSec / songcontroller.secPerBeat;

        //// 가장 가까운 정수 비트 인덱스
        //int nearestBeat = (int)Math.Round(hitBeat);

        //// 그 비트의 "이상적인" 시간(초) - offset 고려
        //double idealSec = nearestBeat * songcontroller.secPerBeat + songcontroller.metronomoffset;

        //// 오차(초) → ms
        //double errorSec = hitDspSec - idealSec;
        //double errorAbsMs = Math.Abs(errorSec) * 1000.0;

        //if (errorAbsMs <= perfectMs) return (EnumData.NotePressMode.Perfect, errorAbsMs);
        //if (errorAbsMs <= greatMs) return (EnumData.NotePressMode.Great, errorAbsMs);
        //if (errorAbsMs <= goodMs) return (EnumData.NotePressMode.Good, errorAbsMs);
        //return (EnumData.NotePressMode.Miss, errorAbsMs);

        // 현재 비트 위치(실수)
        double hitBeat = hitDspSec / songcontroller.secPerBeat;

        // 가장 가까운 정수 비트 인덱스
        int nearestBeat = (int)Math.Round(hitBeat);

        // 그 비트의 "이상적인" 시간(초)
        double idealSec = nearestBeat * songcontroller.secPerBeat;

        // 오차(초) 및 ms
        double errorSec = hitDspSec - idealSec;
        double errorAbsMs = Math.Abs(errorSec) * 1000.0;

        if (errorAbsMs <= perfectMs) return (EnumData.NotePressMode.Perfect, errorAbsMs);
        if (errorAbsMs <= greatMs) return (EnumData.NotePressMode.Great, errorAbsMs);
        if (errorAbsMs <= goodMs) return (EnumData.NotePressMode.Good, errorAbsMs);
        return (EnumData.NotePressMode.Miss, errorAbsMs);
    }
}
