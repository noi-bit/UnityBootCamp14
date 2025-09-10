using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Action start;

    private float time;
    public float startdelay;

    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if (time > startdelay)
        {
            if (start != null)
                start.Invoke();
        }
    }
}
