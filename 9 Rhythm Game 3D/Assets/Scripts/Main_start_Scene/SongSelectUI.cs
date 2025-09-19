using System;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectUI : MonoBehaviour
{
    [SerializeField] private Image cover;
    [SerializeField] private Text text;
    [SerializeField] private Dropdown dropdown;

    public AudioSource previewMusic;
    public static SongSelectUI UIinstance;
    public SO_data[] list;
    public int cur = 0;
    public LV dropdownlevel;

    void Awake()
    {
        if (UIinstance != null) { Destroy(gameObject); return; }
        UIinstance = this;
        DontDestroyOnLoad(gameObject);
        dropdown.onValueChanged.AddListener(OndropDownEvent);
    }

    public void OndropDownEvent(int index)
    {
        dropdownlevel = (LV)index;
    }

    public void LoadUI()
    {
        UIset(list[cur]);
    }

    void UIset(SO_data data)
    {
        previewMusic.clip = data.music;
        cover.sprite = data.CoverImage;
        text.text = data.SongName;
        previewMusic.Play();
    }

    public void SelectChangenext()
    {
        int next = (cur + 1) % list.Length;
        UIset(list[next]);
        
        cur = next;
    }
    public void SelectChangebefore()
    {
        int next = (cur - 1 + list.Length) % list.Length;
        UIset(list[next]);

        cur = next;
    }

    public void StopMusicUI()
    {
        previewMusic.Stop();
    }
}
