using UnityEngine;

public class Sample02 : MonoBehaviour
{
    public Sample01 sample1;
    //Sample1���� Awake���� ������Ʈ�� ������ ���

    private void Awake()
    {
        sample1 = GameObject.FindWithTag("s1").GetComponent<Sample01>();
        //1.GameObject.FindWithTag("�±��̸�") - ������ �ش� �±׸� ������ �ִ� ������Ʈ�� �˻��ϴ� ���
        //�� ����� ���� �޾ƿ��� �� ==> gameObject

        //2.gameObject.GetComponent<T>
        //���� ������Ʈ�� GetComponent<T>�� ���� T�� ������Ʈ ������ �ۼ����ָ�
        //�ش� ���ӿ�����Ʈ�� ������Ʈ�� ������ �ִ� ���� �����ɴϴ�.
        //�� ����� ���� �޾ƿ��� �� ==> T

        Debug.Log(sample1.cc.message);
    }
}
