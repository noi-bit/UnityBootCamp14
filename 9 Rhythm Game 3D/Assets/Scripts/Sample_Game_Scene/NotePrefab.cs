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

    // [�߰�] ť�갡 ������ DSP �ð�
                        private double _cubeSpawnDspTime; // ť�갡 ������ ������ DSP �ð�
    // [�߰�] ���� Ÿ�̹� DSP ���ذ�
                        private double _targetDspTime; // �� ť�갡 �ִ� ũ�Ⱑ �Ǿ�� �ϴ� DSP �ð�

    private void Awake()
    {
        mr = this.GetComponent<Renderer>();
    }

    //--> ���⼭ ���� Ÿ�̹� DSP���� ���� DSP�� �޾ƿ;� ��
    //������ finalSize�� Speed�� �־���
    public void NoteSizeUp(Vector3 finalcubesize, float Speed, double cubeSpawnDspTime, double targetDspTime)
    {
        //_targetDspTime = targetDspTime; // ���� Ÿ�̹� DSP ���ذ�
        //_cubeSpawnDspTime = cubeSpawnDspTime; // ť�� ���� DSP ���ذ�

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
