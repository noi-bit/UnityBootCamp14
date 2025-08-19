using UnityEngine;

//목표 : 일정 시간마다 적을 생성해 내 위치에 놓을 것
//필요한 데이터 : 일정 시간, 현재 시간, 적 생성공장
//작업 순서 : 시간체크 - 현재시간>시간체크 시간(쿨타임) - 적 생성
public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyFactory; //적 생성공장
    public GameObject spawnArea; //생성 지역(배열)

    public float min =1, max =5; //소환 시간 간격
    public float currentTime; //현재 시간
    public float createTime = 1; //쿨타임

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime> createTime)
        {
            var enemy = Instantiate(EnemyFactory, spawnArea.transform.position, Quaternion.identity);
            //현재의 매니저 - 적 소환 지점(spawn area)에 생성을 진행할 것으로,
            //따로 위치나 회전 값 제공 X

            //지점이 따로 설정되어 있다면 지점 위치에 생성한다.
            
            
            currentTime = 0; //현재시간 설정 리셋해 다시 쿨타임이 넘어가면(조건문 체크) 적을 생성할 수 있게 한다
            createTime = Random.Range(min,max); //쿨타임이 1~4의 값이 된다
        }
    }
}
