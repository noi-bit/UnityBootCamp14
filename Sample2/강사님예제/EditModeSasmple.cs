using UnityEngine;

//������ ��� ���¿��� Update, OnEnable, OnDisable�� ������ ������ �� �ֽ��ϴ�.
//Play�� ������ �ʾƵ� Editor ������ Update � ������ ��ɵ��� �����غ� �� �ֽ��ϴ�.
//[ExecuteInEditMode]
public class EditModeSasmple : MonoBehaviour
{

    void Update()
    {
        //�����Ϳ����� �����غ��� �ڵ�
        if (!Application.isPlaying)
        {
            Vector3 pos = transform.position;
            pos.y = 0;
            transform.position = pos;
            Debug.Log("Editor Test...(�� ��ũ��Ʈ�� �� ������Ʈ�� y���� 0���� �����˴ϴ�.)");
        }
    }
}
