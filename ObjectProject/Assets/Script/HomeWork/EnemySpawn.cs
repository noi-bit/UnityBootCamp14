using System.Collections;
using UnityEngine;
//����-1 ��ũ��Ʈ
//EnemyMoveAI��ũ��Ʈ�� �ް��ִ� ������Ʈ�� ����

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemyprefab;//Enemy �������� �巡�׵�� ����
    public Transform spawnPoint;//��ũ��Ʈ�� �޷��ִ� ������Ʈ�� ��ġ�� �巡�׵��
    public float interval = 5.0f;//���� ���� �ð� ����
    private Transform bullet;

    void Start()
    {
        StartCoroutine(Spawn());        
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(Enemyprefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);//interval Ÿ�� ��ŭ ���

            Debug.Log($"{spawnPoint.position}���� {Enemyprefab.name}������ �����Ǿ����ϴ�.");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        bullet = GameObject.FindGameObjectWithTag("Bullet")?.transform;//�Ѿ��� ������
        float bulletenter = Vector3.Distance(transform.position, bullet.position);

        if (bulletenter <= 0)
        {
             
        }
    }
}
