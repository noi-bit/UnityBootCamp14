using UnityEngine;
// 카메라 기준으로 마우스 클릭 위치에 레이캐스트 처리 (FPS 에임 느낌?)

public class CameraRayCastSample : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
         // Ray ray = new Ray(위치, 방향);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                // 카메라에서 사용할 Ray를 따로 설정해야함
                // ※ 카메라와 세트니 기억해놓자자 ※
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 1.
                Debug.Log("넌 이제 노란색이 되었어!");
                hit.collider.GetComponent<Renderer>().material.color = Color.yellow;

                // 2. 충돌체 오브젝트에 대한 정보
                var hitObject = hit.collider.gameObject;

                // 3. change_layer로 layer가 노란색으로 바뀌는 변수
                int change_layer = LayerMask.NameToLayer("Yellow");

                // 4. 레이어가 유효한 값일 경우(레이어는 비트레이어니까 -가 들어갈 일이 없다)
                if (change_layer != -1) 
                {   // 5. 충돌한오브젝트.레이어 = 체인지 레이어 변수로 노란색으로 바뀌게 한다
                    hitObject.layer = change_layer;
                }
            }
        }
    }
}
