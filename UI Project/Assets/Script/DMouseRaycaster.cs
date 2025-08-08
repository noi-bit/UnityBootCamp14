using UnityEngine;

public class DMouseRaycaster : MonoBehaviour
{
    private Camera cam;
    public float distance = 10.0f; //충돌 감지범위
    public LayerMask layerMask;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))//좌클
        {
            Ray ray = cam.ScreenPointToRay( Input.mousePosition ); //스크린 마우스 클릭지점 체크

            if(Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
            {
                //트리거 체크
                var trigger = hit.collider.GetComponent<DTrigger>();

                if(trigger != null )
                {
                    //트리거를 통한 다이얼로그 접근 코드 작성
                    trigger.OnDTriggerEnter();
                }
            }
        }
    }
}
