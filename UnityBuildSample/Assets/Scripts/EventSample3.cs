using UnityEngine;
using UnityEngine.Events;
//UnityEngine.Events 네임스페이스 연결이 필수

//c#의 evnet와의 차이점
//1. 인스펙터에서 확인이 가능하다
//2. 추가 제거 기능을 +=, -=로 하지 않고, AddListener/RemoveListener로 진행합니다.

//                     UnityAction              vs              UnityEvent
//      타입              delegate                                class
//      기능              함수참조                        에디터에서 핸들러 직접 등록가능
//      구독              +=, -=                          AddListern(), RemoveListener()
//   사용할 상황       스크립트 코드 내 처리                  인스펙터용 이벤트 시스템
//      속도                빠름                              느림(연결 정보에 대한 파싱 후 런타임 실행 방식)
//     메모리               적음                                    많음
//   GC발생 여부            낮음                                    높음
//      편의성         자체 설계 필요                         바로 사용 가능(쉽고편함)

//          ※UnityAction 은 UnityEvent를 사용하는 코드를 설계할 때 효과적임
//※일반 delegate는 UnityAction<T>와 같이 타입에 대한 설정이 안되어있어 따로 만들어서 사용해야 함

//※유니티 작업 시 사용할 수 있는 delegate 형태 데이터 선택지
//  1. c# delegate
//  2. Unity UnityAction
//  3. c# Func<T>, Action<T>

public class EventSample3 : MonoBehaviour
{
    public UnityEvent OnKButtonEnter;
    public UnityAction OnAction;

    private void Start()
    {
        //OnKButtonEnter += Sample; 오류남
        OnKButtonEnter.AddListener(Sample); //이런식으로 추가해줘야..
        //.AddListener(UnityAction call) 형태임 결국 Sample은 UnityAction
        OnAction += Sample;//OnAction은 델리게이트라서 +=로 추가 가능
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            OnKButtonEnter?.Invoke();
        }
        //TestSelf1에서 사용하려면 if(버튼을 누르면?) 유니티이벤트 랜덤아이템출력?.Invoke(); 스타트에서는 랜덤아이템출력.AddListener(랜덤아이템텍스트출력)
    }

    public void Sample()
    {
        Debug.Log("<color=cyan>실행!</color>");
    }

    public void Sample2()
    {
        Debug.Log("<color=green>Sample2 실행!</color>");
    }
}
