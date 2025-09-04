using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float t;
    public float beatTempo;
    public bool hasStarted;
    public SOscript SOscript;

    void Start()
    {
        beatTempo = SOscript.BPM /60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            t += Time.deltaTime;
            if (t >= 0.566f)
            {
                hasStarted = true;
            }
        
        }
        
           transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
       
    }
}
