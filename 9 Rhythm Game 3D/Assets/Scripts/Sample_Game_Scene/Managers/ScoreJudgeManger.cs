using System;
using Unity.Mathematics;
using UnityEngine;

public class ScoreJudgeManger : MonoBehaviour
{
    public SongController songcontroller;

    //판정 길이 밀리초
    public float perfectMs = 30f;
    public float greatMs = 60f;
    public float goodMs = 100f;

    public (EnumData.NotePressMode notemode, double errorMs) EvaluateHit(double hitDspSec)
    {
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
