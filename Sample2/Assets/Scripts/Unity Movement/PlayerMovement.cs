using UnityEngine;

// 1. �� ��ũ��Ʈ�� ����ϱ� ���ؼ��� Rigidbody ������Ʈ�� �䱸

[RequireComponent (typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    public float jp = 300f;
    public LayerMask ground; 

    private Rigidbody rb;
    //private bool isGrounded; - IsGrounded��� �޼ҵ带 �����߱� ������ ��������ʾƵ� ����

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Ű �Է�
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        //���� ����(�̵� ����)
        Vector3 dir = new Vector3(x,0,z);;

        //�̵� �ӵ� ����(�ӷ�)
        Vector3 velocity = dir * speed;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        //������ �ٵ��� �Ӽ�
        //linearVelocity = ���� �ӵ�(��ü�� ���� �󿡼� �̵��ϴ� �ӵ�)
        //angularVelocity = �� �ӵ�(��ü�� ȸ���ϴ� �ӵ�)

        //���� ��� �߰�
        //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        //{
        //    rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
        //    //ForceMode.Impulse : �������� ��
        //    //ForceMode.Force : �������� ��
        //}
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
            //ForceMode.Impulse : �������� ��
            //ForceMode.Force : �������� ��
        }
    }

    private void FixedUpdate()
    {
        
    }

    private bool IsGrounded()
    {
        //�Ʒ� �������� 1��ŭ ���̸� ���� ���̾� üũ
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }
}
