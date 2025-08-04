using System.Collections;
using UnityEngine;
//4번째 스크립트

public class CoroutineSample : MonoBehaviour
{
    // 적용할 타겟
    public GameObject target;

    // 변화 시간
    float duration = 5f;

    // 변화할 색
    public Color color;

    void Start()
    {
        // 타겟이 설정되어있다면
        if(target != null)
        {
            StartCoroutine(ChangeColor());
            // 1. StartCoroutine(메소드명()); : IEnumerator 형태의 메소드를 코루틴으로 시작
            // 코드작성 과정에서 메소드가 결정되어 안전함
            //  ㄴ> 메소드 호출은 컴파일 과정에서 확인되기에 찾아 실행하는 시간이 문자열보다 적게 든다

            // 2. StartCoroutine("ChangeColor"); , StartCoroutine("메소드명");
            // 문자열을 통해 매개변수가 없는 코루틴을 호출할 수 있다
            // 내부적으로 메소드의 이름을 문자열로 전달 후, 런타임에서 찾아서 실행하는 방식(리플렉션)
            //  ㄴ> 타입 체크를 하지 않아 잘못된 이름을 쓰면 런타임 오류 발생
        }
        else
        {
            Debug.Log("현재 타겟이 등록되지 않은 상태입니다");
        }
    }

    IEnumerator ChangeColor() 
    {
        // Coroutine = StartCoroutine(ChangeColor());
        // StopCoroutine(coroutine);
        // StopCoroutine("ChangeColor"); -- 매개변수가 있는 함수면 사용할수 없는 방식
        // StopAllCoroutines(); -- 모든 코루틴에 대한 정지(현재 게임오브젝트에서 실행중인)

        // 타겟으로부터 렌더러 컴포넌트에 대한 값을 얻어옴
        var targetRenderer = target.GetComponent<Renderer>();

        if (targetRenderer == null)// 조사한 타겟의 렌더러가 없을 경우
        {
            Debug.LogWarning("렌더러를 얻어오지 못했습니다.(NULL)");
            yield break;// 작업 중단 
        } // targetRenderer 가 null 이 아닐경우..(위에 yield break로 Null 시 중단하기 때문)

        float time = 0.0f;

        var start = targetRenderer.material.color;// 타겟의 렌더러가 가진 머티리얼의 색을 사용
        var end = color;

        // 반복작업
        // 코루틴 내에서 반복문을 설계하면, yield에 의해 빠져나갔다가 다시 돌아와서 반복문을 실행하게 됨
        while(time< duration)
        {
            time += Time.deltaTime;
            var value = Mathf.PingPong(time, duration) / duration;
            // Mathf.PingPong(a,b)
            // 주어진 값을 a와 b사이에서 반복하는 값을 생성(기본적인 왕복 운동)
            // 약 0에서 1까지의 변화 값이 계산됩니다
            // 정규화 작업을 진행하는 이유 : color는 0부터 1까지의 값이기 때문

            targetRenderer.material.color = Color.Lerp(start, end, value);// 색상에 대한 부드러운 변경

            yield return null; // null이지만 yield에 적용하면 다음 프레임까지 대기 한다는 의미
                               // 다음 프레임에 다시 while이 실행됨(time<duration 동안)
            //yield return new WaitForSeconds(1f);// - 1초마다 yield를 호출시킴
            Debug.Log("한 프레임이 끝났어요");
        }
    }
    // 코루틴 : 정지 기능
    // StopCoroutine(코루틴 객체);
}
