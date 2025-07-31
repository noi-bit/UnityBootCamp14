using UnityEngine;
using UnityEngine.Events;

public class UnityEventSample : MonoBehaviour
{
    //Tooltip은 인스펙터에서 필드 값에 마우스를 올렸을때 설명을 보여주는 기능
    [Tooltip("이벤트 리스트를 추가하고, 실행할 기능을 가진 게임 오브젝트를 등록하세요")]
    public UnityEvent action;

    private void Update()
    {
        action.Invoke(); // 액션에 등록된 함수를 실행합니다(인스펙터에서 어떤 함수를 등록할지 설정가능)
    }

    public void Rotate()
    {
        gameObject.transform.Rotate(1, 0, 0);
    }

    public int x;
    public void Move()
    {
    }
}
