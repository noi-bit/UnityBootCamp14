using UnityEngine;

//�������̽�(interface)

//���������� interface �������̽���
//{
//    �޼ҵ� ����;
//    �Ӽ�;
//    �̺�Ʈ;
//}
public interface IThrowable
{

}

public interface IWeapon
{ 

}

public interface ICountable
{

}

public interface IPotion
{

}

public interface IUsable
{

}

public class Item
{

}

public class Sword : Item, IWeapon { }
//Sword�� Item�Դϴ�, Sword�� IWeapon���� ���� ���Դϴ�
//Ŭ������ Sword : Item, Love �̷� ������ �ΰ��� ����� �ȵ�
//�������̽��� ���߻�� ����(�±� ��������? ���÷�? �߰��ٸ� Ȥ�� �ȳ���)
public class Jabelin : Item, IWeapon, ICountable, IThrowable { }
//����� Ŭ������ ���� ���̰�, �״��� �������̽� �¸�����
//�������̽� �ȿ��� ���(�Լ�)�� ����

public class MaxPotion : Item, IPotion, ICountable, IUsable { }

public class FirePotion : Item, IPotion, IThrowable, ICountable, IUsable { }

public class InterSample : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
