using UnityEngine;
//�÷��̾�� ���� ����?
//�÷��̾� : ����ڰ� ��Ʈ�� ����
//�� : ������ ��ɿ� ���� �ڵ����� ������

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public enum EnemyType
    {
        Down, Chase
    }
    public EnemyType type = EnemyType.Down; //�⺻�����δ� �Ʒ��� �������� �����Ӹ�
    Vector3 dir;//���⼳��

    private void Start() //���� ������ ����
    {
        //�Լ� �и�
        //���� : 1. ���� ����(������ ������) 2. ���뼺�� ������ �� ����(���� ���� ����, ����� ���� ���� ���� ��)
        PatternSetting();
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    void PatternSetting()
    {
        int rand = Random.Range(0, 10); //0 ~ 9 ������ �� �� �ϳ��� ���� �������� 
        if (rand < 3) // 0,1,2(Ȯ�� 30%)
        {
            //�÷��̾� ���󰡴� ���
            type = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position; // ���� = Ÿ�� ��ġ - ���� ��ġ
            dir.Normalize(); //������ ũ�⸦ 1�� ����(�ݿø�?����)
        }
        else
        {
            //�Ʒ��� �������� ���
            type = EnemyType.Down;
            dir = Vector3.down;
        }
    }

    //OnCollisionEnter : �浹 �߻� �� 1�� ȣ��
    //OnCollisionStay : �浹 �����ϴ� ���� ȣ��
    //OnCollisionExit : �浹 �߻� �� �浹 �۾����� ��� ��� 1�� ȣ��

    //OnTriggerXXX�� ���� ���� ������ ������ ������ �ִ�.
    //2D�� ��� - OnCollisionEnter2Dó�� �������� 2D�� ����ؾ� ��

    //�Ϲ����� ������ �浹 Collision
    //Is Trigger üũ�� ����� ������Ʈ���� Ʈ���� �浹��? onTriggerEnter(�浹 "����"�� üũ)
    private void OnCollisionEnter(Collision collision)
    {
        //�浹 �̺�Ʈ �߻�
        //������Ʈ���� �������� �浹 �߻� �� ȣ��
        //���� �ϳ��� Rigidbody�� ������ �־�� ó����
        Destroy(collision.gameObject); //���� �ı�(�Ѿ�)
        Destroy(gameObject); //�ڽ� �ı�
    }

}
