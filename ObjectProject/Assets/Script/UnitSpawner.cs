using UnityEngine;
using System.Collections;

//5번째 스크립트
//UnitMoveAI를 컴포넌트로 달고있는 오브젝트를 스폰함

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab; //등록한 프리팹만 생성할 수 있게 함(유닛 프리팹)
    public Transform spawnPoint; //스폰지점을 만들어줌(생성위치)
    public float interval = 5.0f; //유닛 생성 시간 간격

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn()
    {
        while (true)//무한생성
        {
            //유닛을 생성합니다
            //생성위치는 스폰포인트
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);

            //생성 간격만큼 대기합니다.
            yield return new WaitForSeconds(interval);

            //콘솔 메세지 호출
            Debug.Log($"{spawnPoint.name}에서 {unitPrefab.name} 유닛이 생성되었습니다.");
        }
    }
}
