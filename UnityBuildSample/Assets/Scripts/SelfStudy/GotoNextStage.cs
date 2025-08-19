using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotoNextStage : MonoBehaviour
{
    public Button nextstage;
    void Start()
    {
        nextstage.onClick.AddListener(NextStage);
    }

    
    public void NextStage()
    {
        SceneManager.LoadScene("GameScene2");
    }
}
