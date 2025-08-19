using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScenetoTitleScene : MonoBehaviour
{
    public Button Back;

    void Start()
    {
        Back.onClick.AddListener(BacktoTitle);
    }

    void BacktoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
