using System;
using System.Collections;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    //public UIManager uimanager;
    private static GameManager _instance;
    private MoveSceneManager _movescene = new MoveSceneManager();
    private ResourceManager _resources = new ResourceManager();
    private SongManager _songmanager = new SongManager();
    //private InputManager _inputmanager = new InputManager();    
    public static GameManager Instance { get { Init(); return _instance; } }
    public static MoveSceneManager MoveScene { get { return Instance._movescene; } }
    public static ResourceManager Resources { get { return Instance._resources; } }
    public static SongManager Song { get { return Instance._songmanager; } }
    //public static InputManager InputManager { get { return Instance._inputmanager; } }

    public static bool _isGameStart;

    void Start() //awake에서?
    {
        Init();
    }
    void Update()
    {
        //_inputmanager.OnUpdate();
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

            //MoveScene.cl
            /*
             각 매니저마다의 초기화
             
             */

        }
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public static void Clear()
    {
        MoveScene.Clear();
        /* 
         각 매니저마다 Clear함수를 넣고
        여기서 전체 클리어가 가능하게끔
        */
    }
}
