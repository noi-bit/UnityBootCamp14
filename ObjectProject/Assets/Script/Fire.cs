using UnityEngine;
//6-1��° ��ũ��Ʈ
//Ǯ���� ����Ϸ��� �ּ��� 3��
    //Ǯ ������� ��ũ��Ʈ
    //Ǯ ����� ��ũ��Ʈ
    //�߻��ϴ� ��ü�� ��ũ��Ʈ

//�� �ڵ�� �Ѿ˿� ���� �߻�(����) ��ɸ� ���
public class Fire : MonoBehaviour
{
    //�Ѿ� �߻縦 ���� Ǯ
    public BulletPool pool;

    //�Ѿ� �߻� ����
    public Transform pos;

    //�Ѿ� �߻� �ӵ�
    public float speed = 2f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = pool.GetBullet();
            bullet.transform.position = pos.position;
            bullet.transform.rotation = pos.rotation;
        }
    }

}
