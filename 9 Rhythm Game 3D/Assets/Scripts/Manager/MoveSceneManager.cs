using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneManager
{
    public BaseScene CurrentScene 
    { get { return GameObject.FindFirstObjectByType<BaseScene>();}}

    public void LoadScene(EnumData.Scene type)
    {
        GameManager.Clear();
        SceneManager.LoadScene(type.ToString()); //-> 1 �κ� 2 ����
    }

    //���ӸŴ������� �Ѱ������� Clear���Ѿ� �Ҷ�?
    public void Clear()
    {
        CurrentScene.Clear();
    }
}
