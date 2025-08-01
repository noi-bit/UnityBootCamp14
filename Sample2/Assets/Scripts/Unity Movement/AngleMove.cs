using UnityEngine;

// 플레이어를 45도 방향으로 직진하게 하는 코드

public class AngleMove : MonoBehaviour
{
    [SerializeField] float angle_degree; //각도(도)
    [SerializeField] float speed;        //속도(움직일때 사용할 수치)

    void tan()
    {
        var radian = Mathf.Deg2Rad * angle_degree;
        Mathf.Tan(radian);
        transform.position = new Vector3 (radian, 0, 0);
    }
    void Update()
    {
        //var radian = Mathf.Deg2Rad * angle_degree;
        //Vector3 pos = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian));

        //transform.Translate(pos * speed * Time.deltaTime);
        ////=transform.position = new Vector3(x, y, 0); 이 문법과 같다

        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    transform.position = Vector3.zero;
        //}
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            tan();
        }
    }
}
