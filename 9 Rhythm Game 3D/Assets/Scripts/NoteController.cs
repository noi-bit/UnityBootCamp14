using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class NoteController : MonoBehaviour
{
    //public SO_data sodata;
    public GameObject note; //ť��(��Ʈ)�� �ǹ��Ѵ�
    public GameObject[] cubeposition; //���� ���������Ǵ� ��Ʈ ��ġ ������ ��� ������Ʈ �迭(�е�)
    public SongController songController; //�뷡 ��ũ��Ʈ���� �뷡�� ����,BPM���� ������ �޾ƿ;� ��

    [Tooltip("�� �ڸ��� ��Ʈ�� �������� ���� ����")]
    [SerializeField] int spawnEveryNBeats = 1; //�� ���ڸ��� ��Ʈ�� ������!! -������ ��������
    [SerializeField] int beatOffset = 0; //����?������

    //[Tooltip("��Ʈ ������� �ӵ� = BPM�� �����")]
    //[SerializeField] private float Notdeletespeed;

    #region Ǯ��������
    [SerializeField] private NoteObjectPool pool; //-> ��Ʈ�� ����� ��ġ
    //private Coroutine noteLife_coroutine;

    private void Start() //���� �߰�
    {
        if (pool == null) pool = FindAnyObjectByType<NoteObjectPool>();
        songController.OnBeat += Test;
        //Notdeletespeed = songController.songBpm * 0.003f;     <--�̰� NotePrefab ��ũ��Ʈ��, ���⼭�� OnBeat �����ϰ�, ��Ʈ ��Ģ(beatOffset, spawnEveryNBeats) üũ�ϰ� ����
    }

    private void OnDisable()
    {
        if (songController != null)
            songController.OnBeat -= Test;
    }

    void Test(int beatIndex)
    {
        if (cubeposition == null || cubeposition.Length == 0) return;

        
        if (((beatIndex - beatOffset) % spawnEveryNBeats) != 0) return;

        GameObject go = pool.GetNote();
        if (go == null) return;
        
        Vector3 pos = cubeposition[Random.Range(0, cubeposition.Length)].transform.position;
        go.transform.position = pos;

        var nc = go.GetComponent<NotePrefab>();
        nc.SetLifeByBpm(songController.sodata.BPM);
        // ����� -> NoteController note =  go.GetComponent<NoteController>();

    }

    void ReturnPool() => pool.Return(gameObject);
    #endregion

}
