using UnityEngine;
// �ﰢ�Լ�
// ����Ƽ���� �������ִ� �ﰢ�Լ��� �ַ� ȸ��, ī�޶� ����, �, �����ӿ� ���� ǥ������ ����(�ַ� ȸ���� ���� �Լ�)

// Ư¡) ������ �������� ��� �� 1���� = �� 57��

public class TFuntion : MonoBehaviour
{
    // ���)
    // Sin(Radian) : �־��� ������ Y��ǥ (���� ���� ��ġ ����Ҷ� ���)
    // Cos(Radian) : �־��� ������ X��ǥ (���� ���� ��ġ ����Ҷ� ���)
    // Tan(Radian) : �־��� ������ ���� (Y/X)

    // ����ȸ��
    public void CircleRotate()
    {
        float angle = Time.time * 90.0f;
        float radian = angle * Mathf.Deg2Rad;   //angle�� (��->����)�� �����ָ� �������� ��ȯ�˴ϴ�

        var x = Mathf.Cos(radian) * 5.0f;       //var = ����Ÿ��, ���� ������ ���� �˸°� ������
        var y = Mathf.Sin(radian) * 5.0f;

        transform.position = new Vector3(x, y, 0);
    }

    public void Butterfly()
    {
        float t = Time.time * 2;
        float x = Mathf.Sin(t) * 8;
        float y = Mathf.Sin(t * 2f) * 2 * 2;

        transform.position = new Vector3( x, y, 0);
    }

    // Time.time : �������� ������ ���������� �ð�
    // Time.deltaTime : �������� �����ϰ� ������ �ð�

    public void Wave()
    {
        var offset = Mathf.Sin(Time.time * 2.0f) * 0.5f; //Sin�̵� Cos�̵� �ุ �޾Ƽ� �����̱� ������ �Դٰ��� �� 
        transform.position = pos + Vector3.up * offset; //�Դٰ��� �ϴ� ����
        //                   ��ġ + Vector3.���� * ��ǥ��
    }

    Vector3 pos;

    private void Start()
    {
        pos = transform.position; //������ �� �� ��ũ��Ʈ�� �������ִ� ������Ʈ�� ��ġ ����
    }

    void Update()
    {
        // ���콺 ���� Ŭ�� ���� ���� CircleRotate ȣ��
        if (Input.GetMouseButton(0))
        {
            CircleRotate();
        }

        if (Input.GetMouseButton(1)) // ���콺 ��Ŭ��
        {
            Wave();
        }

        if (Input.GetMouseButton(2))
        {
            Butterfly();
        }
    }
}
