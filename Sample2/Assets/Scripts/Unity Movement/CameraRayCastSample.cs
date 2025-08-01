using UnityEngine;
// ī�޶� �������� ���콺 Ŭ�� ��ġ�� ����ĳ��Ʈ ó�� (FPS ���� ����?)

public class CameraRayCastSample : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
         // Ray ray = new Ray(��ġ, ����);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                // ī�޶󿡼� ����� Ray�� ���� �����ؾ���
                // �� ī�޶�� ��Ʈ�� ����س����� ��
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 1.
                Debug.Log("�� ���� ������� �Ǿ���!");
                hit.collider.GetComponent<Renderer>().material.color = Color.yellow;

                // 2. �浹ü ������Ʈ�� ���� ����
                var hitObject = hit.collider.gameObject;

                // 3. change_layer�� layer�� ��������� �ٲ�� ����
                int change_layer = LayerMask.NameToLayer("Yellow");

                // 4. ���̾ ��ȿ�� ���� ���(���̾�� ��Ʈ���̾�ϱ� -�� �� ���� ����)
                if (change_layer != -1) 
                {   // 5. �浹�ѿ�����Ʈ.���̾� = ü���� ���̾� ������ ��������� �ٲ�� �Ѵ�
                    hitObject.layer = change_layer;
                }
            }
        }
    }
}
