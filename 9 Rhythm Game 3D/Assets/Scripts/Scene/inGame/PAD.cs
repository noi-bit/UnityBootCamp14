using UnityEngine;
using UnityEngine.PlayerLoop;

public class PAD : MonoBehaviour //모든 패드에 부착하여라
{
    public GameObject NoteButton;
    private Vector3 originposition;
    private Rigidbody rb;
    private Vector3 move;

    public bool _pressed=false;
    public KeyCode ButtonKey;
    public float pushValue=0.3f;

    void Start()
    {
        rb = NoteButton.GetComponent<Rigidbody>();
        originposition = NoteButton.transform.position;
    }

    public void Push()
    {
        move = _pressed ? originposition + new Vector3(0, -pushValue, 0) : originposition;
        rb.MovePosition(move);
    }
}
