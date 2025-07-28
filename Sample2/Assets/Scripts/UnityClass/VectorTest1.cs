using Unity.VisualScripting;
using UnityEngine;

public class VectorTest1 : MonoBehaviour
{
    //���� ������Ʈ�� Transform �� �̿��� Vector�� ���ϱ�
    public Transform A_CUBE;
    public Transform B_CUBE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���� ť���� ��ġ��( A_CUBE.position) ���ͷ�(Vector3 posA) �����մϴ�.
        Vector3 posA = A_CUBE.position;
        Vector3 posB = B_CUBE.position;
    
        //�� ������ �� => ���� ����
        Vector3 BtoA = posB - posA;
        Vector3 AtoB = posA - posB;

        //�Ÿ� ����
        //Distance�� ������ ����
        //a = (ax, ay, az)
        //b = (bx, by, bz)��� �� ��,
        // �� ���� ������ �Ÿ��� �� �࿡ ���� ���� ������ �տ� ���� ��Ʈ ��
        // ��((bx-ax)^2 + (by-ay)^2 + (bz-az)^2) <--��Ʈ

        //����Ƽ�� Mathf Ŭ������ ������� �ٲٸ�?
        Vector3 dif = posB - posA;
        float distance = Mathf.Sqrt(dif.x * dif.x + dif.y * dif.y + dif.z * dif.z);
        Debug.Log(distance);

        distance = Vector3.Distance(posA, posB); //== ��((bx-ax)^2 + (by-ay)^2 + (bz-az)^2)
        Debug.Log(distance);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
