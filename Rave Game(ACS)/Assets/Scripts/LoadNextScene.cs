using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void playScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void startScene()
    {
        SceneManager.LoadScene("startScene");
    }
}
