using UnityEngine;

//�е��� ������ �ڵ�
public class PADcontroller : MonoBehaviour
{
    public GameObject NoteButton; //�긦�����δ�
    public KeyCode ButtonKey; //�� ��ǲ���޾Ƽ�
    public float pushValue; //�󸶳� ��������

    bool pressed;

    Rigidbody rb;

    Vector3 originposition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Start()
    {
        originposition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(ButtonKey)) pressed = true;
        if (Input.GetKeyUp(ButtonKey)) pressed = false;
    }

    private void FixedUpdate()
    {
        var target = pressed ? originposition + new Vector3(0, -pushValue, 0) : originposition;
        rb.MovePosition(target);
    }
   
}
