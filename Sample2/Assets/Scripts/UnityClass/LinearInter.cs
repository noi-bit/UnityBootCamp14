using UnityEngine;

public class LinearInter : MonoBehaviour //���� ����(linear interpolate) - Cube a
{
    //Vector3.Lerp(start,end,t);
    //start -> end���� t�� ���� ���� �����մϴ�.
    //--> �ش� �������� ���� ���� õõ�� �̵��ϴ� �ڵ�
    //t�� ����(0 ~ 1 -- float ������)

    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0.0f; //(0���� 1������ ������ �������ִ�)


    private void Start()
    {
        start_position = transform.position; //�ش� ��ũ��Ʈ�� �������ִ� ������Ʈ - Cube a
    }

    private void Update()
    {
        //������ ������ �ʾ��� ���� �̵��� �����ϰڽ��ϴ�, t�� 1�̸� ���̶�� ��
        if(t<1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start_position, target.position, t);
        }
    }
}
