using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{//얘가 직접 동작하지 않고 Scene에 붙은 자식들이 얘를 호출함
    public EnumData.Scene SceneType { get; protected set; }

    void Awake()
    {
        Init();
    }
    
    protected virtual void Init()
    {
        if(SceneType == EnumData.Scene.Title)
        Debug.Log("타이틀 씬 도달");
        if (SceneType == EnumData.Scene.Game)
        Debug.Log("게임 씬 도달");

        //GameManager.Resources./*SO프리팹을 불러오는 함수 작성*/;
    }

    protected virtual void MoveScene()
    {
        Debug.Log("씬을 이동합니다");
    }

    public abstract void Clear();
}
