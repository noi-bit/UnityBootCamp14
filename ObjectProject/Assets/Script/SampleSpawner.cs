using UnityEngine;
// 2��° ��ũ��Ʈ

public class SampleSpawner : MonoBehaviour
{
    // �ش� ������Ʈ�� ���� �� ������Ʈ�� ���� �����ϰ�, ������Ʈ�� �ο��Ѵ�
    void Start()
    {
        GameObject sample = GameObject.Find("Sample"); // sample ���ӿ�����Ʈ�� Sample �� ã�´�

        if(sample == null) // ������Ʈ Ž�� ����� ���� ���
        {
            GameObject go = new GameObject("Sample");
            go.AddComponent<Sample>();
        }
        else
        {
            Debug.Log("�̹� �����մϴ�.");
        }
    }

}
