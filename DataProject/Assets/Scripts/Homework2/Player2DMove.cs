using UnityEngine;
using UnityEngine.UI;

public class Player2DMove : MonoBehaviour
{
    public float PlayerSpeed = 3.0f;
    public Canvas playerlv;
    Vector3 playerpos;
    public Text lvtext;
    private int lv = 1;
    private void Start()
    {
        lvtext.text = $"lv : ?";
    }

    void Update()
    {
        float Horizoninput = Input.GetAxisRaw("Horizontal")*PlayerSpeed*Time.deltaTime;
        float Verticalinput = Input.GetAxisRaw("Vertical") * PlayerSpeed * Time.deltaTime;
        transform.Translate(new Vector3(Horizoninput, Verticalinput,0));
        playerpos = transform.position;

        playerlv.transform.position = playerpos + new Vector3(0,0.1f);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            lv++;
        }
            lvtext.text = $"lv : {lv}";
        Debug.Log("Ãæµ¹Àº ¤·¤¸µÊ");
    }
}

