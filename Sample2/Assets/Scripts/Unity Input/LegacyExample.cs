using UnityEngine;
using UnityEngine.UI;

//특정 키를 입력하면 텍스트의 특정 메세지가 나오도록 하는 코드

public class LegacyExample : MonoBehaviour
{
    public Text text;
    KeyCode key;

    private void Start()
    {
        text = GetComponentInChildren<Text>();//GetComponent는 본인에게 붙어있는 컴포넌트라서 children을 붙여준다
        //GetComponentInChildren<T>();
        //현 오브젝트의 자식으로부터 컴포넌트를 얻어오는 기능
    }
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    text.text = "뿅!";
        //}
        //if(Input.GetKeyDown(KeyCode.Return)) //Return은 키보드의 Enter
        //{
        //    text.text = "반가워~ > <";
        //}
        //if(Input.GetKeyDown(KeyCode.Escape)) //ESC 키
        //{
        //    text.text = "";
        //}

        //KeyCode 형태의 데이터 전체를 열거형 형태로 조사합니다
        //배열과 같은 묶음으로 관리되는 데이터를 순차적으로 조사하는 코드
        //foreach(데이터 변수명 in 묶음)
        //{
        //
        //}
        foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode)))//이 밑에 코드에서 foreach를 제외해도 됨
        {
            if(Input.GetKeyDown(key))
            {
                switch(key) //enum을 작업할때 switch를 사용하면 좀더 쉽다 (ex)case 직업.불 : 이런식으로?
                {
                    case KeyCode.Escape:
                        text.text = "";
                    break;
                    case KeyCode.Space:
                        text.text = "우앵 ㅠㅠㅠ";
                    break;
                    case KeyCode.Return:
                        text.text = "어려워";
                    break;
                }
            }
        }
    }
}
