using System.Collections.Generic;
using UnityEngine;
//6��° ��ũ��Ʈ
//������Ʈ Ǯ��(Object Pooling)
//  : ���� �����ǰ� �Ҹ�Ǵ� ������Ʈ�� �̸� ������ �����صΰ�
//    �ʿ��� �� Ȱ��ȭ�ϰ� ������� ���� �� ��Ȱ��ȭ �ϴ½����� ������ �����ϴ� ����� ���� ����

//������) ź��, ����Ʈ, ������ �ؽ�Ʈ, ���� ó�� ���� �����ǰ� ������� ������
//          �Ź� new, destroy�� ���� ���� ������ �߻��ϸ� GC�� ���� ȣ��ǰ�
//          �̴� ���� ���Ϸ� �̾����� �ֱ⿡ ���� ����� �������� ���

//EX) �߻� �Ѿ� �� 30��/ ������ ���� 20���� - �̷� �͵��� �̸� �ѹ��� �� ����
//    �Ⱦ��� ������ ��Ȱ��ȭ �س��´�

public class BulletPool : MonoBehaviour
{
    public GameObject bullet_prefab;
    public int size = 30;//�Ѿ� 30�� ����

    //Ǯ�� ���� ���Ǵ� �ڷᱸ��
    //1. ����Ʈ(List) : �����͸� ���������� �����ϰ�, �߰�, ������ �����ӱ� ������ ȿ����
    //2. ť(Queue) : �����Ͱ� ���� ������� �����Ͱ� ���������� ������ �ڷᱸ��
    private List<GameObject> pool;

    private void Start()
    {
        //�Ѿ� ����
        pool = new List<GameObject>();//pool -> public Gameobject bullet_prefab;���� �߰������� ������ ������Ʈ���� ����Ʈ
                                      
        for (int i = 0; i< size; i++)//size(����,30��)��ŭ..0,30 �̴� 30��
        {
            var bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = transform;//������ �Ѿ��� ���� ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����ν� ������

            bullet.SetActive(false);//��Ȱ��ȭ ����

            bullet.GetComponent<Bullet>().SetPool(this);//���� ������ �Ҹ��� Ǯ�� "����"��� ������

            pool.Add(bullet);//����Ʈ��.Add(��) -> ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }
    }

    public GameObject GetBullet()
    {
        //��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� ã�Ƽ� Ȱ��ȭ��
        foreach(var bullet in pool)
        {
            //1. ����â���� Ȱ��ȭ�� �ȵǾ��ִٸ�
            if(!bullet.activeInHierarchy)
            {
                //2. bullet�� Ȱ��ȭ ��Ų ��
                bullet.SetActive(true);
                //3. return �Ѵ�
                return bullet;
            }
        }
        //�Ѿ��� ������ ��쿡�� ���Ӱ� ���� ����Ʈ(pool)�� ���
        var new_bullet = Instantiate(bullet_prefab);
        new_bullet.transform.parent = transform;
        new_bullet.GetComponent<Bullet>().SetPool(this);
        pool.Add(new_bullet);
        return new_bullet;
    }
    
    public void Return(GameObject bullet)//�ݳ�
    {
        bullet.SetActive(false);
    }
}
