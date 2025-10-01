using UnityEngine;
using static EnumData;

public class SongManager //��� �뷡�� �����͸� ����ִ�?
{
    public SO_data currentSOdata;
    

    public float GetLevelValue()
    {
        return currentSOdata.level switch
        {
            EnumData.LV.supereasy => 4f,
            EnumData.LV.easy => 2f,
            EnumData.LV.normal => 1f,
            EnumData.LV.hard => 0.5f,
            _ => 1f //default�� ����
        };
        // value = 0;
        //switch (currentSOdata.level)
        //{
        //    case EnumData.LV.supereasy:
        //        return 4;
        //        break;
        //    case EnumData.LV.easy:
        //        return 2;
        //        break;
        //    case EnumData.LV.normal:
        //        return 1;
        //        break;
        //    case EnumData.LV.hard:
        //        return 0.5f;
        //        break;

        //}
    }
}
