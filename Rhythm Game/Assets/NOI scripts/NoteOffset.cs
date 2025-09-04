using UnityEngine;

public class NoteOffset : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnAnimatorMove()
    {
        transform.position += new Vector3(0, 1, 0);
    }
}
