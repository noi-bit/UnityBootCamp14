using UnityEngine;

public class CameraMoveSample : MonoBehaviour
{
    public GameObject player;
    public int offsetValue;
    Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, offsetValue, 0);
        transform.position = player.transform.position + offset;    
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
