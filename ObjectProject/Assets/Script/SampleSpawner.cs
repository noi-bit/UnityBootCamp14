using UnityEngine;
// 2번째 스크립트

public class SampleSpawner : MonoBehaviour
{
    // 해당 오브젝트가 없을 때 오브젝트를 새로 생성하고, 컴포넌트를 부여한다
    void Start()
    {
        GameObject sample = GameObject.Find("Sample"); // sample 게임오브젝트르 Sample 을 찾는다

        if(sample == null) // 오브젝트 탐색 결과가 없을 경우
        {
            GameObject go = new GameObject("Sample");
            go.AddComponent<Sample>();
        }
        else
        {
            Debug.Log("이미 존재합니다.");
        }
    }

}
