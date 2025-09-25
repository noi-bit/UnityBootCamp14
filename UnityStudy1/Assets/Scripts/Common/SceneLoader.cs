using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title, //로그인, 정보를 로딩하는 단계
    Lobby,
    InGame
}

public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    public void LoadScene(SceneType sceneType)
    {
        Logger.Log($"{sceneType} - scene Loading...");

        Time.timeScale = 1f; //씬이동 후 타임스케일 초기화
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
