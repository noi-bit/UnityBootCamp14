using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectPrefab;

    float spawnTime = 2.0f;//2초당 생성
    float time = 0.0f;//시간 체크용 변수

    /*시간을 따로 계산해서 변수로 저장하고, 그 변수가 스폰 타임보다 커지면
    오브젝트 생성 & 변수는 0으로 초기화*/

    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime;
        if(time>spawnTime)
        {
            GameObject go = Instantiate(ObjectPrefab);/*생성 메소드, go변수로써 오브젝트를 저장해 
                                                        새로 생성되는 오브젝트들의 값들을 수정할 수 있다*/
            time = 0.0f;

            int rand = Random.Range(-3, 4); //-3부터 3 사이의 값을 랜덤으로 가지게 됨
            go.transform.position = new Vector3(rand, 5, 5.033f);
            
        }
    }
}
