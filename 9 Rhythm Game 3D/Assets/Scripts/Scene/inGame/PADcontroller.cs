using UnityEngine;
using System.Collections;

//�е��� ������ �ڵ�
public class PADcontroller : MonoBehaviour
{
    public GameObject NoteButton; //�긦�����δ�
    public KeyCode ButtonKey; //�� ��ǲ���޾Ƽ�
    public float pushValue; //�󸶳� ��������
    public UIManager _uimanager;
    //public NoteController _noteController;

    bool pressed;
    public bool _gamegetstart = true;

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
        if (_gamegetstart == false) return;
        if (Input.GetKeyDown(ButtonKey)) pressed = true;
        if (Input.GetKeyUp(ButtonKey)) pressed = false;
    }

    private void FixedUpdate()
    {
        var target = pressed ? originposition + new Vector3(0, -pushValue, 0) : originposition;
        rb.MovePosition(target);
    }
    
    public void NoteHitTiming(EnumData.NotePressMode pressmode)
    {
        switch (pressmode)
        {
            case EnumData.NotePressMode.Miss:
                _uimanager.SliderScore(-10);
                _uimanager.JudgeText.color = Color.red;
                _uimanager.SeterrorMsText(pressmode);
                break;

            case EnumData.NotePressMode.Good:
                _uimanager.SliderScore(3);
                _uimanager.JudgeText.color = Color.orange;
                _uimanager.SeterrorMsText(pressmode);
                break;

            case EnumData.NotePressMode.Great:
                _uimanager.SliderScore(5);
                _uimanager.JudgeText.color = Color.yellow;
                _uimanager.SeterrorMsText(pressmode);
                break;

            case EnumData.NotePressMode.Perfect:
                _uimanager.SliderScore(10);
                _uimanager.JudgeText.color = Color.green;
                _uimanager.SeterrorMsText(pressmode);
                break;
        }
    }
    
}
