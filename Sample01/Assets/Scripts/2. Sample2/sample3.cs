using UnityEngine;
//유니티에서 제공되는 클래스를 사용해 스크립트를 작성합니다.

/*1. 유니티의 Transform 클래스 사용
트랜스폼은 유니티 에디터에서 게임 오브젝트를 생성할 때, 모든 게임 오브젝트에
기본적으로 부여되는 컴포넌트를 의미합니다.
해당 오브젝트의 위치(Position), 회전(Roatation), 크기(Scale)에 대한 정보를 가지고있습니다.
*컴포넌트의 기능을 호출하는 GetComponent<T>를 사용하지 않고 바로 사용이 가능합니다.
(모든 오브젝트에 존재하기 때문에)*/

//해당 클래스가 제공해주는 주요 속성(Property)
/*transform.position - 현재 오브젝트의 위치 정보를 의미합니다.
Vector3 형태의 데이터, x,y,z축은 각각 float(실수로 표현 가능)*/

/*transform.rotation - 현재 오브젝트의 회전 정보를 의미합니다.(좀더 부드럽게 회전)
Quaternion 형태의 데이터, x,y,z와 w 4개의 축 사용 - float 형태*/

/*transform.eulerAngles - 현재 오브젝트의 회전정보 를 의미합니다
Vector3 형태의 데이터, x,y,z 3개의 축만 사용 - float 형태*/

/*transform.forward - 현재 오브젝트 기준의 "전방"을 나타내는 값*/

/*transform.up - 현재 오브젝트 기준의 "상단"을 나타내는 값*/

/*transform.right - 현재 오브젝트 기준의 "오른쪽"을 나타내는 값*/


//*TIP : 메소드 "()" 안에 작성된 변수는 해당 기능을 수행할 떄 전달해줄 값에 대한 표현 -- parameter(파라미터)
/*해당 클래스가 제공해주는 주요 문법(메소드)
transform.LookAt(Transform target) - 오브젝트를 주어진 타겟을 향하도록 오브젝트를 회전시키는 기능
transform.Rotate(Vector3 eulerAngles) - 전달받은 각도를 기준으로 게임 오브젝트를 회전시키는 기능(Vector 3)
transform.Translate(Vector3 translation) - 주어진 값만큼 게임 오브젝트를 이동시키는 기능*/

public class sample3 : MonoBehaviour
{
    //transform을 이용한 오브젝트의 컴포넌트 접근
    public GameObject go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(go.transform.GetComponent<sample4>().value);//go.GetComponent<Sample4>().value 로 사용도 가능
        //모든 오브젝트에는 무조건 transform이 있기 때문에
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
