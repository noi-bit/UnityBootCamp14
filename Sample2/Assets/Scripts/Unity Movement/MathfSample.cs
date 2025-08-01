using UnityEngine;
//�߿� Ŭ���� Mathf
//����Ƽ���� ���� ���� ��ƿ��Ƽ Ŭ����
//���� ���߿��� ���� �� �ִ� ���� ���꿡 ���� ���� �޼ҵ�� ����� ����
//ex)���� �޼ҵ� : static Ű����� ������ �ش� �޼ҵ�� Ŭ������.�޼ҵ��()���� ����� ����
//:  Mathf.Abs(-5)


public class MathfSample : MonoBehaviour
{
    //�⺻������ ���Ǵ� �޼ҵ�
    float abs = -5;
    float ceil = 4.1f;
    float floor = 4.6f;
    float round = 4.5f;
    float clamp;
    float clamp01;
    float pow = 2;
    float sqrt = 4;

    void Start()
    {
        Debug.Log(Mathf.Abs(abs));              // ����(absolute number)
        Debug.Log(Mathf.Ceil(ceil));            // �ø�(�Ҽ����� ������� �� �ø�ó��), �Ҽ��� �����(ceil, ceilint - float���� int�� �ٲ���(������ �Ҽ����� ������� ������)
        Debug.Log(Mathf.Floor(floor));          // ����(�Ҽ����� ������� �� ����ó��)  �Ҽ��� �����(floor, floorint)
        Debug.Log(Mathf.Round(round));          // �ݿø�(5 ���ϸ� ������ �ʰ��� �ø�)  �Ҽ��� �����(round, roundint)
        Debug.Log(Mathf.Clamp(7, 0, 4));        // ���� ���޹��� �� = 7, �ּ� = 0, �ִ� = 4/ ��� -> 4(�ѵ�ġ�� ������ ��� ��갪�� �ѵ�ġ�� �ʰ������ʰ� ������ ���..(������ ��������?))
                                                //                  �� ��, �ּ�, �ִ� ������ ���� �Է��մϴ� 
        Debug.Log(Mathf.Clamp01(5));            // ���� ���޹��� �� = 5, �ּ� = 0, �ִ� = 1(�ڵ� ����) --> ������ ����� �ּڰ� 0 �Ǵ� �ִ� 1�� ó��
                                                // ���޹������� 1���� ũ�� 1, 1���� ������ 0���� ó����
                                                // % ������ ���� ó���� �� ���� ���ȴ�

                                                //=======Clamp vs Clamp01=======
                                                //Clamp   ==> ü��, ����, �ӵ� ���� �ɷ�ġ ���信�� ���� ����
                                                //Clamp01 ==> ����(%), ���� ��(t), ���� ��(���󿡼��� ����)

        Debug.Log("���� :" + Mathf.Pow(pow, 2));                                               //��, ���� ��(����)�� ���޹޾� �ش� ���� �ŵ������� �����
        Debug.Log("������ :" + Mathf.Pow(pow, 0.5f));                                          //Mathf.Sqrt()�� ����ϴ� �ͺ��� ������ �ſ� ����(sqrt�� ��ȣ)
        Debug.Log("������ ������ ��� ���� ���� ���·� ����մϴ� :" + Mathf.Pow(pow, -2f));      //2�� -2 ���� => 1/4
        Debug.Log(Mathf.Sqrt(sqrt));                                                          //���� ���޹޾� �ش� ���� �������� ����� => 4�� 2�� ������ => 2 ���
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
