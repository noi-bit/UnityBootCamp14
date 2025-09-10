using UnityEngine;

public class NOIGameManager : MonoBehaviour
{
    NOIMetronom metronom;
    NoteOffset noteOffset;
    
    public GameObject[] notes;

    void Start()
    {
        
    }
    
    void Update()
    {
        create(); 
    }

    public void create()
    {
        float time = 0;
        time += Time.deltaTime;
        if (time > 1)
        {
            //Metronum(temp);
            for(int i = 0; i<notes.Length; i++)
            { Instantiate(notes[i]);}
            time = 0;

        }
    }
}
