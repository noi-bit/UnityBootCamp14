using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;//gameobject가 정확히 누구인지 인스펙터에서 설정
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //카메라와 플레이어 거리 차이를 offset값으로 설정.
        offset = transform.position - player.transform.position;//현재 옵젝 - 플레이어(설정)의 위치
    }

    // Update is called once per frame, 렌더링 전에 호출되는 위치
   
    private void LateUpdate()//update에서 처리할 부분을 처리한 후에 호출되는 위치
    //카메라 작업에서 많이 사용됨(오브젝트 추적이 목적인 경우)
    {
        //카메라의 위치는 플레이어와의 일정 거리를 유지한다(offset)
        transform.position = player.transform.position + offset;
    }
}
