using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestSelf1 : MonoBehaviour
{
    //TestSelf1���� ����Ϸ��� if(��ư�� ������?) ����Ƽ�̺�Ʈ �������������?.Invoke(); ��ŸƮ������ �������������.AddListener(�����������ؽ�Ʈ���)


    public UnityEvent OnButtonEnter;
    public Button randomButton;
    public Text �ȳ��ؽ�Ʈ;
    public Text inputtext;
    public Text itemtext;
    //int input;

    private void Start()
    {
        �ȳ��ؽ�Ʈ.text = "��ư�� �����ֽʽÿ�";
        OnButtonEnter.AddListener(ButtonSelect);
        randomButton.onClick.AddListener(ButtonSelect);
        
        //if(GetKey0to9 != null)
        //{
        //    GetKey0to9(this, EventArgs.Empty);
        //}
        //GetKey0to9 += ButtonSelect;
    }
    void Update()
    {
        //if ()
        //{
        //    OnButtonEnter?.Invoke();
        //}
    }
   // public void ButtonSelect(object sender, EventArgs e)
    public void ButtonSelect()
    {
        
         int a = UnityEngine.Random.Range(0, 11);
            inputtext.text = $"{a}�� �����ϼ̽��ϴ�.";
            Debug.Log($"{a}�� �����ϼ̽��ϴ�.");

            switch (a)
            {
                case 0:
                    {
                        itemtext.text = "<������ ����> �������� ������ϴ�";
                    }
                    break;
                case 7:
                    {
                        itemtext.text = "<�¾��� �Ҳɸ���> �������� ������ϴ�";
                    }
                    break;
                case 9:
                    {
                        itemtext.text = "<��ӿ�����> �������� ������ϴ�";
                    }
                    break;
                case 2:
                    {
                        itemtext.text = "<������ �ܰ�> �������� ������ϴ�";
                    }
                    break;
                case 4:
                    {
                        itemtext.text = "<������ ���> �������� ������ϴ�";
                    }
                    break;
                case 10:
                    {
                        itemtext.text = "<��ٵ��� ����> �������� ������ϴ�";
                    }
                    break;
                default:
                    {
                        itemtext.text = "�������� ���� ���߽��ϴ�";
                    }
                break;
            

            }
    }
    //public void GetKey0to9Select(object sender, EventArgs e)
    //{
    //    KeyCode[] inputs = { KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6 };
    //    int a = UnityEngine.Random.Range(1, 7);
    //    for (int i = 0; i < inputs.Length; i++)
    //    {
    //        if (Input.GetKeyDown(inputs[i]))
    //        {
    //            //input = i;
    //            inputtext.text = $"�Էµ� ���� : {i+1}";
    //            Debug.Log($"<color=yellow><{i+1}>�Է� �̺�Ʈ ����</color>");

    //            if (i == a)
    //            {
    //                itemtext.text = "�������� ������ϴ�";
    //            }
    //            else
    //            {
    //                itemtext.text = "�������� ���� ���߽��ϴ�";
    //            }
    //        }    
    //    }
    //}

    

    //private void GetKeyDebug(object sender, EventArgs e)
    //{
    //    Debug.Log("<color=yellow>���� Ű �Է� �̺�Ʈ ����</color>");
    //}
}
