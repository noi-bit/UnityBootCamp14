using UnityEditor.ShaderGraph;
using UnityEngine;

public class LenamonMoveControl : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float turnSpeed = 360f;
    public float gravity = -20f;

    CharacterController _cc;
    Animator _anim;

    NewActions _controls;

    // 입력 캐시
    Vector2 _moveInput;
    bool _runHeld;

    // 중력 누적
    float _yVelocity;

    private void Awake()
    {
        _controls = new NewActions();

        _cc = GetComponent<CharacterController>(); 
        _anim = GetComponentInChildren<Animator>();

        _controls.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _moveInput = Vector2.zero;

        _controls.Player.Run.performed += ctx => _runHeld = true;
        _controls.Player.Run.canceled += ctx => _runHeld = false;
    }

    void OnEnable()
    {
        _controls.Enable(); // ★ 이거 안 하면 입력 0임
    }

    void OnDisable()
    {
        _controls.Disable();
    }

    void Update()
    {
        // 2D 입력을 3D로 변환 (WASD → xz)
        Vector3 input = new Vector3(_moveInput.x, 0f, _moveInput.y);
        input = Vector3.ClampMagnitude(input, 1f);

        // 속도 결정(Shift 누르면 runSpeed)
        float targetSpeed = _runHeld ? runSpeed : walkSpeed;
        Vector3 horizontal = input * targetSpeed;

        // 회전(입력이 있을 때만)
        if (input.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(new Vector3(horizontal.x, 0f, horizontal.z));
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, targetRot, turnSpeed * Time.deltaTime
            );
        }

        // 중력 처리
        if (_cc.isGrounded && _yVelocity < 0f)
            _yVelocity = -1f;

        _yVelocity += gravity * Time.deltaTime;

        // 최종 이동
        Vector3 velocity = new Vector3(horizontal.x, _yVelocity, horizontal.z);
        _cc.Move(velocity * Time.deltaTime);

        // 애니 파라미터 반영
        if (_anim != null)
        {
            // Speed 파라미터(Animator에서 전이 조건으로 쓰던 그거)
            _anim.SetFloat("Speed", horizontal.magnitude);
        }
    }
}
