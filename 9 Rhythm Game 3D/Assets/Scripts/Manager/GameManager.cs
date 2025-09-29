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
    private ResourceManager _resources = new ResourceManager();

    public static GameManager Instance { get { Init(); return _instance; } }
    public static MoveSceneManager MoveScene { get { return Instance._movescene; } }
    public static ResourceManager Resources { get { return Instance._resources; } }

                                    //얘는 게임 시작할때만 딜레이가 생기는거니까? 여기없어도될듯?
                                    [Tooltip("게임 전체 시작 전 딜레이")]
                                    //public float Globaldelay=4f;
                                    //public Action start;
    //public EnumData.Scene nowstats;

    void Start()
    {
        Init();
    }
    void Update()
    {
        
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@@Managers@@");
            if (go == null)
            {
                go = new GameObject { name = "@@Managers@@"};
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<GameManager>();

            /*
             각 매니저마다의 초기화
             
             */

        }
    }

    private void OnEnable()
    {
        //nowstats = EnumData.Scene.inTitle;
        //SceneManager.sceneLoaded += GameSceneLoad;
    }

    //private void GameSceneLoad(Scene scene, LoadSceneMode mode)
    //{
    //    if(scene.buildIndex ==2)
    //       StartCoroutine(_Start()); 
    //}

    private void OnDisable()
    {
        //SceneManager.sceneLoaded -= GameSceneLoad;
    }
    //private IEnumerator _Start()
    //{
    //    yield return null; //구독자들이 모든 구독을 마칠 수 있게 기다려줌
    //            //yield return new WaitForSecondsRealtime(Globaldelay);
    //}

    public static void Clear()
    {
        MoveScene.Clear();
        /* 
         각 매니저마다 Clear함수를 넣고
        여기서 전체 클리어가 가능하게끔
        */
    }

}
