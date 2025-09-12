using UnityEngine;

[CreateAssetMenu]
public class SO_data : ScriptableObject
{
    public string SongName;
    public AudioClip music;

    public bool loop = false;
    public float BPM;
    [Tooltip("노래의 첫 시작까지의 오프셋 길이")]
    public double firstBeatOffset;//노래의 첫 시작까지의 오프셋 길이(박자로)
    [Tooltip("음량")]
    public float volume = 1f;
}
