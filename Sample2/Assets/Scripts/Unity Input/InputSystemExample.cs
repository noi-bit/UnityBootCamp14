using UnityEngine;
using UnityEngine.InputSystem;

//Player Input이 존재해야 사용할수 있다

//RequireComponent(typeof(T))는 이 스크립트를 컴포넌트로 사용할 경우,
//해당 오브젝트는 반드시 T를 가지고 있어야 한다.
//없는 경우라면 자동으로 등록해주고, 이 코드가 존재하는 한
//에디터에서 게임 오브젝트의 해당 컴포넌트를 제거할 수 없습니다.
[RequireComponent(typeof(PlayerInput))]
public class InputSystemExample : MonoBehaviour
{
    //현재 Action Map : Sample
    //         Action : Move
    //           Type : Value
    //         Compos : Vector2
    //        Binding : 2D Vector(WASD)
    private Vector2 moveInputValue;
    private float speed = 3.0f;

    //Send Message로 사용되는 경우,
    //특정 키가 들어오면, 특정 함수를 호출합니다
    //함수명은 On + Actions name, 현재 만든 Actions 의 이름 Move라면
    //함수명은 OnMove가 됩니다.

    void OnMove(InputValue value)//InputSystem에서 전달받는값 InputValue
    {
        moveInputValue = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y);
        transform.Translate(move*speed*Time.deltaTime,Space.World);//월드 좌표 기준으로 설정 : ,Space.World
    }
}
