using UnityEngine;

public class Sample01 : MonoBehaviour
{
    public CustomComponent cc;

    private void Awake()
    {
        cc = GetComponent<CustomComponent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
