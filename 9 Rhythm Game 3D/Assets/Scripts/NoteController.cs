using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class NoteController : MonoBehaviour
{
    //public SO_data sodata;
    public GameObject note; //큐브(노트)를 의미한다
    public GameObject[] cubeposition; //새로 랜덤생성되는 노트 위치 정보가 담긴 오브젝트 배열(패드)
    public SongController songController; //노래 스크립트에서 노래의 박자,BPM등의 정보를 받아와야 함

    [Tooltip("몇 박마다 노트를 뽑을지에 대한 변수")]
    [SerializeField] int spawnEveryNBeats = 1; //몇 박자마다 노트를 뽑을지!! -레벨과 관련있음
    [SerializeField] int beatOffset = 0; //박자?오프셋

    //[Tooltip("노트 사라지는 속도 = BPM에 비례함")]
    //[SerializeField] private float Notdeletespeed;

    #region 풀관련정보
    [SerializeField] private NoteObjectPool pool; //-> 노트가 저장될 위치
    //private Coroutine noteLife_coroutine;

    private void Start() //구독 추가
    {
        if (pool == null) pool = FindAnyObjectByType<NoteObjectPool>();
        songController.OnBeat += Test;
        //Notdeletespeed = songController.songBpm * 0.003f;     <--이건 NotePrefab 스크립트에, 여기서만 OnBeat 구독하고, 비트 규칙(beatOffset, spawnEveryNBeats) 체크하고 스폰
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
        // 강사님 -> NoteController note =  go.GetComponent<NoteController>();

    }

    void ReturnPool() => pool.Return(gameObject);
    #endregion

}
