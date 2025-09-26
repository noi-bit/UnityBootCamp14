using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    //����� ���������� ���� ���� Ȯ��
    public bool ExistsSaveData { get; private set; }

    //��� ���������� �ν��Ͻ� �����ϴ� �����̳�
    public List<IUserData> UserDataList { get; private set; } = new List<IUserData>();

    protected override void Init()
    {
        //base�� Init�� �ؾ߸� �̱��� ��ü�� �����Ǵϱ�
        base.Init();

        //��� ���� �����͸� UserDataList�� �߰�
        UserDataList.Add(new UserSettingsData());
        UserDataList.Add(new UserGoodsData());
    }

    //��� ���������� �ʱ�ȭ
    public void SetDefaultUserData()
    {
        for (int i = 0; i < UserDataList.Count; i++)
        {
            UserDataList[i].SetDafaultData();
        }
    }

    //��� ���������͸� �ε�
    public void LoadUserData()
    {
        ExistsSaveData = PlayerPrefs.GetInt("ExistsSaveData") == 1 ? true : false;

        if (ExistsSaveData == true)
        {
            for (int i = 0; i < UserDataList.Count; i++)
            {
                UserDataList[i].LoadData();
            }
        }
    }

    //��� ���������͸� ����
    public void SaveUserData()
    {
        bool hasSaveError = false;

        for(int i = 0; i< UserDataList.Count; i++)
        {
            bool isSaveSuccess = UserDataList[i].SaveData();
            if(isSaveSuccess == false)
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
