using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class NoteController : MonoBehaviour
{
    //SO_data sodatas;
    public GameObject note; //큐브(노트)를 의미한다
    public GameObject[] cubeposition; //새로 랜덤생성되는 노트 위치 정보가 담긴 오브젝트 배열(패드)
    public SongController songController; //노래 스크립트에서 노래의 박자,BPM등의 정보를 받아와야 함

    [Tooltip("몇 박마다 노트를 뽑을지에 대한 변수")]
    public float spawnEveryNBeats; // float으로 변경
    public int beatOffset = 0; //박자?오프셋

    //[Tooltip("노트 사라지는 속도 = BPM에 비례함")]
    //[SerializeField] private float Notdeletespeed;

    #region 풀관련정보
    [SerializeField] private NoteObjectPool pool; //-> 노트가 저장될 위치
    //private Coroutine noteLife_coroutine;

    private void Start() //구독 추가
    {
      
        LevelLoad();
        if (pool == null) pool = FindAnyObjectByType<NoteObjectPool>();
        songController.createCube += Test;
        //Notdeletespeed = songController.songBpm * 0.003f;     <--이건 NotePrefab 스크립트에, 여기서만 OnBeat 구독하고, 비트 규칙(beatOffset, spawnEveryNBeats) 체크하고 스폰
    }

    void Test(int beatIndex)
    {
        if (cubeposition == null || cubeposition.Length == 0) return;

        float beat = beatIndex - beatOffset;
        if (!Mathf.Approximately(beat % spawnEveryNBeats, 0f)) return;

        GameObject go = pool.GetNote();
        if (go == null) return;
       
        Vector3 pos = cubeposition[Random.Range(0, cubeposition.Length)].transform.position; //여기서 랜덤위치로 설정된 큐브가 생성됨
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
