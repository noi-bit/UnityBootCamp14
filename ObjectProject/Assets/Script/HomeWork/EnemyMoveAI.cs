using UnityEngine;
using System.Collections;
//���� ��ũ��Ʈ

public class EnemyMoveAI : MonoBehaviour //enemy�� �����̴� ��ũ��Ʈ
{
    public float speed = 1.0f;//�̵��ӵ�
    public float detection = 7.0f;//�˻�����
    public float EnemyLife = 3;//Enemy�� ��� ����Ʈ (0�� �Ǹ� destroy)

    private Transform bullet;
    private Transform player_position;//�÷��̾��� ������

    void Start()
    {
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        //?�� ����ؼ� Player���� ���ų� �������� ���Ҷ� ���� ��� nullreference�� ǥ���ϰ� ��

        if(player_position != null )
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

    private void OnCollisionEnter(Collision collision)
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet")?.transform;//�Ѿ��� ������
        float bulletenter = Vector3.Distance(transform.position, bullet.position);

        if (bulletenter <=0)
        {
            
        }
    }
}
