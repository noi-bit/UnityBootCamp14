using UnityEngine;

// �÷��̾ 45�� �������� �����ϰ� �ϴ� �ڵ�

public class AngleMove : MonoBehaviour
{
    [SerializeField] float angle_degree; //����(��)
    [SerializeField] float speed;        //�ӵ�(�����϶� ����� ��ġ)

    void tan()
    {
        var radian = Mathf.Deg2Rad * angle_degree;
        Mathf.Tan(radian);
        transform.position = new Vector3 (radian, 0, 0);
    }
    void Update()
    {
        //var radian = Mathf.Deg2Rad * angle_degree;
        //Vector3 pos = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian));

        //transform.Translate(pos * speed * Time.deltaTime);
        ////=transform.position = new Vector3(x, y, 0); �� ������ ����

        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    transform.position = Vector3.zero;
        //}
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            tan();
        }
    }
}
