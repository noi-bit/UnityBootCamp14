using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NotePrefab : MonoBehaviour //프리팹에 붙인다
{
    Renderer mr;
    public AudioSource crushSound;
    public Material original;
    public Material target;
    private NoteObjectPool pool;
    private Coroutine noteLife_coroutine;
    private Coroutine noteCreate_coroutine;

    public void SetPool(NoteObjectPool pool) => this.pool = pool;

    //점수로직
    public bool noteReturnOn = false;
    SongController SC;
    ScoreJudgeManger SJ;
    PADcontroller PC;
    //점수로직

    private void Start()
    {
        mr = this.GetComponent<Renderer>();
        if (SC == null)
            SC = FindFirstObjectByType<SongController>();
        if (SJ == null)
            SJ = FindFirstObjectByType<ScoreJudgeManger>();
        if (PC == null)
            PC = FindFirstObjectByType<PADcontroller>();
    }


    public void NoteSizeUp(Vector3 finalcubesize, float duration)
    {

        if (gameObject.activeInHierarchy)
        {
            if(noteCreate_coroutine != null) StopCoroutine(noteCreate_coroutine);
            noteCreate_coroutine = StartCoroutine(NoteSizeChange(finalcubesize, duration));
            if (noteLife_coroutine != null) StopCoroutine(noteLife_coroutine);
            noteLife_coroutine = StartCoroutine(NoteMissCheck(duration * 1.4f));
        }
    }

    IEnumerator NoteMissCheck(float life)
    {
        yield return new WaitForSeconds(life);
        NoteDie();
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
                        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PAD"))
        {
            //crushSound.PlayOneShot(crushSound.clip);

            double hitSec = (SC != null) ? SC.nowDspTime : 0.0;
            if(SC != null)
            {
                var(notemode, errorMs) = SJ.EvaluateHit(hitSec);
                PC.NoteHitTiming(notemode);
            }
            ReturnPool();
        }
    }

    void NoteDie()
    {
        ReturnPool();
        PC.NoteHitTiming(EnumData.NotePressMode.Miss);
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
