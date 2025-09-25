using System;
using System.Collections;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public UIManager uimanager;
    private static GameManager _instance;
    private MoveSceneManager _movescene = new MoveSceneManager();

    public static GameManager Instance { get { Init(); return _instance; } }
    public static MoveSceneManager MoveScene { get { return Instance._movescene; } }

    [Tooltip("게임 전체 시작 전 딜레이")]
    public float Globaldelay=4f;
    public Action start;
    public EnumData.GameStatus nowstats;

    void Awake()
    {
        Init();
    }

    private static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@@Managers" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<GameManager>();
        }
    }

    private void OnEnable()
    {
        nowstats = EnumData.GameStatus.Lobby;
        SceneManager.sceneLoaded += GameSceneLoad;
    }

    private void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex ==2)
           StartCoroutine(Start()); 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= GameSceneLoad;
    }
    private IEnumerator Start()
    {
        yield return null; //구독자들이 모든 구독을 마칠 수 있게 기다려줌
        yield return new WaitForSecondsRealtime(Globaldelay);
        start.Invoke();
    }

}
