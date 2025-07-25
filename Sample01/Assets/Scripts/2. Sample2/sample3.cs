using UnityEngine;
//����Ƽ���� �����Ǵ� Ŭ������ ����� ��ũ��Ʈ�� �ۼ��մϴ�.

/*1. ����Ƽ�� Transform Ŭ���� ���
Ʈ�������� ����Ƽ �����Ϳ��� ���� ������Ʈ�� ������ ��, ��� ���� ������Ʈ��
�⺻������ �ο��Ǵ� ������Ʈ�� �ǹ��մϴ�.
�ش� ������Ʈ�� ��ġ(Position), ȸ��(Roatation), ũ��(Scale)�� ���� ������ �������ֽ��ϴ�.
*������Ʈ�� ����� ȣ���ϴ� GetComponent<T>�� ������� �ʰ� �ٷ� ����� �����մϴ�.
(��� ������Ʈ�� �����ϱ� ������)*/

//�ش� Ŭ������ �������ִ� �ֿ� �Ӽ�(Property)
/*transform.position - ���� ������Ʈ�� ��ġ ������ �ǹ��մϴ�.
Vector3 ������ ������, x,y,z���� ���� float(�Ǽ��� ǥ�� ����)*/

/*transform.rotation - ���� ������Ʈ�� ȸ�� ������ �ǹ��մϴ�.(���� �ε巴�� ȸ��)
Quaternion ������ ������, x,y,z�� w 4���� �� ��� - float ����*/

/*transform.eulerAngles - ���� ������Ʈ�� ȸ������ �� �ǹ��մϴ�
Vector3 ������ ������, x,y,z 3���� �ุ ��� - float ����*/

/*transform.forward - ���� ������Ʈ ������ "����"�� ��Ÿ���� ��*/

/*transform.up - ���� ������Ʈ ������ "���"�� ��Ÿ���� ��*/

/*transform.right - ���� ������Ʈ ������ "������"�� ��Ÿ���� ��*/


//*TIP : �޼ҵ� "()" �ȿ� �ۼ��� ������ �ش� ����� ������ �� �������� ���� ���� ǥ�� -- parameter(�Ķ����)
/*�ش� Ŭ������ �������ִ� �ֿ� ����(�޼ҵ�)
transform.LookAt(Transform target) - ������Ʈ�� �־��� Ÿ���� ���ϵ��� ������Ʈ�� ȸ����Ű�� ���
transform.Rotate(Vector3 eulerAngles) - ���޹��� ������ �������� ���� ������Ʈ�� ȸ����Ű�� ���(Vector 3)
transform.Translate(Vector3 translation) - �־��� ����ŭ ���� ������Ʈ�� �̵���Ű�� ���*/

public class sample3 : MonoBehaviour
{
    //transform�� �̿��� ������Ʈ�� ������Ʈ ����
    public GameObject go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(go.transform.GetComponent<sample4>().value);//go.GetComponent<Sample4>().value �� ��뵵 ����
        //��� ������Ʈ���� ������ transform�� �ֱ� ������
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
