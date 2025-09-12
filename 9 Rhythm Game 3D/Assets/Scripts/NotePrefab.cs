using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NotePrefab : MonoBehaviour //프리팹에 붙인다
{
    [Tooltip("노트 사라지는 속도 = BPM에 비례함")]
    [SerializeField] private float Notedeletespeed;
    [SerializeField] private float Notedeletevalue;
    private NoteObjectPool pool;
    private Coroutine noteLife_coroutine;

    public void SetPool(NoteObjectPool pool) => this.pool = pool;

    public void SetLifeByBpm(float bpm)
    {
        Notedeletespeed = bpm * Notedeletevalue;
        if(gameObject.activeInHierarchy)
        {
            if (noteLife_coroutine != null) StopCoroutine(noteLife_coroutine);
            noteLife_coroutine = StartCoroutine(NoteReturn(Notedeletespeed));
        }
    }

    void OnEnable()
    {
        var life = (Notedeletespeed > 0f) ? Notedeletespeed : 0.3f;
        noteLife_coroutine = StartCoroutine(NoteReturn(life));
    }

    void OnDisable()
    {
        if (noteLife_coroutine != null)
            StopCoroutine(noteLife_coroutine);
    }

    IEnumerator NoteReturn(float life)
    {
        yield return new WaitForSeconds(life);
        ReturnPool();
    }

    void ReturnPool()
    {
        if (pool != null)
        {
            pool.Return(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == CompareTag("NOTE"))
            Debug.Log("노트충돌일어남");
        else
            ReturnPool();
    }
}
