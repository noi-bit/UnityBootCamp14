using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    //저장된 유저데이터 존재 여부 확인
    public bool ExistsSaveData { get; private set; }

    //모든 유저데이터 인스턴스 저장하는 컨테이너
    public List<IUserData> UserDataList { get; private set; } = new List<IUserData>();

    protected override void Init()
    {
        //base의 Init을 해야만 싱글턴 객체가 생성되니까
        base.Init();

        //모든 유저 데이터를 UserDataList에 추가
        UserDataList.Add(new UserSettingsData());
        UserDataList.Add(new UserGoodsData());
    }

    //모든 유저데이터 초기화
    public void SetDefaultUserData()
    {
        for (int i = 0; i < UserDataList.Count; i++)
        {
            UserDataList[i].SetDafaultData();
        }
    }

    //모든 유저데이터를 로드
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

    //모든 유저데이터를 저장
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
