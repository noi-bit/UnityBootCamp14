using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//6-2번째 스크립트

//총알에 대한 정보, 총알 반남, 총알 이동
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;//총알 이동 속도
    public float life_time = 2.0f;//총알 반납 시간
    public GameObject effect_prefab;//이펙트 프리팹

    //연결해줘야하는 값
    private BulletPool pool;//풀(총알이 저장될 위치)
    private Coroutine life_coroutine;
    private int EnemyLifecount;

    //풀 설정(풀에서 해당 값 호출)
    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }

    //활성화 단계
    private void OnEnable()
    {
        life_coroutine = StartCoroutine(BulletReturn());//코루틴 작성이 가능한 영역(Enable,Disable)
    }

    private void OnDisable()
    {
        if(life_coroutine != null)
            StopCoroutine(life_coroutine);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    IEnumerator BulletReturn()
    {
        yield return new WaitForSeconds(life_time);
        ReturnPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        //부딪힌 대상이 Enemy 태그를 가지고 있는 오브젝트일 경우
        //데미지를 입힙니다. 와 같은 데미지 관련 코드 작성
        //EnemyLifecount = new EnemyMoveAI
        //이펙트 연출(파티클)
        if (effect_prefab != null)
        {
            Instantiate(effect_prefab, transform.position, Quaternion.identity);
        }
        
        ReturnPool();
    }


    //메소드의 명령이 한줄일 경우, => 로 사용할 수 있다
    void ReturnPool() => pool.Return(gameObject);//pool에 값이 없으면 nullreference가 된다
}
