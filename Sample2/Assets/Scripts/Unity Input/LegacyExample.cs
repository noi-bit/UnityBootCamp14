using UnityEngine;
using UnityEngine.UI;

//Ư�� Ű�� �Է��ϸ� �ؽ�Ʈ�� Ư�� �޼����� �������� �ϴ� �ڵ�

public class LegacyExample : MonoBehaviour
{
    public Text text;
    KeyCode key;

    private void Start()
    {
        text = GetComponentInChildren<Text>();//GetComponent�� ���ο��� �پ��ִ� ������Ʈ�� children�� �ٿ��ش�
        //GetComponentInChildren<T>();
        //�� ������Ʈ�� �ڽ����κ��� ������Ʈ�� ������ ���
    }
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    text.text = "��!";
        //}
        //if(Input.GetKeyDown(KeyCode.Return)) //Return�� Ű������ Enter
        //{
        //    text.text = "�ݰ���~ > <";
        //}
        //if(Input.GetKeyDown(KeyCode.Escape)) //ESC Ű
        //{
        //    text.text = "";
        //}

        //KeyCode ������ ������ ��ü�� ������ ���·� �����մϴ�
        //�迭�� ���� �������� �����Ǵ� �����͸� ���������� �����ϴ� �ڵ�
        //foreach(������ ������ in ����)
        //{
        //
        //}
        foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode)))//�� �ؿ� �ڵ忡�� foreach�� �����ص� ��
        {
            if(Input.GetKeyDown(key))
            {
                switch(key) //enum�� �۾��Ҷ� switch�� ����ϸ� ���� ���� (ex)case ����.�� : �̷�������?
                {
                    case KeyCode.Escape:
                        text.text = "";
                    break;
                    case KeyCode.Space:
                        text.text = "��� �ФФ�";
                    break;
                    case KeyCode.Return:
                        text.text = "�����";
                    break;
                }
            }
        }
    }
}
