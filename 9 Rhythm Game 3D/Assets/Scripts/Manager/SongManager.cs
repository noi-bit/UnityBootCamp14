using UnityEngine;
using static EnumData;

public class SongManager //얘는 노래의 데이터만 담고있다?
{
    public SO_data currentSOdata; //선택되어 재생되는 노래 정보
    public float GetLevelValue() //레벨마다 리턴하는 값
    {
        return currentSOdata.level switch
        {
            EnumData.LV.supereasy => 4f,
            EnumData.LV.easy => 2f,
            EnumData.LV.normal => 1f,
            EnumData.LV.hard => 0.5f,
            _ => 1f //default와 같다
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
