using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneManager
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); //게임씬
        GameManager.Instance.nowstats = EnumData.GameStatus.inGame;
    }

    public void LoadScene(EnumData.GameStatus status)
    {
        SceneManager.LoadScene((int)status); //-> 1 로비 2 게임
    }
}
