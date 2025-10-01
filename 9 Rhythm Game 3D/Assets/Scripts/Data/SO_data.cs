using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_data : ScriptableObject
{
    public Sprite CoverImage;
    public string SongName;
    public AudioClip music;

    [Tooltip("�뷡�� ù ���� �� ���۱����� ������ ����")]
    public float firstBeatOffset;//�뷡�� ù ���۱����� ������ ����(���ڷ�)

    //public bool loop = false;
    //public float volume = 1f;
    public float BPM;
    public EnumData.LV level;
}

