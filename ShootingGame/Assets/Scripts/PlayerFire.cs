using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Bullet Fire")]
    [Tooltip("�Ѿ� ���� ����")]public GameObject bulletFactory;
    [Tooltip("�ѱ�(�߻�)")]public GameObject firePosition;

    private void Update()
    {
        //GetKeyXXX : KeyCode�� ��ϵǾ��ִ� Ű �Է�
        //GetButtonXXX : Axes Ű�� ���� �Է�
        //GetMouseButtonXXX : ���콺 Ŭ�� ����
        if(Input.GetButtonDown("Fire1")) //Fire1�̶�� ��ư�� ������ ��
        {
            //�Ѿ��� �Ѿ˻������ ���� ����� �Ѿ��� ����
            //�Ѿ��� ��ġ�� �ѱ� �������� ����
            //������ ȸ�� X
            var bullet = Instantiate(bulletFactory, firePosition.transform.position, Quaternion.identity); //bullet����(bulletFactory)
        }
    }
}
