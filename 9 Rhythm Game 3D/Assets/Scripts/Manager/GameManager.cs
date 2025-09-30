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

                                    //��� ���� �����Ҷ��� �����̰� ����°Ŵϱ�? �������ɵ�?
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

            //MoveScene.cl
            /*
             �� �Ŵ��������� �ʱ�ȭ
             
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
         �� �Ŵ������� Clear�Լ��� �ְ�
        ���⼭ ��ü Ŭ��� �����ϰԲ�
        */
    }

}
