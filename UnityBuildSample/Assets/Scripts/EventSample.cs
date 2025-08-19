using UnityEngine;
using System; //event ����� ���ؼ� System ���ӽ����̽��� ����ؾ� ��

//c#�� Event ����

//Ŭ���̳� ��ġ�� ���� ������ ó���ϴ� �ϳ��� �ý���

//������(Publisher)
//��> ������� �ൿ�� ��ٸ��� �����ڿ��� �˷��ִ� ������ ����

//������(Subscribers)
//��> �̺�Ʈ �����ڿ� ���� ������ ���� ������� �ൿ�� ���޹޾� �����ϴ� ����

//�ر������� ���, �������� �ൿ ��ü�� �����ڰ� �˾ƾ� �� �ʿ�� ���� ����(���ó�� �����ִ� ������ �ƴϴ�)
//���������� ��� ���к��ϰ� ������ ��� ���� �����ڵ��� ����� ����� �� ����

public class EventSample : MonoBehaviour
{
    public event EventHandler OnSpaceEnter;
    //�̺�Ʈ ������ �̸��� ���� On + ���� / ������ ��������ϴ�

    //c#���� �������ִ� delegateŸ��
    //EventHandler�� ��� ��ġ�� Ŭ�� ���� �̺�Ʈ�� �����ϴ� �뵵
    //EventHandler �� �޴� �Ű����� (EventHandler(Object sender, EventArgs e)
    //��1. Object sender <- object Ÿ���� �����͸� ���޹��� �� ������,(��� Ŭ������ object�� ��ӹ޴´� var��������?)
    //                      �̺�Ʈ�� �߻���Ų ����� �ǹ��մϴ�.
    //��2. EventArgs e   <- �̺�Ʈ�� ���õ� �����͸� ��� �ִ� ��ü�� �ǹ��մϴ�.
    //                      �ش� ���� EventArgs �Ǵ� �ش� �ڽ� Ŭ������ �� �� �ֽ��ϴ�.


    private void Start()
    {
        //���� ���
        //Event �̸� += ���¿� �´� �޼ҵ� �̸�;
        OnSpaceEnter += Debug_OnSpaceEnter;
    }

    void Update()
    {
    //�̺�Ʈ ���� ��� 1. �̺�Ʈ��(this, EventArgs.Empty)
        if(Input.GetKeyDown(KeyCode.Space)) //�����̽� ��ư Ŭ��
        {
            if(OnSpaceEnter != null) //null�˻縦 �����ϰ� ����(�̺�Ʈ ������ �ȵǾ����� ��쿡�� �����ϸ� �ȵǱ� �����̴�)
            {                        //Ȥ�ø� ��Ȳ�� ����� null�˻� ����
                OnSpaceEnter(this, EventArgs.Empty);
                // this : �̺�Ʈ�� �߻���Ų ��ü(���� Ŭ����)
                // EventArgs.Empty : �̺�Ʈ ���࿡ �־� Ư���� �߰��Ǵ� �����Ͱ� ����(default ó�� �۵���)
            }
            //else ���� �߰��ϰ� ���� ��쿡�� if���� ���� ����(�ƴϸ� ~?.~)
        }
    //�̺�Ʈ ���� ��� 2. Invoke �Լ��� ����ϴ� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
           OnSpaceEnter?.Invoke(this, EventArgs.Empty);
            //or --> OnSpaceEnter?.Invoke(OnSpaceEnter, EventArgs.Empty);
            //OnSpaceEnter"?". ����ǥ�� ���� null �� �ƴ� �� ó���ǵ��� �Ѵ�

            // ~?  ) int?�� ���� �ڷ����� ?�� ���̰� nullable �� Ÿ������ ����ϴ� ���,
            //    ������������ null���� ���� �� �ְ� ���� --(T?)
            //---> Ÿ���� ������ �� ���˴ϴ�, �� ������ Ÿ�Կ� ���˴ϴ�.

            // ~?. ) null ���� �����ڷ� ���Ǵ� ���
            //     ��ü�� null �� �ƴ� ���� ����� ���� ȣ���� �����ϵ��� ����
            //---> �޼ҵ�(Method), �Ӽ�(Property), �̺�Ʈ(Event)���� ȣ�� �ÿ� ����
            //     ���۷��� ������ �۾� �Ǵ� nullable ��ü�� ������� ���
            // ex. Sample s = new Sample();
            //     s?.Method();
            //     ��> s�� null�� �ƴ� ��쿡�� Method�� ȣ����
            //     ��> null�̶��? ������(����, nullreference X)

            //>> if(obj != null) ������ �ڵ� ��� ���
        }
    }

    private void Debug_OnSpaceEnter(object sender, EventArgs e)
    {
        Debug.Log("<color=yellow>���� Ű �Է� �̺�Ʈ ����</color>");
    }

}
