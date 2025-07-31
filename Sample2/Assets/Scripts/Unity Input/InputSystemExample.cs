using UnityEngine;
using UnityEngine.InputSystem;

//Player Input�� �����ؾ� ����Ҽ� �ִ�

//RequireComponent(typeof(T))�� �� ��ũ��Ʈ�� ������Ʈ�� ����� ���,
//�ش� ������Ʈ�� �ݵ�� T�� ������ �־�� �Ѵ�.
//���� ����� �ڵ����� ������ְ�, �� �ڵ尡 �����ϴ� ��
//�����Ϳ��� ���� ������Ʈ�� �ش� ������Ʈ�� ������ �� �����ϴ�.
[RequireComponent(typeof(PlayerInput))]
public class InputSystemExample : MonoBehaviour
{
    //���� Action Map : Sample
    //         Action : Move
    //           Type : Value
    //         Compos : Vector2
    //        Binding : 2D Vector(WASD)
    private Vector2 moveInputValue;
    private float speed = 3.0f;

    //Send Message�� ���Ǵ� ���,
    //Ư�� Ű�� ������, Ư�� �Լ��� ȣ���մϴ�
    //�Լ����� On + Actions name, ���� ���� Actions �� �̸� Move���
    //�Լ����� OnMove�� �˴ϴ�.

    void OnMove(InputValue value)//InputSystem���� ���޹޴°� InputValue
    {
        moveInputValue = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y);
        transform.Translate(move*speed*Time.deltaTime,Space.World);//���� ��ǥ �������� ���� : ,Space.World
    }
}
