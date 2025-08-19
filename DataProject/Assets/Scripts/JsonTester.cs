using System;
using UnityEngine;

public class JsonTester : MonoBehaviour
{
    //����Ƽ���� ��ü(Object)�� �ʵ�(field)�� json���� ��ȯ�ϱ� ���ؼ���
    //���������� �޸𸮿��� �����͸� �а� ���� �۾��� �����ؾ� ��
    //���� [Serializable] �Ӽ��� �߰��� �ش� ������ ���� ����ȭ�� ó������ �ʿ䰡 �ִ�

    //����ȭ[Serializable] : �����͸� �����ϰų� �����ϱ� ���� �������� �������� ���·� �������ִ� �۾�
    //Unity������ ȭ�鿡�� ���������� �������Բ� �� �� �ִ�

    [Serializable]
    public class Data
    {
        public int hp;
        public int atk;
        public int def;
        public string[] items;
        public Position position;
        public string Quest;
        public bool isDead;
    }

    [Serializable]
    public class Position
    {
        public float x;
        public float y;
    }

    public Data my_data;

    private void Start()
    {
        var jsontext = Resources.Load<TextAsset>("data");

        if(jsontext == null)
        {
            Debug.LogError("�ش� JSON������ ���ҽ� �������� ã�� ���߽��ϴ�");
            return;
        }
        my_data = JsonUtility.FromJson<Data>(jsontext.text);//Json ���ڿ��� ��ü�� ���·� ��ȯ�մϴ�

        Debug.Log(my_data.hp);
        Debug.Log(my_data.Quest);
        Debug.Log(my_data.def);
        Debug.Log(my_data.position.x);
        Debug.Log(my_data.position.y);

        foreach(var item in my_data.items)
        {
            Debug.Log(item);
        }
    }
    
}