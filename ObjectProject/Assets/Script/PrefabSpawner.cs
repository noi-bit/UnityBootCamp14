using UnityEngine;
// 8월 4일 1번째 스크립트

// 1. 프리팹을 직접 등록하다
// 2. 생성된 오브젝트에 대한 정보를 내부에서 가진다
// 3. 생성 후에 파괴에 대한 딜레이 시간을 가진다

// 해당 스크립트를 가진 오브젝트가 실행되면, 생성을 진행하고 - 일정 시간 뒤에 파괴처리
// ※ 조건) 프리팹이 등록이 되어있을때, 해당 작업 수행. 아닐 경우 경고메세지 안내

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; //prefab같은경우는 Assets에 있기 때문에 드래그 드롭으로 불러오거나 경로지정해줘야 함
    private GameObject spawned; //prefab을 씬에 불러오면 생성될 오브젝트(프리팹 자체와는 다르다)
    public float delay = 3.0f;

    void Start()
    {
        if(prefab != null)
        {
            spawned = Instantiate(prefab);
            // 생성 코드 Instantiate()
            // 1. Instantiate(prefab); - 해당 프리팹의 정보에 맞게 위치와 회전 값 등이 설정되고 실행된다
            // 2. Instantiate(prefab,transform.position,Quaternion.identity);
            //      ㄴ> 해당 프리팹을 설정하고, 위치와 회전값의 정보대로 오브젝트의 위치와 회전 값을 설정
            //          (위치를 정할거면 회전값도 같이 넣어줘야 한다 - Quaternion.identity는 회전의 초기화)
            // 3. Instantiate(prefab,parent); - 오브젝트를 생성하고, 그 오브젝트를 전달한 오브젝트(위치)의
            //      ㄴ> 자식으로써 등록합니다.
            // 4. Instantiate(prefab, position, quaternion, parent);
            
            spawned.name = "생성된 오브젝트"; // 생성된 오브젝트의 이름을 변경하는 코드
            // spawned.AddComponent<Rigidbody>(); // 이름 변경후 생성된 오브젝트에 컴포넌트를 추가
            Debug.Log(spawned.name + "이 생성되었습니다!");
            Destroy(spawned, delay); // delay 시간 이후 오브젝트 파괴
        }
        else
        {
            Debug.LogWarning("등록된 프리팹이 없습니다!");
        }
    }

}
