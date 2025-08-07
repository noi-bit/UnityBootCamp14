using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

//숙제 스크립트

public class EnemyMoveAI : MonoBehaviour //enemy가 움직이는 스크립트
{
    public float speed = 1.0f;//이동속도
    public float detection = 7.0f;//검색범위
    public float EnemyLife = 3;//Enemy의 목숨 포인트 (0이 되면 destroy)
    

    public int scoreValue = 10;

    //private EnemySpawnPool Enemypool;//풀(총알이 저장될 위치)


    //private GameObject bullet;
    private Transform player_position;//플레이어의 포지션

    //public void EnemyPool(EnemySpawnPool pool)
    //{
    //    this.Enemypool = pool;
    //}

    ScoreControlSample sm;
    
    void Start()
    {
        //sample = new ScoreControlSample();
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        //?를 사용해서 Player값이 없거나 접근하지 못할때 오류 대신 nullreference를 표시하게 함
        sm = Object.FindAnyObjectByType<ScoreControlSample>();
        sm.AddScore(0);
        if (player_position != null )
        {
            StartCoroutine(GotoPlayer());//플레이어 포지션이 널이 아닌 경우, GotoPlayer라는 코루틴을 실행하게 함
        }
        else
        {
            Debug.Log("Player를 찾아야겠어!");
        }
    }

    IEnumerator GotoPlayer()
    {
        while(player_position != null)
        {
            float distance = Vector3.Distance(transform.position, player_position.position);
            if(distance <= detection)
            {
                transform.position = Vector3.MoveTowards(transform.position, player_position.position, speed*Time.deltaTime);
            }
            else
            {
                Debug.Log("어디야??");
            }
            yield return null;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {

        //bullet = GameObject.FindGameObjectWithTag("Bullet");
        //float bulletenter = Vector3.Distance(transform.position, bullet.position);
        if (other.gameObject.CompareTag("Bullet")) 
        {
            Enemydestroy();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

    }

    public void Enemydestroy()
    {
        EnemyLife -= 1;
        if (EnemyLife <= 0)
        {
            // 점수 올리기
            
            if (sm != null)
            {
                sm.AddScore(scoreValue);
            }
            gameObject.SetActive(false);
        }
            
    }
}