using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    // ����� ���� ������ ���� ���� Ȯ�� ����
    public bool ExistsSaveData {  get; private set; }

    // ��� ���� ������ �ν��Ͻ��� �����ϴ� �����̳�
    public List<IUserData> UserDataList { get; private set; } = new List<IUserData>();

    protected override void Init()
    {
        base.Init();

        // ��� ���� �����͸� UserDataList �� �ν��Ͻ� �߰�
        UserDataList.Add(new UserSettingsData());
        UserDataList.Add(new UserGoodsData());
    }

    public void SetDefaultUserData()
    {
        foreach (var UserData in UserDataList)
        {
            UserData.SetDefaultData();
        }
    }

    public void LoadUserData()
    {
        ExistsSaveData = PlayerPrefs.GetInt("ExistsSaveData") == 1 ? true : false;

        if (ExistsSaveData)
        {
            foreach (var UserData in UserDataList)
            {
                UserData.LoadData();
            }
        }
    }

    public void SaveUserData()
    {
        bool hasSaveError = false;

        foreach (var UserData in UserDataList)
        {
            bool isSaveSuccess = UserData.SaveData();
            if (isSaveSuccess == false)
            {
                hasSaveError = true;
            }
        }

        if (hasSaveError == false)
        {
            ExistsSaveData = true;
            PlayerPrefs.SetInt("ExistsSaveData", 1);
            PlayerPrefs.Save();
        }
    }
}
