using UnityEngine;

//��ǥ : ���� �ð����� ���� ������ �� ��ġ�� ���� ��
//�ʿ��� ������ : ���� �ð�, ���� �ð�, �� ��������
//�۾� ���� : �ð�üũ - ����ð�>�ð�üũ �ð�(��Ÿ��) - �� ����
public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyFactory; //�� ��������
    public GameObject spawnArea; //���� ����(�迭)

    public float min =1, max =5; //��ȯ �ð� ����
    public float currentTime; //���� �ð�
    public float createTime = 1; //��Ÿ��

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime> createTime)
        {
            var enemy = Instantiate(EnemyFactory, spawnArea.transform.position, Quaternion.identity);
            //������ �Ŵ��� - �� ��ȯ ����(spawn area)�� ������ ������ ������,
            //���� ��ġ�� ȸ�� �� ���� X

            //������ ���� �����Ǿ� �ִٸ� ���� ��ġ�� �����Ѵ�.
            
            
            currentTime = 0; //����ð� ���� ������ �ٽ� ��Ÿ���� �Ѿ��(���ǹ� üũ) ���� ������ �� �ְ� �Ѵ�
            createTime = Random.Range(min,max); //��Ÿ���� 1~4�� ���� �ȴ�
        }
    }
}
