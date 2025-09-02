using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;

    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }
        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    } //특정 키를 눌렀을때 키 이미지가 pressedImage가 되고
    //누르는걸 떼었을때 defaultImage가 됨
}
