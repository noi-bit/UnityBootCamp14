using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material material;

    public float scrollSpeed = 0.2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.up;
        material.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
