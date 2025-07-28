using UnityEngine;

//오브젝트 캐싱에 대하여(Object cashing)
//캐시(Cashe) - 자주 사용되는 데이터나 값을 미리 복사해두는 임시 장소

//캐시 사용 의도
//1. 시간 지역성 : 가장 최근에 사용된 값이 다시 사용될 가능성이 높다.
//2. 공간 지역성 : 최근에 접근한 주소와 인접한 주소의 변수가 사용될 가능성이 높음.

public class Sample03 : MonoBehaviour
{ 
    Rigidbody rb;
    Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //캐싱(cashing) : 임시 저장 데이터를 만들어놓는 행위
        //변수로 저장해놔 매번 불러오는 수고를 던다
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(pos * 5);
        //∧ 프레임마다 호출, 매 프레임마다 GetComponent로 정보를 가져오니 그만큼 성능 저하
        //일시적으로 한번만 불러올 때는 사용 ㅇㅋ(웬만하면 update에서 사용 x)
    }
}
