using UnityEngine;

//�����͸�� ���¿��� Update, OnEnable, OnDisable�� ������ ������ �� �ִ�
//Play�� ������ �ʾƵ� Editor ������ Update � ������ ��ɵ��� ������ �� �� �ִ�
//[ExecuteInEditMode]
public class EditMenuSample : MonoBehaviour
{
    void Update()
    {
        //�����Ϳ����� �����غ��� �ڵ�(���� �÷��̿����� �����Ҽ� ����)
        //������ �׽�Ʈ�ؾ��ϴ� ��Ȳ�� �� ����Ҽ� ������?
        if(!Application.isPlaying)
        {
            Vector3 pos = transform.position;//�� ��ũ��Ʈ�� �� ������Ʈ�� transform.position
            pos.y = 0;
            transform.position = pos;

            Debug.Log("Editor Test...(�� ��ũ��Ʈ�� �� ������Ʈ�� y���� 0���� �����˴ϴ�.)");
        }
    }
}
