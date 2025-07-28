using UnityEngine;

public class Sphericalnter : MonoBehaviour //구면 선형 보간(Spherically interpolate) - Cube b
{
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0.0f; //(0부터 1까지의 범위를 가지고있다)


    private void Start()
    {
        start_position = transform.position; //해당 스크립트를 가지고있는 오브젝트 - Cube a
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
