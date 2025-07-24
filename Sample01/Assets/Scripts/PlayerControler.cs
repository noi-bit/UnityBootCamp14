using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    private Rigidbody rb; //rigidbodyŬ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();//������Ʈ�� ���� �����´�(�ش����� �����´�) - <Rigidbody>
        //GetComponent<T>(); -���� ������Ʈ�� �پ��ִ� ������Ʈ�� �������� ���./ T : Type
        Debug.Log("������ �Ϸ�Ǿ����ϴ�!^^");//Deletebug - ���� �˻�, �ذ� / Log - �۾�����
    }

    // Update is called once per frame, �����Ӹ����� ����
    void Update()
    {
        //speed += 1;
        //Debug.Log($"�ӵ��� 1 �����մϴ�. ���� �ӵ��� {speed} �Դϴ�.");
        
        //Axis : ����Ƽ ������ �����?
        float horizontal = Input.GetAxis("Horizontal");//���� ������ 
        float vertical = Input.GetAxis("Vertical");//�� ��

        //�̵���ǥ(����) ����
        Vector3 movement = new Vector3(horizontal,0,vertical);//(x�¿�,y���Ʒ�,z�յ�)���� ����, new ���� �������� �����Ǵ°Ŷ� start���� �ۼ��� �ȵǱ� ������ �뷮 ����

        rb.AddForce(movement * speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�浹ü�� ���� ������Ʈ�� �±װ� Item Box���?
        if(other.gameObject.CompareTag("Item Box"))
        {
            Debug.Log("������ ȹ��!");
            //�浹ü(other - Item Box)���ӿ�����Ʈ�� ��Ȱ��ȭ�մϴ�.
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("�ӵ��� 50% �����մϴ�.");
            speed /= 2;
            other.gameObject.SetActive(false);
        }
    }

}
