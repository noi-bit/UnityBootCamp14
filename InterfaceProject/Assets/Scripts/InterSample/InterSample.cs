using UnityEngine;

//인터페이스(interface)

//접근제한자 interface 인터페이스명
//{
//    메소드 선언;
//    속성;
//    이벤트;
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
//Sword는 Item입니다, Sword는 IWeapon으로 사용될 것입니다
//클래스는 Sword : Item, Love 이런 식으로 두가지 상속이 안됨
//인터페이스는 다중상속 가능(태그 같은느낌? 팜플렛? 중간다리 혹은 안내서)
public class Jabelin : Item, IWeapon, ICountable, IThrowable { }
//상속할 클래스를 먼저 붙이고, 그다음 인터페이스 좌르르륵
//인터페이스 안에는 기능(함수)은 없다

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
