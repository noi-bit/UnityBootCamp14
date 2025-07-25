using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectPrefab;

    float spawnTime = 2.0f;//2�ʴ� ����
    float time = 0.0f;//�ð� üũ�� ����

    /*�ð��� ���� ����ؼ� ������ �����ϰ�, �� ������ ���� Ÿ�Ӻ��� Ŀ����
    ������Ʈ ���� & ������ 0���� �ʱ�ȭ*/

    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime;
        if(time>spawnTime)
        {
            GameObject go = Instantiate(ObjectPrefab);/*���� �޼ҵ�, go�����ν� ������Ʈ�� ������ 
                                                        ���� �����Ǵ� ������Ʈ���� ������ ������ �� �ִ�*/
            time = 0.0f;

            int rand = Random.Range(-3, 4); //-3���� 3 ������ ���� �������� ������ ��
            go.transform.position = new Vector3(rand, 5, 5.033f);
            
        }
    }
}
