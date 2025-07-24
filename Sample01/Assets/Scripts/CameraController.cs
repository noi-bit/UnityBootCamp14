using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;//gameobject�� ��Ȯ�� �������� �ν����Ϳ��� ����
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ī�޶�� �÷��̾� �Ÿ� ���̸� offset������ ����.
        offset = transform.position - player.transform.position;//���� ���� - �÷��̾�(����)�� ��ġ
    }

    // Update is called once per frame, ������ ���� ȣ��Ǵ� ��ġ
   
    private void LateUpdate()//update���� ó���� �κ��� ó���� �Ŀ� ȣ��Ǵ� ��ġ
    //ī�޶� �۾����� ���� ����(������Ʈ ������ ������ ���)
    {
        //ī�޶��� ��ġ�� �÷��̾���� ���� �Ÿ��� �����Ѵ�(offset)
        transform.position = player.transform.position + offset;
    }
}
