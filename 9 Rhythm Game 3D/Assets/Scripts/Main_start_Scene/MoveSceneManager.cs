using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneManager
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); //���Ӿ�
        GameManager.Instance.nowstats = EnumData.GameStatus.inGame;
    }

    public void LoadScene(EnumData.GameStatus status)
    {
        SceneManager.LoadScene((int)status); //-> 1 �κ� 2 ����
    }
}
