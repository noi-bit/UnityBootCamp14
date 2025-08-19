using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestSelf1 : MonoBehaviour
{
    //TestSelf1에서 사용하려면 if(버튼을 누르면?) 유니티이벤트 랜덤아이템출력?.Invoke(); 스타트에서는 랜덤아이템출력.AddListener(랜덤아이템텍스트출력)


    public UnityEvent OnButtonEnter;
    public Button randomButton;
    public Text 안내텍스트;
    public Text inputtext;
    public Text itemtext;
    //int input;

    private void Start()
    {
        안내텍스트.text = "버튼을 눌러주십시오";
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
            inputtext.text = $"{a}를 선택하셨습니다.";
            Debug.Log($"{a}를 선택하셨습니다.");

            switch (a)
            {
                case 0:
                    {
                        itemtext.text = "<종말의 여왕> 아이템을 얻었습니다";
                    }
                    break;
                case 7:
                    {
                        itemtext.text = "<태양의 불꽃망토> 아이템을 얻었습니다";
                    }
                    break;
                case 9:
                    {
                        itemtext.text = "<고속연사포> 아이템을 얻었습니다";
                    }
                    break;
                case 2:
                    {
                        itemtext.text = "<시작의 단검> 아이템을 얻었습니다";
                    }
                    break;
                case 4:
                    {
                        itemtext.text = "<무한의 대검> 아이템을 얻었습니다";
                    }
                    break;
                case 10:
                    {
                        itemtext.text = "<라바돈의 모자> 아이템을 얻었습니다";
                    }
                    break;
                default:
                    {
                        itemtext.text = "아이템을 얻지 못했습니다";
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
    //            inputtext.text = $"입력된 숫자 : {i+1}";
    //            Debug.Log($"<color=yellow><{i+1}>입력 이벤트 실행</color>");

    //            if (i == a)
    //            {
    //                itemtext.text = "아이템을 얻었습니다";
    //            }
    //            else
    //            {
    //                itemtext.text = "아이템을 얻지 못했습니다";
    //            }
    //        }    
    //    }
    //}

    

    //private void GetKeyDebug(object sender, EventArgs e)
    //{
    //    Debug.Log("<color=yellow>엔터 키 입력 이벤트 실행</color>");
    //}
}
