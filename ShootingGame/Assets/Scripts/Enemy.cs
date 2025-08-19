using UnityEngine;
//플레이어와 적의 차이?
//플레이어 : 사용자가 컨트롤 진행
//적 : 정해진 명령에 따라 자동으로 움직임

public class Enemy : MonoBehaviour
{
    public EnemyManager manager;
    public static int count = 0;
    public int Nextstagecount = 5;
    public float speed = 5;
    public enum EnemyType
    {
        Down, Chase
    }
    public EnemyType type = EnemyType.Down; //기본적으로는 아래로 내려가는 움직임만
    Vector3 dir;//방향설정
    public GameObject explosionFactory;
    public GameObject explosionTexteffect;

    private void Start() //적의 움직임 패턴
    {
        //함수 분리
        //장점 : 1. 보기 쉽다(가독성 높아짐) 2. 재사용성이 높아질 수 있음(공격 패턴 리셋, 재생성 시의 방향 설정 등)
    }

    void Update()
    {
        PatternSetting();
        transform.position += dir * speed * Time.deltaTime;
    }

    void PatternSetting()
    {
        int rand = Random.Range(0, 10); //0 ~ 9 까지의 값 중 하나의 값을 랜덤으로 
        if (rand < 3) // 0,1,2(확률 30%)
        {
            //플레이어 따라가는 기능
            type = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position; // 방향 = 타겟 위치 - 본인 위치
            dir.Normalize(); //방향의 크기를 1로 설정(반올림?같은)
        }
        else
        {
            //아래로 내려가는 기능
            type = EnemyType.Down;
            dir = Vector3.down;
        }
    }

    //OnCollisionEnter : 충돌 발생 시 1번 호출
    //OnCollisionStay : 충돌 유지하는 동안 호출
    //OnCollisionExit : 충돌 발생 후 충돌 작업에서 벗어날 경우 1번 호출

    //OnTriggerXXX로 위와 같은 형태의 문법을 가지고 있다.
    //2D일 경우 - OnCollisionEnter2D처럼 마지막에 2D를 명시해야 함

    //일반적인 물리적 충돌 Collision
    //Is Trigger 체크가 진행된 오브젝트와의 트리거 충돌은? onTriggerEnter(충돌 "여부"만 체크)
    private void OnCollisionEnter(Collision collision)
    {
        //stopspawn();
        //클래스명.Instance.메소드명()으로 기능만 사용하는 것이 가능해짐
        ScoreManager.instance.SetScore(5);

        GameObject explosion = Instantiate(explosionFactory, transform.position, Quaternion.identity);

        int rand = Random.Range(0, 10);
        if(rand < 4)
        {
            GameObject explosionText = Instantiate(explosionTexteffect, transform.position += new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
        //충돌 이벤트 발생
        //오브젝트간의 물리적인 충돌 발생 시 호출
        //둘중 하나라도 Rigidbody를 가지고 있어야 처리됨
        Destroy(collision.gameObject); //상대방 파괴(총알)
        Destroy(gameObject); //자신 파괴

        count++;
    }

    public void stopspawn()
    {
        if (count >= Nextstagecount)
        {
            manager.currentTime = 0;
        }
    }

}
