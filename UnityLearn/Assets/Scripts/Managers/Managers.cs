using System;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; //static - ���ϼ� ����
    //�� �̵��� �������� �ٲ�� null�� �� --> �׷��� DontDestroyOnLoad() �Լ��� ���
    //�������� ���� �̵��ص� �״�� ������ �� --> int age = 30; �̷���

    static public Managers GetInstance { get { Init(); return Instance; } }
                                       //�Ŵ��� ��ü�� ������ �ʴ��� �ܺ� Ŭ�������� Instance�� ȣ��� �� Init���� ��������Բ� ��

    void Start()
    {
        //Instance = this; //-> �÷��̸� ������ ���� ��ü�� ������ �Ǹ� �ڱ� �ڽ��� �ش� ��ü�� ����ش�
        Init();
    }

    void Update()
    {
        
    }

    static void Init()
    {
        if(Instance == null)
        {
            GameObject go = GameObject.Find("@@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            Instance = go.GetComponent<Managers>();
        }
    }
}
