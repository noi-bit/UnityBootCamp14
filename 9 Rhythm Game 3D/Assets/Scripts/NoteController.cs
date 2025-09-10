using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject NoteButton;
    public KeyCode ButtonKey;
    public float pushValue;

    public Metronome metronome;

    private Renderer Renderer;
    public Color origincolor;
    public Color targetcolor;

    Vector3 originposition;

    void Start()
    {
        Renderer = GetComponent<Renderer>();
        originposition = transform.position;
        //metronome.create += colorChange;
    }

    void Update()
    {
        keypress();
    }

    void keypress()
    {
        if (Input.GetKeyDown(ButtonKey))
        {
            gameObject.transform.position -= new Vector3(0, pushValue, 0);
            Renderer.material.color = targetcolor;

        }
        if (Input.GetKeyUp(ButtonKey))
        {
            gameObject.transform.position = originposition;
            Renderer.material.color = origincolor;
        }
    }

    void colorChange()
    {
        Renderer.material.color = targetcolor;
    }
}
