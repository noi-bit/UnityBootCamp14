using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_data : ScriptableObject
{
    public Sprite CoverImage;
    public string SongName;
    public AudioClip music;

    [Tooltip("노래의 첫 박자 의 시작까지의 오프셋 길이")]
    public float firstBeatOffset;//노래의 첫 시작까지의 오프셋 길이(박자로)

    //public bool loop = false;
    //public float volume = 1f;
    public float BPM;
    public EnumData.LV level;
}

