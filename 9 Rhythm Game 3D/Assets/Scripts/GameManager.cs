using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Action start;

    [Tooltip("���� ��ü ���� �� ������")]
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
        yield return null; //�����ڵ��� ��� ������ ��ĥ �� �ְ� ��ٷ���
        yield return new WaitForSecondsRealtime(Globaldelay);
        start.Invoke();
    }

}
