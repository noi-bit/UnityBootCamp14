using UnityEngine;
//중요 클래스 Mathf
//유니티에서 수학 관련 유틸리티 클래스
//게임 개발에서 사용될 수 있는 수학 연산에 대한 정적 메소드와 상수를 제공
//ex)정적 메소드 : static 키워드로 구성된 해당 메소드는 클래스명.메소드명()으로 사용이 가능
//:  Mathf.Abs(-5)


public class MathfSample : MonoBehaviour
{
    //기본적으로 사용되는 메소드
    float abs = -5;
    float ceil = 4.1f;
    float floor = 4.6f;
    float round = 4.5f;
    float clamp;
    float clamp01;
    float pow = 2;
    float sqrt = 4;

    void Start()
    {
        Debug.Log(Mathf.Abs(abs));              // 절댓값(absolute number)
        Debug.Log(Mathf.Ceil(ceil));            // 올림(소수점과 상관없이 값 올림처리), 소수점 사라짐(ceil, ceilint - float에서 int로 바꿔줌(어차피 소수점은 사라지기 때문에)
        Debug.Log(Mathf.Floor(floor));          // 내림(소수점과 상관없이 값 내림처리)  소수점 사라짐(floor, floorint)
        Debug.Log(Mathf.Round(round));          // 반올림(5 이하면 내리고 초과면 올림)  소수점 사라짐(round, roundint)
        Debug.Log(Mathf.Clamp(7, 0, 4));        // 현재 전달받은 값 = 7, 최소 = 0, 최대 = 4/ 결과 -> 4(한도치가 존재할 경우 계산값이 한도치를 초과하지않게 제한할 경우..(리미터 같은느낌?))
                                                //                  └ 값, 최소, 최대 순으로 값을 입력합니다 
        Debug.Log(Mathf.Clamp01(5));            // 현재 전달받은 값 = 5, 최소 = 0, 최대 = 1(자동 설정) --> 범위를 벗어나면 최솟값 0 또는 최댓값 1로 처리
                                                // 전달받은값이 1보다 크면 1, 1보다 작으면 0으로 처리됨
                                                // % 개념의 값을 처리할 때 자주 사용된다

                                                //=======Clamp vs Clamp01=======
                                                //Clamp   ==> 체력, 점수, 속도 등의 능력치 개념에서 범위 제한
                                                //Clamp01 ==> 비율(%), 보간 값(t), 알파 값(색상에서의 투명도)

        Debug.Log("제곱 :" + Mathf.Pow(pow, 2));                                               //값, 제곱 수(지수)를 전달받아 해당 수의 거듭제곱을 계산함
        Debug.Log("제곱근 :" + Mathf.Pow(pow, 0.5f));                                          //Mathf.Sqrt()로 계산하는 것보다 연산이 매우 느림(sqrt를 선호)
        Debug.Log("지수가 음수일 경우 값은 역수 형태로 계산합니다 :" + Mathf.Pow(pow, -2f));      //2의 -2 제곱 => 1/4
        Debug.Log(Mathf.Sqrt(sqrt));                                                          //값을 전달받아 해당 값의 제곱근을 계산함 => 4는 2의 제곱근 => 2 출력
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
