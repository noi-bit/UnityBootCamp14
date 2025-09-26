using UnityEngine;

public interface IUserData
{
    //기본값으로 데이터를 초기화 하는 함수
    void SetDafaultData();

    //데이터를 로드하는 함수
    bool LoadData();

    //데이터를 저장하는 함수
    bool SaveData();
}
