using UnityEngine;
//��ư�� OnClick�� ����� ���

public class SkeletonController : MonoBehaviour
{
    public ScoreText st;
    private int a = 0;
    public GameObject skeleton;//���̷��� ������Ʈ�� ����� �巡���ؼ� �����Ҽ�����
    /* public void �޼ҵ��()
      {
           �� �޼ҵ带 ������ ��� ������ ��ɹ��� �ۼ��ϴ� ��ġ
      }*/
    private void Start()
    {
        st = GetComponent<ScoreText>();
    }
    public void LButtonEnter()//�ۿ��� �����ϱ� public, void - ��ɸ� �����ϰ������(�Ϲ� �ڷ���)
    {
        skeleton.transform.Translate(1, 0, 0);//transform.Translate(-1,0,0)�׳� �̴�� �ϸ� ��ư�� �����δ�
    }

    public void RButtonEnter()
    {
        skeleton.transform.Translate(-1, 0, 0);//��ư�� ������ ���� skeleton�� �Էµ� ������Ʈ�� ��ǥ��� �����δ�
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            a = 0;
            st.text.text = "Score : " + a;
        }

    }
}
