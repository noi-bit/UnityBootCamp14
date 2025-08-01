using UnityEngine;
// RayCast : 시작 위치에서 특정 방향으로 가상의 광선을 쐈을 때,
//          부딪히는 오브젝트가 있는지를 판단함
//  1. 특정 오브젝트를 충돌 범위에서 제외하는 작업 가능
//  2. 특정 오브젝트에 대한 충돌 판정을 확인하는 용도(총알같은..)

public class RayCastSample : MonoBehaviour
{
    RaycastHit hit; // 충돌 감지용 변수

    // ref : 변수를 참조로 전달, 변수가 메소드 안에서 변경될 수 있음을 알리는 용도
    // out : 변수를 참조로 전달, 변수 전달 전에 변수에 대한 초기화를 진행할 필요가 X

    // Physics.RayCast(Vector3 origin, Vector3 direction, out RayCastHit hitinfo,
    // float maxDistance, int layerMask);                 └>out: 변수를 참조로 전달되는것
    // 각 요소들은 쓸 수도, 안 쓸 수도 있음(오버로드)

    // origin의 방향에서 direction 방향으로 maxDistance 길이의 광선을 발사함
    // layerMask : tag보다 좀더 큰 거시적 범위의 분류(그룹에 대한 식별)
    // tag       : 개별 오브젝트 분류
    // hitinfo   : 충돌체에 대한 정보

    const float length = 20.0f; // 값에 대한 상수 (길이 변경 5 -> 20)

    private void Start() // 한번에 충돌 여러개 처리
    {
        #region //레이캐스트로 start시 한번에 모두 충돌하는 코드
        // 선 그리기
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        // 레이어마스크 설정하기
        int ignoreLayer = LayerMask.NameToLayer("Red");
        int layerMask = ~(1 << ignoreLayer);

        // 충돌체 설정
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, length, layerMask);

        // 반복문으로 콜라이더 체크
        for(int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.name + "를 했습니다.");
            hits[i].collider.gameObject.SetActive(false);
            // hits 배열의 i번째 값의 충돌체가 가진 게임 오브젝트를 비활성화합니다.
        }
        #endregion

    }
    //void Update()
    //{
    #region 맨 앞에 충돌하면 충돌 끝인 코드
    //    Debug.DrawRay(transform.position, transform.forward * length, Color.red);

    //    // 1. 충돌시키고 싶지 않은 레이어에 대한 변수 설정("Red"라는 이름을 가진 레이어를 가진 옵젝을 무시)
    //    int ignoreLayer = LayerMask.NameToLayer("Red"); // 충돌시키고 싶지 않은 레이어
    //    // 2. ~(1<<LayerMask.NameToLayer("Red")) - 해당 레이어("Red") "이외의" 값
    //    int layerMask = ~(1 << ignoreLayer); //비트반전
    //                                         // 우리가 지정한 레이어를 제외한 레이어들을 적용시킴

    //    //{// ex) 만약 Red 레이어와 Blue 레이어 둘 다 제외하고 싶은 경우?
    //    //int ignoreLayers = (1 << LayerMask.NameToLayer("Red")) | (1 << LayerMask.NameToLayer("BLUE"));
    //    //int layerMasks = ~ignoreLayers;
    //    //}

    //    // 마우스 좌클릭시 레이캐스트 발사
    //    //if (Input.GetMouseButtonDown(1))
    //    //{                 // Vector3 origin, Vector3 direction, out 충돌감지 변수, float maxDistance
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, length, layerMask))
    //    {
    //        Debug.Log("발사합니당!");
    //        Debug.Log(hit.collider.name);
    //        hit.collider.gameObject.SetActive(false); // 레이를 맞으면 맞은 오브젝트가 꺼짐

    //        // 레이어마스크는 비트 마스크이며, 각 비트는 하나의 레이어를 의미
    //        // 1<< n 은 n번째 레이어만 포함하는 마스크를 의미
    //        // "~" 에 의해 작성된 ~(1<<n) 은 해당 레이어 n 을 제외한 모든 레이어를 의미
    //    }
    //    //}
    //    // 오브젝트의 위치에서 정면으로 length만큼의 길이에 해당하는 디버깅 광선을 쏘는 코드
    //    // 주로 레이캐스트 작업에서 광선이 안보이기 때문에 보여주는 용도로 사용
    #endregion
    //}
}
