using System.Collections;
using UnityEngine;
//숙제-1 스크립트
//EnemyMoveAI스크립트를 달고있는 오브젝트를 스폰

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemyprefab;//Enemy 프리팹을 드래그드롭 설정
    public Transform spawnPoint;//스크립트가 달려있는 오브젝트의 위치를 드래그드롭
    public float interval = 5.0f;//유닛 생성 시간 간격
    public GameObject boss;
    private float timer = 0f;
    public GameObject effect_prefab;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        ScoreControlSample sm = Object.FindAnyObjectByType<ScoreControlSample>();
        while (true)
        {
            if (sm.score >= 100)
            {
                interval = 3.0f;
            }
            Instantiate(Enemyprefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);//interval 타임 만큼 대기
            //StopCoroutine(Spawn());
            Debug.Log($"{spawnPoint.position}에서 {Enemyprefab.name}유닛이 생성되었습니다.");
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5f && timer < 10f)
        {
            effect_prefab.SetActive(true);
        }
        else if (timer >= 10f)
        {
            effect_prefab.SetActive(false);
        }

        if (timer >= 10f)
        {
            boss.SetActive(true);

            Debug.Log("보스 등장!");
            this.enabled = false; // 타이머 비활성화 (1회만 실행되게)
        }
        //private void OnCollisionEnter(Collision collision)
        //{

        //    bullet = GameObject.FindGameObjectWithTag("Bullet")?.transform;//총알의 포지션
        //    float bulletenter = Vector3.Distance(transform.position, bullet.position);

        //    if (bulletenter <= 0)
        //    {

        //    }
        //}
    }
}
