using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NotePrefab : MonoBehaviour //�����տ� ���δ�
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

    

    private void Awake()
    {
        mr = this.GetComponent<Renderer>();
    }


    public void NoteSizeUp(Vector3 finalcubesize, float duration)
    {
        //_targetDspTime = targetDspTime; // ���� Ÿ�̹� DSP ���ذ�
        //_cubeSpawnDspTime = cubeSpawnDspTime; // ť�� ���� DSP ���ذ�

        if (gameObject.activeInHierarchy)
        {
            if(noteCreate_coroutine != null) StopCoroutine(noteCreate_coroutine);
            noteCreate_coroutine = StartCoroutine(NoteSizeChange(finalcubesize, duration));
        }
    }

    IEnumerator NoteSizeChange(Vector3 finalcubesize, float duration)
    {
        float t = 0f;
        Vector3 startScale = Vector3.zero;

        if(duration<=0)
        {
            transform.localScale = finalcubesize;
            yield break;
        }
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, finalcubesize, t/ duration);
            if(t >= duration * 0.9f)
            {
                mr.material = target;
            }
            yield return null;
        }
        transform.localScale = finalcubesize;
                        //mr.material = target;
    }

    public void SetLifeByBpm(float bpm) //NoteController ���� ȣ��
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
            Debug.Log("��Ʈ�浹�Ͼ");
            /*���� ì! �ϰ� �Ҹ� �ֱ�*/
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
