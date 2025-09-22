using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class NoteController : MonoBehaviour
{
    //SO_data sodatas;
    public GameObject note; //ť��(��Ʈ)�� �ǹ��Ѵ�
    public GameObject[] cubeposition; //���� ���������Ǵ� ��Ʈ ��ġ ������ ��� ������Ʈ �迭(�е�)
    public SongController songController; //�뷡 ��ũ��Ʈ���� �뷡�� ����,BPM���� ������ �޾ƿ;� ��

    [Tooltip("�� �ڸ��� ��Ʈ�� �������� ���� ����")]
    public float spawnEveryNBeats; // float���� ����
    public int beatOffset = 0; //����?������

    //[Tooltip("��Ʈ ������� �ӵ� = BPM�� �����")]
    //[SerializeField] private float Notdeletespeed;

    #region Ǯ��������
    [SerializeField] private NoteObjectPool pool; //-> ��Ʈ�� ����� ��ġ
    //private Coroutine noteLife_coroutine;

    private void Start() //���� �߰�
    {
      
        LevelLoad();
        if (pool == null) pool = FindAnyObjectByType<NoteObjectPool>();
        songController.createCube += Test;
        //Notdeletespeed = songController.songBpm * 0.003f;     <--�̰� NotePrefab ��ũ��Ʈ��, ���⼭�� OnBeat �����ϰ�, ��Ʈ ��Ģ(beatOffset, spawnEveryNBeats) üũ�ϰ� ����
    }

    void Test(int beatIndex)
    {
        if (cubeposition == null || cubeposition.Length == 0) return;

        float beat = beatIndex - beatOffset;
        if (!Mathf.Approximately(beat % spawnEveryNBeats, 0f)) return;

        GameObject go = pool.GetNote();
        if (go == null) return;
       
        Vector3 pos = cubeposition[Random.Range(0, cubeposition.Length)].transform.position; //���⼭ ������ġ�� ������ ť�갡 ������
        go.transform.position = pos;

        go.transform.localScale = Vector3.zero;

        Debug.Log(go.transform.localScale);

        var nc = go.GetComponent<NotePrefab>();

        nc.NoteSizeUp(new Vector3(1.25f,0.5f,1.25f), songController.nowCubetime);
        //nc.SetLifeByBpm(songController.sodata.BPM);
    }

    public void LevelLoad()
    {
        switch(SongSelectUI.UIinstance.dropdownlevel)
        {
            case LV.supereasy:
                spawnEveryNBeats = 4;
                break;
            case LV.easy:
                spawnEveryNBeats = 2;
                break;
            case LV.normal:
                spawnEveryNBeats = 1;
                break;
            case LV.hard:
                spawnEveryNBeats = 0.5f;
                break;
        }
    }

    private void OnDisable()
    {
        if (songController != null)
            songController.createCube -= Test;
    }

    void ReturnPool() => pool.Return(gameObject);
    #endregion

}
