using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title, //�α���, ������ �ε��ϴ� �ܰ�
    Lobby,
    InGame
}

public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    public void LoadScene(SceneType sceneType)
    {
        Logger.Log($"{sceneType} - scene Loading...");

        Time.timeScale = 1f; //���̵� �� Ÿ�ӽ����� �ʱ�ȭ
        SceneManager.LoadScene(sceneType.ToString());
    }

    public void ReloadScene()
    {
        Logger.Log($"{SceneManager.GetActiveScene().name} - scene Loading...");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public AsyncOperation LoadSceneAsync(SceneType sceneType)
    {
        Logger.Log($"{sceneType} - Loading Scene...");

        Time.timeScale = 1;
        return SceneManager.LoadSceneAsync(sceneType.ToString());
    }
}
