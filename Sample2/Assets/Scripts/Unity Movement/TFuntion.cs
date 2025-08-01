using UnityEngine;
// 삼각함수
// 유니티에서 제공해주는 삼각함수는 주로 회전, 카메라 제어, 곡선, 움직임에 대한 표현으로 사용됨(주로 회전에 관한 함수)

// 특징) 단위를 라디안으로 사용 ※ 1라디안 = 약 57도

public class TFuntion : MonoBehaviour
{
    // 요약)
    // Sin(Radian) : 주어진 각도의 Y좌표 (세로 방향 위치 계산할때 사용)
    // Cos(Radian) : 주어진 각도의 X좌표 (가로 방향 위치 계산할때 사용)
    // Tan(Radian) : 주어진 각도의 기울기 (Y/X)

    // 원형회전
    public void CircleRotate()
    {
        float angle = Time.time * 90.0f;
        float radian = angle * Mathf.Deg2Rad;   //angle에 (도->라디안)을 곱해주면 라디안으로 변환됩니다

        var x = Mathf.Cos(radian) * 5.0f;       //var = 오토타입, 값의 유형에 따라 알맞게 정해줌
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

    // Time.time : 프레임이 시작한 순간부터의 시간
    // Time.deltaTime : 프레임이 시작하고 끝나는 시간

    public void Wave()
    {
        var offset = Mathf.Sin(Time.time * 2.0f) * 0.5f; //Sin이든 Cos이든 축만 받아서 움직이기 때문에 왔다갔다 함 
        transform.position = pos + Vector3.up * offset; //왔다갔다 하는 방향
        //                   위치 + Vector3.방향 * 좌표값
    }

    Vector3 pos;

    private void Start()
    {
        pos = transform.position; //시작할 떄 이 스크립트를 가지고있는 오브젝트의 위치 맵핑
    }

    void Update()
    {
        // 마우스 왼쪽 클릭 유지 동안 CircleRotate 호출
        if (Input.GetMouseButton(0))
        {
            CircleRotate();
        }

        if (Input.GetMouseButton(1)) // 마우스 우클릭
        {
            Wave();
        }

        if (Input.GetMouseButton(2))
        {
            Butterfly();
        }
    }
}
