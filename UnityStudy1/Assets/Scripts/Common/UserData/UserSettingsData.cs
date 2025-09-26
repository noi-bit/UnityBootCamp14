using UnityEngine;

public class UserSettingsData : IUserData
{
    //����ڰ� ���带 ������� ���� ����
    public bool Sound { get; set; }

    public void SetDafaultData()
    {
        Logger.Log($"{GetType()} :: SetDefaultData");
        Sound = true;
    }

    //�ʱ� ����
    public bool LoadData()
    {
        Logger.Log($"{GetType()} :: LoadData");
        bool result = false;

        try
        {
            Sound = PlayerPrefs.GetInt("Sound") == 1? true : false;
            result = Sound;
            
            Logger.Log($"Sound : {Sound}");
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
            PlayerPrefs.SetInt("Sound", Sound? 1 : 0);
            PlayerPrefs.Save(); //PlayerPrefs ��� �� ���� �� �� �ݵ�� Save�ؾ���
            result = true;

            Logger.Log($"Sound : {Sound}");
        }
        catch (System.Exception e)
        {
            Logger.LogError($"Save failed ({e.Message})");
        }
        return result;
    }
}
