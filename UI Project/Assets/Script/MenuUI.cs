using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button button_start;
    public Button button_rule;
    public Button button_exit;

    public GameObject RuleUI;

    private void Start()
    {
        button_start.onClick.AddListener(Gamestart);
        button_rule.onClick.AddListener(GameRule);
        button_exit.onClick.AddListener(GameExit);
    }

    private void Gamestart()
    {
        SceneManager.LoadScene("SampleScene"); //씬 이동
                                               //※유의사항 : 씬이 유니티 에디터에서 등록되어있어야 함!!
                                               //SceneMangager - 이름 겹치지 않게 조심 ㅠㅠ
    }

    private void GameRule()
    {
        RuleUI.SetActive(true);
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.Exit(0); //정상적으로 종료합니다
#else
        Application.Quit();
#endif
    }
}
