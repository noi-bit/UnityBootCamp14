using UnityEngine;
// RayCast : ���� ��ġ���� Ư�� �������� ������ ������ ���� ��,
//          �ε����� ������Ʈ�� �ִ����� �Ǵ���
//  1. Ư�� ������Ʈ�� �浹 �������� �����ϴ� �۾� ����
//  2. Ư�� ������Ʈ�� ���� �浹 ������ Ȯ���ϴ� �뵵(�Ѿ˰���..)

public class RayCastSample : MonoBehaviour
{
    RaycastHit hit; // �浹 ������ ����

    // ref : ������ ������ ����, ������ �޼ҵ� �ȿ��� ����� �� ������ �˸��� �뵵
    // out : ������ ������ ����, ���� ���� ���� ������ ���� �ʱ�ȭ�� ������ �ʿ䰡 X

    // Physics.RayCast(Vector3 origin, Vector3 direction, out RayCastHit hitinfo,
    // float maxDistance, int layerMask);                 ��>out: ������ ������ ���޵Ǵ°�
    // �� ��ҵ��� �� ����, �� �� ���� ����(�����ε�)

    // origin�� ���⿡�� direction �������� maxDistance ������ ������ �߻���
    // layerMask : tag���� ���� ū �Ž��� ������ �з�(�׷쿡 ���� �ĺ�)
    // tag       : ���� ������Ʈ �з�
    // hitinfo   : �浹ü�� ���� ����

    const float length = 20.0f; // ���� ���� ��� (���� ���� 5 -> 20)

    private void Start() // �ѹ��� �浹 ������ ó��
    {
        #region //����ĳ��Ʈ�� start�� �ѹ��� ��� �浹�ϴ� �ڵ�
        // �� �׸���
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        // ���̾��ũ �����ϱ�
        int ignoreLayer = LayerMask.NameToLayer("Red");
        int layerMask = ~(1 << ignoreLayer);

        // �浹ü ����
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, length, layerMask);

        // �ݺ������� �ݶ��̴� üũ
        for(int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.name + "�� �߽��ϴ�.");
            hits[i].collider.gameObject.SetActive(false);
            // hits �迭�� i��° ���� �浹ü�� ���� ���� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        }
        #endregion

    }
    //void Update()
    //{
    #region �� �տ� �浹�ϸ� �浹 ���� �ڵ�
    //    Debug.DrawRay(transform.position, transform.forward * length, Color.red);

    //    // 1. �浹��Ű�� ���� ���� ���̾ ���� ���� ����("Red"��� �̸��� ���� ���̾ ���� ������ ����)
    //    int ignoreLayer = LayerMask.NameToLayer("Red"); // �浹��Ű�� ���� ���� ���̾�
    //    // 2. ~(1<<LayerMask.NameToLayer("Red")) - �ش� ���̾�("Red") "�̿���" ��
    //    int layerMask = ~(1 << ignoreLayer); //��Ʈ����
    //                                         // �츮�� ������ ���̾ ������ ���̾���� �����Ŵ

    //    //{// ex) ���� Red ���̾�� Blue ���̾� �� �� �����ϰ� ���� ���?
    //    //int ignoreLayers = (1 << LayerMask.NameToLayer("Red")) | (1 << LayerMask.NameToLayer("BLUE"));
    //    //int layerMasks = ~ignoreLayers;
    //    //}

    //    // ���콺 ��Ŭ���� ����ĳ��Ʈ �߻�
    //    //if (Input.GetMouseButtonDown(1))
    //    //{                 // Vector3 origin, Vector3 direction, out �浹���� ����, float maxDistance
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, length, layerMask))
    //    {
    //        Debug.Log("�߻��մϴ�!");
    //        Debug.Log(hit.collider.name);
    //        hit.collider.gameObject.SetActive(false); // ���̸� ������ ���� ������Ʈ�� ����

    //        // ���̾��ũ�� ��Ʈ ����ũ�̸�, �� ��Ʈ�� �ϳ��� ���̾ �ǹ�
    //        // 1<< n �� n��° ���̾ �����ϴ� ����ũ�� �ǹ�
    //        // "~" �� ���� �ۼ��� ~(1<<n) �� �ش� ���̾� n �� ������ ��� ���̾ �ǹ�
    //    }
    //    //}
    //    // ������Ʈ�� ��ġ���� �������� length��ŭ�� ���̿� �ش��ϴ� ����� ������ ��� �ڵ�
    //    // �ַ� ����ĳ��Ʈ �۾����� ������ �Ⱥ��̱� ������ �����ִ� �뵵�� ���
    #endregion
    //}
}
