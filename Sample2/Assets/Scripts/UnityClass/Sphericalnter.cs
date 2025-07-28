using UnityEngine;

public class Sphericalnter : MonoBehaviour //���� ���� ����(Spherically interpolate) - Cube b
{
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
        if (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(start_position, target.position, t);
        }
    }
}
