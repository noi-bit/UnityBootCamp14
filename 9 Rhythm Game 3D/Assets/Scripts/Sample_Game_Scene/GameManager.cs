using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public UIManager uimanager;
    public static GameManager instance;
    public Action start;

    [Tooltip("���� ��ü ���� �� ������")]
    public float Globaldelay;
    //public float Globaldelay2;
    //public float temp;
    //public int temp2;

    //private float time;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += GameSceneLoadt;
    }

    private void GameSceneLoadt(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex ==2)
           StartCoroutine(Start()); 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= GameSceneLoadt;
    }
    private IEnumerator Start()
    {
        yield return null; //�����ڵ��� ��� ������ ��ĥ �� �ְ� ��ٷ���
        yield return new WaitForSecondsRealtime(Globaldelay);
        start.Invoke();
    }

}
