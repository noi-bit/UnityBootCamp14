using System.Collections;
using UnityEngine;
//����-1 ��ũ��Ʈ
//EnemyMoveAI��ũ��Ʈ�� �ް��ִ� ������Ʈ�� ����

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemyprefab;//Enemy �������� �巡�׵�� ����
    public Transform spawnPoint;//��ũ��Ʈ�� �޷��ִ� ������Ʈ�� ��ġ�� �巡�׵��
    public float interval = 5.0f;//���� ���� �ð� ����
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
            yield return new WaitForSeconds(interval);//interval Ÿ�� ��ŭ ���
            //StopCoroutine(Spawn());
            Debug.Log($"{spawnPoint.position}���� {Enemyprefab.name}������ �����Ǿ����ϴ�.");
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

            Debug.Log("���� ����!");
            this.enabled = false; // Ÿ�̸� ��Ȱ��ȭ (1ȸ�� ����ǰ�)
        }
        //private void OnCollisionEnter(Collision collision)
        //{

        //    bullet = GameObject.FindGameObjectWithTag("Bullet")?.transform;//�Ѿ��� ������
        //    float bulletenter = Vector3.Distance(transform.position, bullet.position);

        //    if (bulletenter <= 0)
        //    {

        //    }
        //}
    }
}
