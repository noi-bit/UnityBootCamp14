using UnityEngine;

public interface IUserData
{
    // �⺻������ ������ �ʱ�ȭ �ϴ� �Լ�
    void SetDefaultData();

    // �����͸� �ε� �ϴ� �Լ�
    bool LoadData();

    // �����͸� ���� �ϴ� �Լ�
    bool SaveData();
}
