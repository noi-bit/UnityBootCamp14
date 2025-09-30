using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SettingsUI : BaseUI
{
    public TextMeshProUGUI _gameVersionText;

    public GameObject _soundOnToggle;
    public GameObject _soundOffToggle;

    private const string PRIVACY_POLICY_URL = "https://www.google.com/";

    public override void SetInfo(BaseUIData uiData)
    {
        base.SetInfo(uiData);

        _gameVersionText.text = $"Version : {Application.version}";

        UserSettingsData userSettingsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        if (userSettingsData != null)
        {
            SetSoundSetting(userSettingsData.Sound);
        }
    }

    private void SetSoundSetting(bool sound) // ���ӿ�����Ʈ�� Ȱ��ȭ ��Ȱ��ȭ
    {
        _soundOnToggle.SetActive(sound);
        _soundOffToggle.SetActive(!sound);
    }

    public void OnClickSoundOnToggle()
    {
        Logger.Log($"{GetType()}::OnClickSoundOnToggle");

        AudioManager.Instance.PlaySFX(SFX.ui_button_click);

        UserSettingsData userSettingsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        if (userSettingsData != null) // ���� ������ ����
        {
            userSettingsData.Sound = false; 
            UserDataManager.Instance.SaveUserData();
            AudioManager.Instance.Mute();
            SetSoundSetting(userSettingsData.Sound);
        }
    }

    public void OnClickSoundOffToggle()
    {
        Logger.Log($"{GetType()}::OnClickSoundOffToggle");

        AudioManager.Instance.PlaySFX(SFX.ui_button_click);

        UserSettingsData userSettingsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        if (userSettingsData != null) // ���� ������ ����
        {
            userSettingsData.Sound = true;
            UserDataManager.Instance.SaveUserData();
            AudioManager.Instance.UnMute();
            SetSoundSetting(userSettingsData.Sound);
        }
    }

    public void OnClickPrivacyPolicyURL()
    {
        Logger.Log($"{GetType()}::OnClickPrivacyPolicyURL");

        AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        Application.OpenURL(PRIVACY_POLICY_URL);
    }
}
