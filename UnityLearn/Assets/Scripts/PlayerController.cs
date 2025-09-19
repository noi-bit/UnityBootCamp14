using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed; 
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime * speed; 
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
    }
}
