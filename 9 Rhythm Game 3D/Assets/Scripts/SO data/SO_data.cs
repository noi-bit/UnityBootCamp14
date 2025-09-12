using UnityEngine;

[CreateAssetMenu]
public class SO_data : ScriptableObject
{
    public string SongName;
    public AudioClip music;

    public bool loop = false;
    public float BPM;
    [Tooltip("�뷡�� ù ���۱����� ������ ����")]
    public double firstBeatOffset;//�뷡�� ù ���۱����� ������ ����(���ڷ�)
    [Tooltip("����")]
    public float volume = 1f;
}
