using UnityEngine;

//������Ʈ ĳ�̿� ���Ͽ�(Object cashing)
//ĳ��(Cashe) - ���� ���Ǵ� �����ͳ� ���� �̸� �����صδ� �ӽ� ���

//ĳ�� ��� �ǵ�
//1. �ð� ������ : ���� �ֱٿ� ���� ���� �ٽ� ���� ���ɼ��� ����.
//2. ���� ������ : �ֱٿ� ������ �ּҿ� ������ �ּ��� ������ ���� ���ɼ��� ����.

public class Sample03 : MonoBehaviour
{ 
    Rigidbody rb;
    Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //ĳ��(cashing) : �ӽ� ���� �����͸� �������� ����
        //������ �����س� �Ź� �ҷ����� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(pos * 5);
        //�� �����Ӹ��� ȣ��, �� �����Ӹ��� GetComponent�� ������ �������� �׸�ŭ ���� ����
        //�Ͻ������� �ѹ��� �ҷ��� ���� ��� ����(�����ϸ� update���� ��� x)
    }
}
