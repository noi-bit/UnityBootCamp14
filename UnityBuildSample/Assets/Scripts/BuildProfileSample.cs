using UnityEngine;


public class BuildProfileSample : MonoBehaviour
{
    void Start()
    {
#if CUSTOM_DEBUG_MODE
        //if (!Application.isPlaying) {
        Debug.Log("����� ��忡�� �������� ����Դϴ�.");
#elif CUSTOM_RELEASE_MODE //���� ������ �����Ѵٸ� �̰��� ����� ��Ȱ��ȭ ����
        Debug.Log("������ ��忡�� ���� ���� ����Դϴ�.");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}