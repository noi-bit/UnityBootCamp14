using a;
using UnityEngine;
//A. 유니티 엔진 관련 기능을 사용하겠습니다.(네임스페이스 유니티엔진)
//해당코드 내에서 사용되는 특정 기능들은 unityengine 네임스페이스의 기능으로 해석됨.

//네임스페이스는 특정 데이터를 묶어주는 용도로 사용할 수 있다.(이름 충돌 문제를 해결)
//목적 : 분류
namespace a
{
    public class Item
    {
        public int id;
    }
}
namespace b
{
    public class Item
    {
        public Item id2;
    }
}
//네임스페이스 사용 방법
//1. 네임스페이스, 클래스명과 같이 네임스페이스를 직접 작성해서 사용하는 경우
//2. using 을 이용해(맨 위) 해당 코드 내에서 사용하는 값은 그 네임스페이스의 값임을 알리고 사용하는 경우

//B. 클래스의 이름은 BasicScript, 이 스크립트는 MonoBehaviour 의 기능을 포함하고있습니다.(C#의 상속)
//스크립트의 이름과 같은 class가 반드시 존재해야 합니다.
//MonoBehaviour 클래스는 에디터에서 게임 오브젝트에 스크립트를 컴포넌트로써 연결할 수 있는 프레임워크를 제공한다.
//Start, Update와 같은 이벤트에 대한 연결도 제공
public class BasicScript : MonoBehaviour
{

//C. 유니티 생명주기(이벤트)
//유니티에서는 스크립트를 실행할 경우 사전에 지정한 순서대로 여러 개의 이벤트 함수가 실행된다.
//사용자는 해당 이벤트함수에 기능을 작성하는 것으로 원하는 상황에 맞는 작업을 처리할 수 있다.

    void Start()
    {
        Item item = new Item();//using A에 의해 이 Item 자동으로 네임스페이스 A의 아이템을 의미하게 된다.
        b.Item item2 = new b.Item();//네임스페이스를 앞에 .으로 붙혀줘서 작성함으로써, 해당 위치의 Item임을 표현.
    }

    void Update()
    {
        
    }
}
