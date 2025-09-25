using UnityEngine;
using System.Collections;

//패드의 움직임 코드
public class PADcontroller : MonoBehaviour
{
    public GameObject NoteButton; //얘를움직인다
    public KeyCode ButtonKey; //이 인풋을받아서
    public float pushValue; //얼마나 누를건지
    public UIManager _uimanager;

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
    
    public void NoteHitTiming(EnumData.NotePressMode pressmode)
    {
        switch (pressmode)
        {
            case EnumData.NotePressMode.Miss:
                _uimanager.SliderScore(-10);
                _uimanager.ErrorMSText.color = Color.red;
                _uimanager.SeterrorMsText(pressmode);
                break;
            case EnumData.NotePressMode.Good:
                _uimanager.SliderScore(3);
                _uimanager.ErrorMSText.color = Color.orange;
                _uimanager.SeterrorMsText(pressmode);
                break;
            case EnumData.NotePressMode.Great:
                _uimanager.SliderScore(5);
                _uimanager.ErrorMSText.color = Color.aliceBlue;
                _uimanager.SeterrorMsText(pressmode);
                break;
            case EnumData.NotePressMode.Perfect:
                _uimanager.SliderScore(10);
                _uimanager.ErrorMSText.color = Color.greenYellow;
                _uimanager.SeterrorMsText(pressmode);
                break;
        }
    }
    
}
