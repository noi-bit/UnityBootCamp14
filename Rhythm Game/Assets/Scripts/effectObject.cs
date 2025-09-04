using UnityEngine;

public class effectObject : MonoBehaviour
{
    public float lifetime = 0.03f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifetime);
    }
}
