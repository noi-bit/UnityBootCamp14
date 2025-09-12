using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Action start;

    [Tooltip("게임 전체 시작 전 딜레이")]
    public float Globaldelay;

    //private float time;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
        yield return null; //구독자들이 모든 구독을 마칠 수 있게 기다려줌
        yield return new WaitForSecondsRealtime(Globaldelay);
        start.Invoke();
    }

}
