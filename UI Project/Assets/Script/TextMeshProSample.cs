using UnityEngine;
using TMPro;

public class TextMeshProSample : MonoBehaviour
{
    public TextMeshProUGUI textUI; //TMP�� ����ϴ� UI ������Ʈ

    private void Start()
    {
        textUI.text = "<size=150%>�ȳ��ϼ��� �Ф�<size=150%> <s>�� �� ���</s>";
        //��ġ �ؽ�Ʈ(HTML �±װ�������) ����
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
