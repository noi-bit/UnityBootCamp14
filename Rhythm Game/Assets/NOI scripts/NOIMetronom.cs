using UnityEngine;

public class NOIMetronom : MonoBehaviour
{
    public AudioSource tik;
    //public AudioClip tik;

    public float bpm;
    public float second = 60;

    public float temp1 = 4f;
    public float temp2 = 4f;

    public float time = 0;

    public float temp;

    private void Start()
    {
        temp = (second / bpm) * (temp1 / temp2);
    }

    void Update()
    {
        Metronum(temp);
        //time += Time.deltaTime;
        //if(time> temp)
        //{
        //    Metronum(temp);
        //    time = 0;
        //}
    }

    public void Metronum(float temp)
    {
        time += Time.deltaTime;
        if (time > temp)
        {
            //Metronum(temp);
            Debug.Log("1");
            tik.Play();
            time = 0;
        }
    }
}
