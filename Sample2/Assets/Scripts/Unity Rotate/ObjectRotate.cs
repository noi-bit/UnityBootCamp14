using UnityEngine;
// 유니티의 회전(Rotate)
// 1. 오일러 각(Euler Angle)에 의한 회전 - x,y,z 회전 값
//    ㄴ> 유니티 인스펙터에서의 Transform 컴포넌트의 Rotation에 표기된 값(각도 기준)
//        ex) Rotation x 120, y 45, z 0 --> x축으로 120도 y축으로 43도 회전되었음을 의미함

// 2. 쿼터니언(Quaternion) - 회전을 계산하기에 안정적이고 수학적인 방식을 가진 값
//    ㄴ> 유니티 엔진 내부에서 실제로 저장되고 계산되는 값
//        (쿼터니언으로 유니티 내부에서 계산하고 오일러 각으로 표시)

// 쿼터니언으로 처리하는 이유?
// ㄴ> 유니티에서 쿼터->오일러 각 변환 시 360도 이상의 회전은 보정될 수 있음
//      ex) 380도 -> 20도 회전으로 바뀔수 있다

// 짐벌 락 현상(Gimbal Lock) : 오일러 각을 이용해 회전을 표현하는 경우 발생하는 회전 자유도의 손실
// ㄴ> 어떤 축이 다른 축과 정렬되는 순간, 한 축의 회전이 무효되면서 회전 방향이 3개에서 2개만 남는 현상

// 쿼터니언의 구조
// ㄴ> 4차원 복소수 (x,y,z,w(스칼라)) - 하나의 벡터(x,y,z), 하나의 스칼라 w
// 쿼터니언도 벡터처럼 방향인 동시에 회전의 개념을 가지고 있다(벡터는 위치이면서 방향의 개념)
// 세 축을 동시에 회전시켜 짐벌 락 현상이 발생하지 않도록 구성되어 있음(x,y,z는 항상 동시에 변화한다)
// 쿼터니언은 회전의 원점과 방향을 비교해 회전을 측정할 수 있다
// orientation : 방향

// 단점 : 180도 이상의 표현 불가
//        직관적으로 바로 이해하기 어려운 구조 - 그래서 계산에는 쿼터니언, 값으로는 오일러 각을 사용

// 오브젝트에 대한 회전 기능 스크립트
public class ObjectRotate : MonoBehaviour
{
    
    void Update()
    {
        #region //Rotate() 종류
        //transform.Rotate() - 회전을 진행시키는 가장 기본적인 코드
        //transform.Rotate(Vector3 eulerAngles); - 지정한 축을 기준으로 회전
        //transform.Rotate(float x, float y, float z); - 로컬(게임 오브젝트) 기준의 회전
        //transform.Rotate(Vector3 axis, float angle); - 특정 축을 중심으로 회전
        //transform.Rotate(Vector3 axis, float angle, Space space); - 월드 또는 로컬 중에 선택
        //ex) transform.Rotate(Vector3.forward, 60f * Time.deltaTime, Space.World);
        //     ㄴ> 월드 기준으로 z축으로 60도만큼 회전해라
        #endregion
        //게임오브젝트를 기준으로 회전 진행
        //ㄴ>transform.Rotate(new Vector3(20,20,20) * Time.deltaTime);
        //transform.Rotate(20, 20, 20)

        //절대좌표를 기준으로 회전 진행
        transform.Rotate(new Vector3(20,20,20) * Time.deltaTime, Space.World);
    }
}
