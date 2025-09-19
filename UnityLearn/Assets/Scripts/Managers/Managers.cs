using System;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; //static - 유일성 보장
    //씬 이동시 참조값이 바뀌며 null이 됨 --> 그래서 DontDestroyOnLoad() 함수를 사용
    //값형식은 씬이 이동해도 그대로 유지가 됨 --> int age = 30; 이런거

    static public Managers GetInstance { get { Init(); return Instance; } }
                                       //매니저 객체를 만들지 않더라도 외부 클래스에서 Instance가 호출될 때 Init으로 만들어지게끔 함

    void Start()
    {
        //Instance = this; //-> 플레이를 누를때 새로 객체가 생성이 되며 자기 자신을 해당 객체에 담아준다
        Init();
    }

    void Update()
    {
        
    }

    static void Init()
    {
        if(Instance == null)
        {
            GameObject go = GameObject.Find("@@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            Instance = go.GetComponent<Managers>();
        }
    }
}
