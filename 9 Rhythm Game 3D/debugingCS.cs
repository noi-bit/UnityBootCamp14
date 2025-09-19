using UnityEngine;

public class NotePrefab2 : MonoBehaviour
{
    // ... 기존 변수들 ...
    private float Notedeletespeed;//0
    public float Notedeletevalue = 0.003f;//0
    private NoteObjectPool pool;//0
    private Coroutine noteLife_coroutine;//0
    private Coroutine noteCreate_coroutine;//0
    public void SetPool(NoteObjectPool pool) => this.pool = pool;//0


    // [추가] 큐브가 생성된 DSP 시각
    private double _cubeSpawnDspTime; // 큐브가 실제로 생성된 DSP 시각
    // [추가] 박자 타이밍 DSP 기준값
    private double _targetDspTime; // 이 큐브가 최대 크기가 되어야 하는 DSP 시각


    private void Awake()
    {
        mr = this.GetComponent<Renderer>();
    }

    // [변경] NoteSizeUp에서 박자 타이밍 DSP값과 현재 DSP값을 받아옴
    public void NoteSizeUp(Vector3 finalcubesize, float Speed, double targetDspTime, double cubeSpawnDspTime)
    {
        //_targetDspTime = targetDspTime; // 박자 타이밍 DSP 기준값
        //_cubeSpawnDspTime = cubeSpawnDspTime; // 큐브 생성 DSP 기준값

        if (gameObject.activeInHierarchy)
        {
            if (noteCreate_coroutine != null) StopCoroutine(noteCreate_coroutine);
            noteCreate_coroutine = StartCoroutine(NoteSizeChange(finalcubesize, Speed));
        }
    }

    IEnumerator NoteSizeChange(Vector3 finalcubesize, float Speed)
    {
        // [추가] 실제 크기 변화에 사용할 시간 계산
        float _growDuration = (float)(_targetDspTime - _cubeSpawnDspTime); // 박자 타이밍까지 남은 시간(초)
        if (_growDuration <= 0f) _growDuration = 0.01f; // 음수 방지

        transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
        mr.material = original;
        float t = 0f;
        while (t < _growDuration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(new Vector3(0.1f, 0.5f, 0.1f), finalcubesize, t / _growDuration);
            if (t >= _growDuration * 0.7f)
            {
                mr.material = target;
            }
            yield return null;
        }
        transform.localScale = finalcubesize;
        mr.material = target;
    }

    // ... 나머지 기존 코드 ...
}