using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneManager
{
    public BaseScene CurrentScene 
    { get { return GameObject.FindFirstObjectByType<BaseScene>();}}

    public void LoadScene(EnumData.Scene type)
    {
        GameManager.Clear();
        SceneManager.LoadScene(type.ToString()); //-> 1 로비 2 게임
    }

    //게임매니저에서 총괄적으로 Clear시켜야 할때?
    public void Clear()
    {
        CurrentScene.Clear();
    }
}
