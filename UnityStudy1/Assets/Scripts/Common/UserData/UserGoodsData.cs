using UnityEngine;

public class UserGoodsData : IUserData
{
    //������ ��ȭ 1.Gem(����) 2.Gold(��)
    //int -> 4����Ʈ -> 21������
    public long Gem { get; set; }
    public long Gold { get; set; }

    public void SetDafaultData()
    {
        Logger.Log($"{GetType()} :: SetDafaultData");

        Gem = 0;
        Gold = 0;
    }

    public bool LoadData()
    {
        Logger.Log($"{GetType()} :: LoadData");

        bool result = false;

        try
        {
            Gem = long.Parse(PlayerPrefs.GetString("Gem"));
            Gold = long.Parse(PlayerPrefs.GetString("Gold"));
            result = true;

            Logger.Log($"Gem : {Gem} / Gold : {Gold}");
        }
        catch (System.Exception e)
        {
            Logger.LogError($"Load failed ({e.Message})");
        }
        return result;
    }

    public bool SaveData()
    {
        Logger.Log($"{GetType()} :: SaveData");

        bool result = false;

        try
        {
            PlayerPrefs.GetString("Gem", Gem.ToString());
            PlayerPrefs.GetString("Glod", Gold.ToString());
            PlayerPrefs.Save();
            result = true;

            Logger.Log($"Gem : {Gem} / Gold : {Gold}");
        }
        catch (System.Exception e)
        {
            Logger.LogError($"Save failed ({e.Message})");
        }
        return result;
    }


}
