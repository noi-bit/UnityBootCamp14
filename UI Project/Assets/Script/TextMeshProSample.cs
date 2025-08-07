using UnityEngine;
using TMPro;

public class TextMeshProSample : MonoBehaviour
{
    public TextMeshProUGUI textUI; //TMP를 사용하는 UI 컴포넌트

    private void Start()
    {
        textUI.text = "<size=150%>안녕하세요 ㅠㅠ<size=150%> <s>이 말 취소</s>";
        //리치 텍스트(HTML 태그같은느낌) 제공
    }

    public void SetText(bool warning)
    {
        if(warning)
        {
            textUI.text = "<color=red><b>WARNING!!!</b></color>";
        }
        else
        {
            textUI.text = "<color=green>NORMAL</color>";
        }
    }
}
