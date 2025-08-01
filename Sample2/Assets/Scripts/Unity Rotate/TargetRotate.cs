using UnityEngine;
// ��ǥ�������� ȸ����Ű�� �ڵ�

public class TargetRotate : MonoBehaviour
{ 
    public Transform target;

    public float speed = 90.0f; // �ʴ� ȸ�� �ӵ�(degree)


    void Update()
    {
        // Quaternion.LookRotation(Vector3 forward) : Ư�� ������ �ٶ󺸴� ȸ���� ����� �� ���
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Quaternion.RotateToward(��ġ, Ÿ�� ��ġ, �ӵ�);
        // ������ ȸ������ Ÿ���� ȸ������ ���� �ӵ��� �ε巴�� ȸ���� �����ϴ� �Լ�
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
        //                                              ���� ��ġ         ,Ÿ�� ��ġ      ,���ǵ�(90.0f)
    }
}

