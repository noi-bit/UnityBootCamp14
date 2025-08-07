using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

//���� ��ũ��Ʈ

public class EnemyMoveAI : MonoBehaviour //enemy�� �����̴� ��ũ��Ʈ
{
    public float speed = 1.0f;//�̵��ӵ�
    public float detection = 7.0f;//�˻�����
    public float EnemyLife = 3;//Enemy�� ��� ����Ʈ (0�� �Ǹ� destroy)
    

    public int scoreValue = 10;

    //private EnemySpawnPool Enemypool;//Ǯ(�Ѿ��� ����� ��ġ)


    //private GameObject bullet;
    private Transform player_position;//�÷��̾��� ������

    //public void EnemyPool(EnemySpawnPool pool)
    //{
    //    this.Enemypool = pool;
    //}

    ScoreControlSample sm;
    
    void Start()
    {
        //sample = new ScoreControlSample();
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        //?�� ����ؼ� Player���� ���ų� �������� ���Ҷ� ���� ��� nullreference�� ǥ���ϰ� ��
        sm = Object.FindAnyObjectByType<ScoreControlSample>();
        sm.AddScore(0);
        if (player_position != null )
        {
            StartCoroutine(GotoPlayer());//�÷��̾� �������� ���� �ƴ� ���, GotoPlayer��� �ڷ�ƾ�� �����ϰ� ��
        }
        else
        {
            Debug.Log("Player�� ã�ƾ߰ھ�!");
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
                Debug.Log("����??");
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
            // ���� �ø���
            
            if (sm != null)
            {
                sm.AddScore(scoreValue);
            }
            gameObject.SetActive(false);
        }
            
    }
}