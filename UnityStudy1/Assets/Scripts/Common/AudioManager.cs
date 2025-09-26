using System;
using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    lobby,
    COUNT //=>�ش� �̳ѿ� ����� �ִ��� Ȯ���ϱ� ����
}

public enum SFX
{ 
    chapter_clear,
    stage_clear,
    ui_button_click,
    COUNT
}

public class AudioManager : SingletonBehaviour<AudioManager>
{
    public Transform BGMTransform;
    public Transform SFXTransform;

    private const string AUDIO_PATH = "Audio";

    private Dictionary<BGM, AudioSource> m_BGMPlayer = new Dictionary<BGM, AudioSource>();
    private AudioSource m_CurrentBGMSource;


    private Dictionary<SFX, AudioSource> m_SFXPlayer = new Dictionary<SFX, AudioSource>();

    protected override void Init()
    {
        base.Init();

        //--> ���ҽ��� "�ҷ���" ����
        LoadBGMPlayer();
        LoadSFXPlayer();
    }

    //��� BGM���� ����� ��ȸ�Ͽ�, ���ӿ�����Ʈ ���� �� ����� �ҽ� ���۳�Ʈ �߰�, �ش� BGM ����
    private void LoadBGMPlayer()
    {
        for(int i = 0; i<(int)BGM.COUNT; i++) //-> �ϴ� BGM enum�� �ִ� �ҽ����� for������ ���� ���̾��Ű�� �÷����´�
        {
            string audioName = ((BGM)i).ToString();
            string pathString = $"{AUDIO_PATH}/{audioName}";
            AudioClip audioClip = Resources.Load<AudioClip>(pathString);
            if(audioClip == null)
            {
                Logger.LogError($"{audioName} Clip does not exist");
                continue;
            }

            GameObject newGo = new GameObject(audioName);
            AudioSource newAudioSource = newGo.AddComponent<AudioSource>();
            newAudioSource.clip = audioClip;
            newAudioSource.loop = true;
            newAudioSource.playOnAwake = false;

            newGo.transform.parent = BGMTransform;

            m_BGMPlayer[(BGM)i] = newAudioSource;
        }
    }

    private void LoadSFXPlayer()
    {
        for(int i = 0; i<(int)SFX.COUNT; i++)
        {
            string audioName = ((SFX)i).ToString();
            string pathString = $"{AUDIO_PATH}/{audioName}";
            AudioClip audioClip = Resources.Load<AudioClip>(pathString);
            if (audioClip == null)
            {
                Logger.LogError($"{audioName} Clip does not exist");
                continue;
            }

            GameObject newGo = new GameObject(audioName);
            AudioSource newAudioSource = newGo.AddComponent<AudioSource>();
            newAudioSource.clip = audioClip;
            newAudioSource.loop = false;
            newAudioSource.playOnAwake = false;

            newGo.transform.parent = SFXTransform;

            m_SFXPlayer[(SFX)i] = newAudioSource;
        }
    }

    public void PlayBGM(BGM bgm)
    {
        if(m_CurrentBGMSource != null) //���� �÷����ϴ� BGM�� �ִٸ�
        {
            m_CurrentBGMSource.Stop();
            m_CurrentBGMSource = null;
        }

        if(m_BGMPlayer.ContainsKey(bgm) == false) 
        {
            Logger.LogError($"Invalid clip name : {bgm}"); return;
        }

        m_CurrentBGMSource = m_BGMPlayer[bgm];
        m_CurrentBGMSource.Play();
    }

    public void PauseBGM()
    {
        if (m_CurrentBGMSource != null)
            m_CurrentBGMSource.Pause();
    }
    public void ResumeBGM()
    {
        if (m_CurrentBGMSource != null)
            m_CurrentBGMSource.UnPause();
    }
    public void StopBGM()
    {
        if (m_CurrentBGMSource != null)
            m_CurrentBGMSource.Stop();
    }

    public void PlaySFX(SFX sfx)
    {
        if(m_SFXPlayer.ContainsKey(sfx)==false)
        {
            Logger.LogError($"Invalid sfx name : {sfx}"); return;
        }

        m_SFXPlayer[sfx].Play();
    }
    
    public void Mute()
    {               //��� ��ųʸ� ������
        foreach(var audioSourceItem in m_BGMPlayer)
        {
            audioSourceItem.Value.volume = 0f;
        }
        foreach (var audioSourceItem in m_SFXPlayer)
        {
            audioSourceItem.Value.volume = 0f;
        }
    }
    public void UnMute()
    {               
        foreach (var audioSourceItem in m_BGMPlayer)
        {
            audioSourceItem.Value.volume = 1f;
        }
        foreach (var audioSourceItem in m_SFXPlayer)
        {
            audioSourceItem.Value.volume = 1f;
        }
    }
}
