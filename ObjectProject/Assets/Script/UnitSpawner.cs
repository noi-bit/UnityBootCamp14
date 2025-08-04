using UnityEngine;
using System.Collections;

//5��° ��ũ��Ʈ
//UnitMoveAI�� ������Ʈ�� �ް��ִ� ������Ʈ�� ������

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab; //����� �����ո� ������ �� �ְ� ��(���� ������)
    public Transform spawnPoint; //���������� �������(������ġ)
    public float interval = 5.0f; //���� ���� �ð� ����

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn()
    {
        while (true)//���ѻ���
        {
            //������ �����մϴ�
            //������ġ�� ��������Ʈ
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);

            //���� ���ݸ�ŭ ����մϴ�.
            yield return new WaitForSeconds(interval);

            //�ܼ� �޼��� ȣ��
            Debug.Log($"{spawnPoint.name}���� {unitPrefab.name} ������ �����Ǿ����ϴ�.");
        }
    }
}
