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
        rand = Random.Range(0, 10);//0~9
        // 0 1 2 3 4 5 6 7 8 9
        // ���߿��� 9���� ���� ���� ���� Ȯ��? 90%
    }
}
