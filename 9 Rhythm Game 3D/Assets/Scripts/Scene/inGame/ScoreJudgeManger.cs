using System;
using Unity.Mathematics;
using UnityEngine;

public class ScoreJudgeManger : MonoBehaviour
{

                        //--> �굵 ���Ӿ� ������ �۵��ϴ°Ŵϱ� ���Ӿ� ����
    public SongController songcontroller;

    //���� ���� �и���
    public float perfectMs = 30f;
    public float greatMs = 60f;
    public float goodMs = 100f;

    public (EnumData.NotePressMode notemode, double errorMs) EvaluateHit(double hitDspSec)
    {
        //// metronomoffset�� ����� ��Ʈ �ð� ���
        //double adjustedHitSec = hitDspSec - songcontroller.metronomoffset;

        //// ������ �ð����� ��Ʈ ���
        //double hitBeat = adjustedHitSec / songcontroller.secPerBeat;

        //// ���� ����� ���� ��Ʈ �ε���
        //int nearestBeat = (int)Math.Round(hitBeat);

        //// �� ��Ʈ�� "�̻�����" �ð�(��) - offset ���
        //double idealSec = nearestBeat * songcontroller.secPerBeat + songcontroller.metronomoffset;

        //// ����(��) �� ms
        //double errorSec = hitDspSec - idealSec;
        //double errorAbsMs = Math.Abs(errorSec) * 1000.0;

        //if (errorAbsMs <= perfectMs) return (EnumData.NotePressMode.Perfect, errorAbsMs);
        //if (errorAbsMs <= greatMs) return (EnumData.NotePressMode.Great, errorAbsMs);
        //if (errorAbsMs <= goodMs) return (EnumData.NotePressMode.Good, errorAbsMs);
        //return (EnumData.NotePressMode.Miss, errorAbsMs);

        // ���� ��Ʈ ��ġ(�Ǽ�)
        double hitBeat = hitDspSec / songcontroller.secPerBeat;

        // ���� ����� ���� ��Ʈ �ε���
        int nearestBeat = (int)Math.Round(hitBeat);

        // �� ��Ʈ�� "�̻�����" �ð�(��)
        double idealSec = nearestBeat * songcontroller.secPerBeat;

        // ����(��) �� ms
        double errorSec = hitDspSec - idealSec;
        double errorAbsMs = Math.Abs(errorSec) * 1000.0;

        if (errorAbsMs <= perfectMs) return (EnumData.NotePressMode.Perfect, errorAbsMs);
        if (errorAbsMs <= greatMs) return (EnumData.NotePressMode.Great, errorAbsMs);
        if (errorAbsMs <= goodMs) return (EnumData.NotePressMode.Good, errorAbsMs);
        return (EnumData.NotePressMode.Miss, errorAbsMs);
    }
}
