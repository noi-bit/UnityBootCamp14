using UnityEngine;

public class UnityIRandom : MonoBehaviour
{
    [ContextMenuItem("���� �� ȣ��","MenuAttributesMethod")]
    public int rand;

    public void MenuAttributesMethod()
    {
        //Random.Range() : ����Ƽ�� ����
        //�ּҰ� ��������~ �ִ밪 ����X (�����ϰ��)

        //�ּҰ� ���� ����~ �ִ밪 ����O (�Ǽ��ϰ��)
        rand = Random.Range(0, 11);//0~10
    }
}
