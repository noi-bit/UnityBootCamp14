using UnityEngine;

// 1. 이 스크립트를 사용하기 위해서는 Rigidbody 컴포넌트가 요구

[RequireComponent (typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    public float jp = 300f;
    public LayerMask ground; 

    private Rigidbody rb;
    //private bool isGrounded; - IsGrounded라는 메소드를 생성했기 때문에 사용하지않아도 ㅇㅋ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //키 입력
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        //방향 설계(이동 방향)
        Vector3 dir = new Vector3(x,0,z);;

        //이동 속도 설정(속력)
        Vector3 velocity = dir * speed;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        //리지드 바디의 속성
        //linearVelocity = 선형 속도(물체가 공간 상에서 이동하는 속도)
        //angularVelocity = 각 속도(물체가 회전하는 속도)

        //점프 기능 추가
        //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        //{
        //    rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
        //    //ForceMode.Impulse : 순간적인 힘
        //    //ForceMode.Force : 지속적인 힘
        //}
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
            //ForceMode.Impulse : 순간적인 힘
            //ForceMode.Force : 지속적인 힘
        }
    }

    private void FixedUpdate()
    {
        
    }

    private bool IsGrounded()
    {
        //아래 방향으로 1만큼 레이를 쏴서 레이어 체크
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }
}
