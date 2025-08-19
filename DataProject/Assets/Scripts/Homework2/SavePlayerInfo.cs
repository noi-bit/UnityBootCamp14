using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePlayerInfo : MonoBehaviour//PlayerPrefs �� �غ���
{
    public Button DeleteorNew;//�����ϱ�
    public Button LoadData;//�̾��ϱ�
    public Button Save;//����
    public Image newSelect;
    public InputField playername;
    public Dropdown gender;
    public Dropdown work;
    public Dropdown level;

    private void Start()
    {
        Save.onClick.AddListener(SaveData);
        LoadData.onClick.AddListener(Loading);
        DeleteorNew.onClick.AddListener(DestroyData);
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("nameInput"))
        {
            LoadData.interactable = true;
        }
        else
        {
            LoadData.interactable = false;
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("�÷��̾��� ������ ���������ϴ�");
        }
    }

    void Loading()
    {
        SceneManager.LoadScene("NewScene");
        Debug.Log("���ο� ���迡 ���� �� ȯ���մϴ�");
    }

    void SaveData()
    {

        PlayerPrefs.SetString("nameInput", playername.text);
        PlayerPrefs.SetString("gender", gender.options[gender.value].text);
        PlayerPrefs.SetString("work", work.options[work.value].text);
        PlayerPrefs.SetString("level", level.options[level.value].text);
        PlayerPrefs.Save();


        Debug.Log("�÷��̾� ������ ����Ǿ����ϴ�");
        newSelect.gameObject.SetActive(false);

    }

    void DestroyData()
    {
        if (PlayerPrefs.HasKey("playername") && PlayerPrefs.HasKey("gender"))
        {
            PlayerPrefs.DeleteAll();
            newSelect.gameObject.SetActive(true);
        }
        else
        {
            newSelect.gameObject.SetActive(true);
        }
    }
}
