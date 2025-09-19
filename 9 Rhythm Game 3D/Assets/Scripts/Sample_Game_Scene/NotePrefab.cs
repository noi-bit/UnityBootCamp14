using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NotePrefab : MonoBehaviour //프리팹에 붙인다
{
    Renderer mr;
    public Material original;
    public Material target;
    private NoteObjectPool pool;
    private Coroutine noteLife_coroutine;
    private Coroutine noteCreate_coroutine;

    private float Notedeletespeed;
    public float Notedeletevalue = 0.003f;
    //public float NotecreateSpeed;

    public void SetPool(NoteObjectPool pool) => this.pool = pool;

    // [추가] 큐브가 생성된 DSP 시각
                        private double _cubeSpawnDspTime; // 큐브가 실제로 생성된 DSP 시각
    // [추가] 박자 타이밍 DSP 기준값
                        private double _targetDspTime; // 이 큐브가 최대 크기가 되어야 하는 DSP 시각

    private void Awake()
    {
        mr = this.GetComponent<Renderer>();
    }

    //--> 여기서 박자 타이밍 DSP값과 현재 DSP값 받아와야 함
    //원래는 finalSize랑 Speed만 있었음
    public void NoteSizeUp(Vector3 finalcubesize, float Speed, double cubeSpawnDspTime, double targetDspTime)
    {
        //_targetDspTime = targetDspTime; // 박자 타이밍 DSP 기준값
        //_cubeSpawnDspTime = cubeSpawnDspTime; // 큐브 생성 DSP 기준값

        if (gameObject.activeInHierarchy)
        {
            if(noteCreate_coroutine != null) StopCoroutine(noteCreate_coroutine);
            noteCreate_coroutine = StartCoroutine(NoteSizeChange(finalcubesize, Speed, targetDspTime, cubeSpawnDspTime));
        }
    }

    IEnumerator NoteSizeChange(Vector3 finalcubesize, float Speed, double targetDspTime, double cubeSpawnDspTime)
    {
        float t = 0f;
        float _duration = (float)(targetDspTime - _cubeSpawnDspTime);

        transform.localScale = Vector3.zero;
        while (t < _duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, finalcubesize, t/ _duration);
            if(t>= _duration * 0.7f)
            {
                mr.material = target;
            }
            yield return null;
        }
        transform.localScale = finalcubesize;
                        //mr.material = target;
    }

    public void SetLifeByBpm(float bpm) //NoteController 에서 호출
    {
        Notedeletespeed = bpm * Notedeletevalue;
        if(gameObject.activeInHierarchy)
        {
            if (noteLife_coroutine != null) StopCoroutine(noteLife_coroutine);
            noteLife_coroutine = StartCoroutine(NoteReturn(Notedeletespeed));
        }
    }

    IEnumerator NoteReturn(float life)
    {
        yield return new WaitForSeconds(life);
        ReturnPool();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PAD"))
        {
            Debug.Log("노트충돌일어남");
            /*여기 챙! 하고 소리 넣기*/
            ReturnPool();
        }
    }

    void ReturnPool()
    {
        if (pool != null)
        {
            mr.material = original;
            pool.Return(gameObject);
        }
    }

    void OnDisable()
    {
        if (noteLife_coroutine != null)
            StopCoroutine(noteLife_coroutine);
        if (noteCreate_coroutine != null)
            StopCoroutine(noteCreate_coroutine);
    }
}
