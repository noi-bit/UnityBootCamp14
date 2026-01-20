using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class SelectCanvas : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image cover;
    [SerializeField] private Text text;
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private Button Gamestart;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button PrevButton;

    [Header("Song Data")]
    [SerializeField] private List<SO_data> _songlist = new List<SO_data>();
    [SerializeField] private SO_data currentsong;
    [SerializeField] private int cur = 0;

    [Header("Audio")]
    [SerializeField] private AudioSource previewMusic;

    public Action goGame;
    public EnumData.LV dropdownlevel;

    void Awake()
    {
        var SOsongs = GameManager.Resources.LoadAll<SO_data>("Song_SO");
        _songlist.AddRange(SOsongs);
        if (_songlist == null) Debug.Log("노래가 리스트에 들어오지 않음");
        SetupUI();
        SetupSO();
    }

    private void OnEnable()
    {
        if(_songlist != null && _songlist.Count > 0)
        {
            PlayCurrentMusic();
        }
    }
    private void SetupUI()
    {
        dropdown.onValueChanged.AddListener(OndropDownEvent);
        Gamestart.onClick.AddListener(GoGame);
        NextButton.onClick.AddListener(SelectChangenext);
        PrevButton.onClick.AddListener(SelectChangebefore);
        //Gamestart.onClick.AddListener(StopMusicUI);
    }

    public void OndropDownEvent(int index)
    {
        dropdownlevel = (EnumData.LV)index;
        //GameManager.Song.LV = dropdownlevel;
    }

    public void SetupSO()
    {
        if (_songlist == null || _songlist.Count == 0) return;
        currentsong = _songlist[cur];
        UIset(currentsong);
        
    }

    void UIset(SO_data data)
    {
        if (data == null) return;

        GameManager.Song.currentSOdata = data;
        cover.sprite = data.CoverImage;
        text.text = data.SongName;
        previewMusic.clip = data.music;
        data.level = dropdownlevel;
    }
    public void SelectChangenext()
    {
        if (_songlist == null || _songlist.Count == 0) return;

        cur = (cur + 1) % _songlist.Count;
        SetupSO();
        PlayCurrentMusic();
    }
    public void SelectChangebefore()
    {
        if (_songlist == null || _songlist.Count == 0) return;
        StopPreviewMusic();
        cur = (cur - 1 + _songlist.Count) % _songlist.Count;
        SetupSO();
        PlayCurrentMusic();
    }
    private void PlayCurrentMusic()
    {
        if (previewMusic != null && previewMusic.clip != null)
        {
            previewMusic.Play();
        }
    }
    private void StopPreviewMusic()
    {
        if (previewMusic != null && previewMusic.isPlaying)
        {
            previewMusic.Stop();
        }
    }
    public void GoGame()
    {
        StopPreviewMusic();
        goGame?.Invoke();
    }
}
