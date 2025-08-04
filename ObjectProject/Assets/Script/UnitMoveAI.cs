using System.Collections;
using UnityEngine;
//5-1��° ��ũ��Ʈ

public class UnitMoveAI : MonoBehaviour
{
    public float speed = 1.0f; //�̵� �ӵ�
    public float detection = 7.0f; //�˻� ����

    private Transform player_position; //�÷��̾��� ������


    void Start()
    {
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        //(? ������ Ȱ��) : ��ü�� null �� �� �߻��� ���� ����
        //                  ��> int? a = null;
        //GameObject.FindGameObjectWithTag("Player")?.transform�� ���� �ۼ��� �ϸ� �ش� ����
        //Nullable Ÿ������ �����մϴ�


        if(player_position !=null)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.Log("�÷��̾ ã�� �� �����ϴ�.");
        }
    }

    IEnumerator Move()
    {
        while (player_position != null)
        {
            float distance = Vector3.Distance(transform.position, player_position.position);

            //�÷��̾ ������ �Ÿ� ���� �ִٸ�?
            if(distance <= detection)
            {
                //Vector3 dir = (player_position.position - transform.position).normalized;//normalize = ����ȭ
                transform.position = Vector3.MoveTowards(transform.position, player_position.position, speed*Time.deltaTime);
            }
            //�Ÿ� ���� ������ �� �ൿ ȣ��
            else
            {
                Debug.Log("�� ���� ���� ����..");
            }
        yield return null;
        }
    }
}
