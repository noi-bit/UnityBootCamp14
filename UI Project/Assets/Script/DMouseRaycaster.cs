using UnityEngine;

public class DMouseRaycaster : MonoBehaviour
{
    private Camera cam;
    public float distance = 10.0f; //�浹 ��������
    public LayerMask layerMask;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))//��Ŭ
        {
            Ray ray = cam.ScreenPointToRay( Input.mousePosition ); //��ũ�� ���콺 Ŭ������ üũ

            if(Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
            {
                //Ʈ���� üũ
                var trigger = hit.collider.GetComponent<DTrigger>();

                if(trigger != null )
                {
                    //Ʈ���Ÿ� ���� ���̾�α� ���� �ڵ� �ۼ�
                    trigger.OnDTriggerEnter();
                }
            }
        }
    }
}
