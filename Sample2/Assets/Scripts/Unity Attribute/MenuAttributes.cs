using UnityEngine;
//Attribute : [AddComponentMenu(**)]ó�� Ŭ������ �Լ�, ���� �տ� �ٴ�[]���� Attribute(�Ӽ�)�̶�� ��
//�����Ϳ� ���� Ȯ���̳� ����� ���� �� ���ۿ��� �����Ǵ� ��ɵ�
//��� ���� : ����ڰ� �����͸� �� ����������, ���������� ����ϱ� ���ؼ�



//AddComponentMenu - ����Ƽ�� Componentâ���� ����Ҽ� �ְ� ��
//AddComponentMenu("�׷��̸�/����̸�")
//Editor�� Component�� �޴��� �߰��ϴ� ��� , �׷��� ���� ��� �׷��� �����Ǹ�, �ƴ� ��쿡�� ��ɸ� �����ȴ�
//���� ���� ���� ������ ���� ���� ������ ������ �ִ�
//1. !,@,#,$ �� ���� Ư�����ڰ� �� ��
//2. ����
//3. �빮��
//4. �ҹ���
[AddComponentMenu("00_Sample/AddComponentMenu")]
public class MenuAttributes : MonoBehaviour
{
    //�Լ��� �̸� ��ü�� �Լ��� ������ �� �ִ�
    //[ContextMenuItem("������� ǥ���� �̸�", "�Լ��� �̸�")]
    //message�� ������� MessageReset ����� �����Ϳ��� ����� �� �ִ�
    [ContextMenuItem("�޼����ʱ�ȭ","MessageReset")]//������Ʈ ������ ���� �����ϱ� ����
    public string message = "�ȳ��ϼ���!";//static(ó���� ������Ʈ ����Ǿ��� �� �����)
    
    public void MessageReset()
    {
        message = "�ȵ�";
        
    }

   
    [ContextMenu("��� �޼��� ȣ��")]//������Ʈ �̸� - ��Ŭ������ ���� ����
    public void MenuAttribute()//������ ���� public ������
    {
        Debug.LogWarning("��� �޼���!");
    }

    [ContextMenu("�Ϳ��� �޼��� ȣ��")]
    public void CuteMessage()//������ ���� public ������
    {
        Debug.LogWarning("�ʹ� �Ϳ���!! > <");
    }

}
