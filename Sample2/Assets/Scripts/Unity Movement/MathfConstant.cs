using UnityEngine;
//Mathf 클래스에서 제공해주는 상수 값

public class MathfConstant : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Mathf.PI);                // 원주율 3.14159...
        Debug.Log(Mathf.Infinity);          // 무한대
        // └> 수학적 연산에 의해서 표현할 수 있는 최대의 수를 넘는 경우에 자동으로 처리되는 값
        // 직접적으로 Infinity를 작성해 명시적으로 무한대를 표현하기도 함
        // 1. Pow(0,-2) = 0^-2 = 1/(0^2) = 1/0 = 계산불가 -> Infinity
        // 2. float 범위로 표현할 수 없는 큰 수를 제곱하는 경우, 결과일 경우
        //      └> (+- 3.4 * 10^38)를 넘어서 오버플로우 현상이 발생했을 경우 -> Infinity
        //※float 의 최대 값 == float.MaxValue (이걸 넘으면 -> Infinity)

        Debug.Log(Mathf.NegativeInfinity);  // 음의 무한대
        // 1. 음수에 대한 지수 연산이 오버플로우 되는 경우
        // 2. 직접적으로 NegativeInfinity 가 명시되는 경우
                                            // 음의 무한대는 어떤 숫자도 될 수 없는
                                            // 음의 방향을 가리키는 개념
                                            // (결코 0에 도달할 수 없는 0에 가까운 것)(음의 최전선)

        Debug.Log(Mathf.Sqrt(-1));
        // = NaN(Not a Number) : 수학적으로 정의되지 않은 계산 결과일 경우 나오는 값
        // ※ NaN에 대하여
        // 1. 두 값이 NaN일 경우 그 값에 대한 비교는 불가능하다(같은지 체크하면 false나옴)
        //     └> float.IsNaN(값)을 통해 해당 값이 NaN인지만 확인이 가능
        // 2. Infinity - Infinity = NaN
        //  2-1. 0/0 과 같이 수학적으로 말이 안되는 값(직접 넣으면 작동하지 않지만 함수에 넣거나 하는식으로 결과가 나올수 있다)
        //  2-2. 음수에 대한 루트 계산(허수나 복소수 같은 개념은 사용자가 따로 설계한 기능으로 수행해야 함)
        //     └> 유니티에서 허수에 대한 직접적인 지원은 X
        //          수학적으로 간단 표현 : 허수 -> 음의 제곱근 ex) Sqrt(-1);
        //                                    -> 복소수 + a + bi 형태로 표현
        //     └> ※ C#에서는 -- System.Numerics.Complex 기능을 통한 허수의 계산 가능
        //        using System.Bumerics;
        //        Complex c = Complex.Sqrt(-1);
        //        단점) 유니티 빌드 기준에 따라 사용이 제한되는 경우가 있습니다(ex. WebGL)


        // --오브젝트의 position이 만약 NaN이다? 필드에서 걍 사라짐
        // --Rigidbody 에서 사용하는 값 중 velocity(속력) 이 NaN이라면? --> 물리 엔진 작용에 대한 고장 
        // --Quaternion(회전)에서 사용하는 값이 NaN이면? --> 회전이 끊기거나 깨지는 현상/ 정상적인 회전X

        // ※ NaN에 대한 방어 코드 작성 시 활용
        // Vector3 pos = transform.position;
        // if(float.IsNaN(pos.x))
        // {
        //     Debug.LogWarning("현재 위치에서 NaN 발견, 원점으로 이동합니다.");
        //     pos = Vector3.zero;
        // }
        // 이런식으로 벡터계산이 오류날 상황을 고려해서 사용할 수 있음

        // 그 이외의 값
        // 1. Mathf.Deg2Rad() : Degree(각도)(DegtoRad) - 각도를 라디안으로 바꿔주는 코드(라디안 값)
        //                      └> Transform.Rotate(0,90,0) -> y축으로 90도만큼 회전
        //                         transform.eulerAngles -> 트랜스폼에서의 (x,y,z) 각도 표현(도)
        //                         Quaternion.AnglerAxis(45f, Vector3.up) -> 45도 만큼 회전
        //                         Vector3.Angle(A,B); -> A 벡터와 B 벡터 사이의 각도(도)
        //                         Quaternion.Angle(A,B) -> 두 회전간의 차이를 각도(도)
        //                         유니티 인스펙터에서 보여지는 회전 입력 -> 각도로 계산
        //                         유니티의 애니메이션에서 사용하는 회전 속성 -> 각도

        // 2. Mathf.Rad2Deg() : Radian(수학적으로 사용되는 각도의 단위)(RadtoDeg) - 라디안을 각도로 바꿔주는 코드(디그리 값)
        // ※ 수학적인 계산이 필요한 경우 Radian으로 거의 사용한다(유니티에서는 대부분 Degree)
        //                      └> 반지름과 같은 길이를 가진 호가 가진 중심각 = 1라디안(약 57도.., 약 60도)
        //                         유니티에서 제공해주는 삼각함수 계산에서는 각도 대신 라디안을 요구함

        // 유니티에서는 저 두 기능을 통해 라디안 -> 도/ 도-> 라디안으로의 변환을 처리함
        // ※ 결론 ) 라디안은 원의 길이, 각속도, 미분 등의 작업을 진행할 때(수학/물리 작업) 계산이 더 간단하게 진행되고
        //       따라서 유니티 등에서 사용되는 삼각 함수와 같은 계산식에서 사용됨

        // ※ 요약 ) degree : 직접적인 회전에 대한 표현(입력, 보여지는 각)
        //          Radian : 삼각함수를 활용한 각 계산
        
        // 자주 사용되는 (각)도와 라디안의 값
        // 0        0       0
        // 90      PI/2     90
        // 180      PI      180
        // 360     2PI      360

        // 3. Mathf.Epsilon   : float형에서 0이 아닌 가장 작은 양수(0에 가장 가까운 값)
        //                      └> 미세한 값을 다룰 때 사용
        //                          float 에서 0f보다 Epsilon으로 0을 체크하면 보다 안전하게 계산됨
        //                          0으로 나누는 상황을 방지합니다
    }


}
