using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//6-2��° ��ũ��Ʈ

//�Ѿ˿� ���� ����, �Ѿ� �ݳ�, �Ѿ� �̵�
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;//�Ѿ� �̵� �ӵ�
    public float life_time = 2.0f;//�Ѿ� �ݳ� �ð�
    public GameObject effect_prefab;//����Ʈ ������

    //����������ϴ� ��
    private BulletPool pool;//Ǯ(�Ѿ��� ����� ��ġ)
    private Coroutine life_coroutine;
    private int EnemyLifecount;

    //Ǯ ����(Ǯ���� �ش� �� ȣ��)
    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }

    //Ȱ��ȭ �ܰ�
    private void OnEnable()
    {
        life_coroutine = StartCoroutine(BulletReturn());//�ڷ�ƾ �ۼ��� ������ ����(Enable,Disable)
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
        //�ε��� ����� Enemy �±׸� ������ �ִ� ������Ʈ�� ���
        //�������� �����ϴ�. �� ���� ������ ���� �ڵ� �ۼ�
        //EnemyLifecount = new EnemyMoveAI
        //����Ʈ ����(��ƼŬ)
        if (effect_prefab != null)
        {
            Instantiate(effect_prefab, transform.position, Quaternion.identity);
        }
        
        ReturnPool();
    }


    //�޼ҵ��� ����� ������ ���, => �� ����� �� �ִ�
    void ReturnPool() => pool.Return(gameObject);//pool�� ���� ������ nullreference�� �ȴ�
}
