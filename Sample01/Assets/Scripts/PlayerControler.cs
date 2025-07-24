using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    private Rigidbody rb; //rigidbody클래스

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();//컴포넌트의 값을 가져온다(해당기능을 가져온다) - <Rigidbody>
        //GetComponent<T>(); -게임 오브젝트에 붙어있는 컴포넌트를 가져오는 기능./ T : Type
        Debug.Log("설정이 완료되었습니다!^^");//Deletebug - 버그 검사, 해결 / Log - 작업내역
    }

    // Update is called once per frame, 프레임마다의 동작
    void Update()
    {
        //speed += 1;
        //Debug.Log($"속도가 1 증가합니다. 현재 속도는 {speed} 입니다.");
        
        //Axis : 유니티 고유의 세계관?
        float horizontal = Input.GetAxis("Horizontal");//왼쪽 오른쪽 
        float vertical = Input.GetAxis("Vertical");//앞 뒤

        //이동좌표(벡터) 설정
        Vector3 movement = new Vector3(horizontal,0,vertical);//(x좌우,y위아래,z앞뒤)동적 정보, new 만든 순간부터 생성되는거라 start에서 작성이 안되기 때문에 용량 절감

        rb.AddForce(movement * speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌체의 게임 오브젝트의 태그가 Item Box라면?
        if(other.gameObject.CompareTag("Item Box"))
        {
            Debug.Log("아이템 획득!");
            //충돌체(other - Item Box)게임오브젝트를 비활성화합니다.
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("속도가 50% 감소합니다.");
            speed /= 2;
            other.gameObject.SetActive(false);
        }
    }

}
