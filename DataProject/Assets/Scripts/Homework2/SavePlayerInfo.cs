using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePlayerInfo : MonoBehaviour//PlayerPrefs 로 해보자
{
    public Button DeleteorNew;//새로하기
    public Button LoadData;//이어하기
    public Button Save;//저장
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
            Debug.Log("플레이어의 정보가 지워졌습니다");
        }
    }

    void Loading()
    {
        SceneManager.LoadScene("NewScene");
        Debug.Log("새로운 세계에 오신 걸 환영합니다");
    }

    void SaveData()
    {

        PlayerPrefs.SetString("nameInput", playername.text);
        PlayerPrefs.SetString("gender", gender.options[gender.value].text);
        PlayerPrefs.SetString("work", work.options[work.value].text);
        PlayerPrefs.SetString("level", level.options[level.value].text);
        PlayerPrefs.Save();


        Debug.Log("플레이어 정보가 저장되었습니다");
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
