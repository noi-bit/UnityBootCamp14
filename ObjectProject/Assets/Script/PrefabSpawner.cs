using UnityEngine;
// 8�� 4�� 1��° ��ũ��Ʈ

// 1. �������� ���� ����ϴ�
// 2. ������ ������Ʈ�� ���� ������ ���ο��� ������
// 3. ���� �Ŀ� �ı��� ���� ������ �ð��� ������

// �ش� ��ũ��Ʈ�� ���� ������Ʈ�� ����Ǹ�, ������ �����ϰ� - ���� �ð� �ڿ� �ı�ó��
// �� ����) �������� ����� �Ǿ�������, �ش� �۾� ����. �ƴ� ��� ���޼��� �ȳ�

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; //prefab�������� Assets�� �ֱ� ������ �巡�� ������� �ҷ����ų� ������������ ��
    private GameObject spawned; //prefab�� ���� �ҷ����� ������ ������Ʈ(������ ��ü�ʹ� �ٸ���)
    public float delay = 3.0f;

    void Start()
    {
        if(prefab != null)
        {
            spawned = Instantiate(prefab);
            // ���� �ڵ� Instantiate()
            // 1. Instantiate(prefab); - �ش� �������� ������ �°� ��ġ�� ȸ�� �� ���� �����ǰ� ����ȴ�
            // 2. Instantiate(prefab,transform.position,Quaternion.identity);
            //      ��> �ش� �������� �����ϰ�, ��ġ�� ȸ������ ������� ������Ʈ�� ��ġ�� ȸ�� ���� ����
            //          (��ġ�� ���ҰŸ� ȸ������ ���� �־���� �Ѵ� - Quaternion.identity�� ȸ���� �ʱ�ȭ)
            // 3. Instantiate(prefab,parent); - ������Ʈ�� �����ϰ�, �� ������Ʈ�� ������ ������Ʈ(��ġ)��
            //      ��> �ڽ����ν� ����մϴ�.
            // 4. Instantiate(prefab, position, quaternion, parent);
            
            spawned.name = "������ ������Ʈ"; // ������ ������Ʈ�� �̸��� �����ϴ� �ڵ�
            // spawned.AddComponent<Rigidbody>(); // �̸� ������ ������ ������Ʈ�� ������Ʈ�� �߰�
            Debug.Log(spawned.name + "�� �����Ǿ����ϴ�!");
            Destroy(spawned, delay); // delay �ð� ���� ������Ʈ �ı�
        }
        else
        {
            Debug.LogWarning("��ϵ� �������� �����ϴ�!");
        }
    }

}
