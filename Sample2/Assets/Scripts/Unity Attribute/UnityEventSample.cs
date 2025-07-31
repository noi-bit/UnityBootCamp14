using UnityEngine;
using UnityEngine.Events;

public class UnityEventSample : MonoBehaviour
{
    //Tooltip�� �ν����Ϳ��� �ʵ� ���� ���콺�� �÷����� ������ �����ִ� ���
    [Tooltip("�̺�Ʈ ����Ʈ�� �߰��ϰ�, ������ ����� ���� ���� ������Ʈ�� ����ϼ���")]
    public UnityEvent action;

    private void Update()
    {
        action.Invoke(); // �׼ǿ� ��ϵ� �Լ��� �����մϴ�(�ν����Ϳ��� � �Լ��� ������� ��������)
    }

    public void Rotate()
    {
        gameObject.transform.Rotate(1, 0, 0);
    }

    public int x;
    public void Move()
    {
    }
}
