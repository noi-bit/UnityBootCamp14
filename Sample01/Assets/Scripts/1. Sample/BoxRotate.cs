using UnityEngine;

public class BoxRotate : MonoBehaviour
{
    public Vector3 pos;

    private void Start()
    {
        pos = new Vector3(0, 40, 10);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(pos*Time.deltaTime);
        //��ŸŸ�� : ���� �����Ӻ��� ���� �����ӱ��� �ɸ� �ð�
        //update������ ���� ������ Ȱ��
        //�ش� ��ǥ��ŭ ���� ������Ʈ�� ȸ����ŵ�ϴ�(�� ��ũ��Ʈ�� ����Ǵ� ������Ʈ)
    }
}
