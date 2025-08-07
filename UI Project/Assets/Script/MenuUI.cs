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
        SceneManager.LoadScene("SampleScene"); //�� �̵�
                                               //�����ǻ��� : ���� ����Ƽ �����Ϳ��� ��ϵǾ��־�� ��!!
                                               //SceneMangager - �̸� ��ġ�� �ʰ� ���� �Ф�
    }

    private void GameRule()
    {
        RuleUI.SetActive(true);
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.Exit(0); //���������� �����մϴ�
#else
        Application.Quit();
#endif
    }
}
