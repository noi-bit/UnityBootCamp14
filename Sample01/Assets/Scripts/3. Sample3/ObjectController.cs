using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject player;
    public Text text;
    private static int score=0;//����

    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
        text.text = "Score :" + score;
    }

    void Update()
    {
        transform.Translate(0, -3f*Time.deltaTime, 0);

        //���Ϲ��� y���� -2���� �۴ٸ� ���Ϲ��� �ı��ϴ� �ڵ�
        if(transform.position.y < -2)
        {
            Destroy(gameObject);//��� ���ķ� ���������� �ı� 
        }
        
        //�浹 ���� ó��
        //���� ���� �浹 ���� ���� ���
        Vector3 v1 = transform.position;//���Ϲ��� Vector3 ����(���罺ũ��Ʈ�� ����Ǵ� ������Ʈ)
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2;//v1�� v2 ������ ��ġ

        float d = dir.magnitude;//������ ũ�� �Ǵ� ���̸� �ǹ��մϴ�(�� �� ������ �Ÿ��� ����� �� ����մϴ�)
        float obj_r = 0.5f;
        float obj_r2 = 1.0f;

        //�� �� ������ �Ÿ��� d�� ���� ������ �� ũ�ٸ� �浹���� �ʴ� ��Ȳ, ������ �۾����ٸ� �浹 
        if(d < obj_r +  obj_r2)
        {
            Destroy(gameObject);
        }

        
    }
}
