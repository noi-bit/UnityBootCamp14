using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject player;
    public Text text;
    private static int score=0;//점수

    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
        text.text = "Score :" + score;
    }

    void Update()
    {
        transform.Translate(0, -3f*Time.deltaTime, 0);

        //낙하물의 y축이 -2보다 작다면 낙하물을 파괴하는 코드
        if(transform.position.y < -2)
        {
            Destroy(gameObject);//명령 이후로 영구적으로 파괴 
        }
        
        //충돌 판정 처리
        //원에 의한 충돌 판정 로직 사용
        Vector3 v1 = transform.position;//낙하물의 Vector3 변수(현재스크립트가 적용되는 오브젝트)
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2;//v1과 v2 사이의 위치

        float d = dir.magnitude;//벡터의 크기 또는 길이를 의미합니다(두 점 사이의 거리를 계산할 때 사용합니다)
        float obj_r = 0.5f;
        float obj_r2 = 1.0f;

        //두 값 사이의 거리인 d의 값이 설정한 값 크다면 충돌하지 않는 상황, 값보다 작아진다면 충돌 
        if(d < obj_r +  obj_r2)
        {
            Destroy(gameObject);
        }

        
    }
}
