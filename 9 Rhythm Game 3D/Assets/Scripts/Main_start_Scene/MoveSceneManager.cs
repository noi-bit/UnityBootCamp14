using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneManager : MonoBehaviour
{
    public void goScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
