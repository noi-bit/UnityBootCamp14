using System.Collections;
using UnityEngine;
// 3 번째 스크립트

public class IEnumeratorSample : MonoBehaviour
{
    class CustomCollection : IEnumerable
    {
        int[] numbers = { 6, 7, 8, 9, 10 };

        // GetEnumerator를 통해 순회 가능한 데이터를 IEnumerator 형태의 객체로 변환
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i<numbers.Length; i++)
            {
                yield return numbers[i];
            }
        }
    }
    
    int[] numbers = {1,2,3,4,5}; // 그냥 시작할때 묶음형 데이터를 만들어 Enumerator를 통해주면 그 기능으로 바꿔줌?

    void Start()
    {
        // numbers 라는 배열을 순회할 수 있는 IEnumerator 형태의 데이터로 변환
        IEnumerator enumerator = numbers.GetEnumerator();

        while(enumerator.MoveNext()) // 다음 값이 있을동안 반복, 없다면 멈춤
        {
            Debug.Log(enumerator.Current); // Current : 현재 순회하고있는 데이터에 대한 정보
        }

        CustomCollection collection = new CustomCollection(); // 커스텀 컬렉션 생성

        // foreach는 순환 가능한 데이터를 순차적으로 작업할 때 사용하는 for문 - 보기 간결해짐
        foreach(int number in collection)
        {
            Debug.Log(number);
        }

        IEnumerator enumerator1 = numbers.GetEnumerator();

        foreach (var data in GetMessage())
        {
            Debug.Log(data.ToString());
        }
    }

    // yield는 C#에서 한번에 하나씩 값을 넘기고, 메소드가 일시정지 되며 후속 값들을 
    // 지속적으로 반환하게 함 - 반복적인 작업, 순차적인 데이터 처리에 사용됨

    // yield 는 yield return; , yield break; 로 사용됨
    
    // yield return은 메소드가 값을 반환하면서 그 지점에서 메소드 실행을 일시중지 시킴
    // --> 호출자가 다음 값을 요구할 때까지 대기함

    // yield break는 메소드에서의 반복을 종료하는 코드 - 완벽하게 실행이 종료됨

    // yield return을 사용하는 메소드-- IEnumerable , IEnumerator 인터페이스를 구현하게 됨
    // 컬렉션을 자동으로 순회하는 foreach(혹은 while)와 자주 사용됨

    // -- IEnumerable : 반복가능한 컬렉션을 나타내는 인터페이스
    // (반복가능 나타냄) 이 기능을 구현한 클래스는 반복할 수 있는 객체가 되며, 
    //                  foreach 등에서 순차적인 탐색을 진행할 수 있게 됨
    //                  해당 인터페이스를 구현하기 위해서는 GetEnumerator() 메소드를 제공하고,
    //                  사용자가 구현해야 함

    // -- IEnumerator : 반복을 관리하는 인터페이스
    //    (반복 관리)    컬렉션에서 하나씩 항목들을 반환하고, 그 상태를 관리하는 역할을 수행함
    //                  MoveNext()를 통해서 다음 값에 접근, Current를 통해서 현재 값 확인
    //                  Reset()을 통해서 리셋 기능 처리

    // 장점 : 값을 필요로 할 때까지 계산을 미루는 방식(메모리 효율이 좋음, 큰 데이터를 처리하기 용이)
    //        ㄴ> 모든 데이터를 저장하는게 아닌 필요한 부분만 처리할 수 있게되기 때문
    static IEnumerable GetMessage()
    {
        Debug.Log("메소드 시작!");
        yield return "야아아아"; // 야아아아 를 내보내고, 다시 해당 메소드로 돌아옵니다
        Debug.Log("탈출 했다가 돌아옴 1");
        yield return "호";
        Debug.Log("탈출 했다가 돌아옴 2");
        yield break; // 순환 작업 종료

        //-----Unreachable Code -----(접근 불가 - 이미 break로 순환 종료)
        //Debug.Log("탈출 했다가 돌아옴 3");
        //yield return "!!!";
    }
}
