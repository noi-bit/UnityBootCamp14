using UnityEngine;

public class LinearInter : MonoBehaviour //선형 보간(linear interpolate) - Cube a
{
    //Vector3.Lerp(start,end,t);
    //start -> end까지 t에 따라 선형 보간합니다.
    //--> 해당 방향으로 일정 간격 천천히 이동하는 코드
    //t의 범위(0 ~ 1 -- float 값으로)

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
        //보간이 끝나지 않았을 때만 이동을 진행하겠습니다, t가 1이면 끝이라는 뜻
        if(t<1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start_position, target.position, t);
        }
    }
}
