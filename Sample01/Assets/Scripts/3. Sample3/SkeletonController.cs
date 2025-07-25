using UnityEngine;
//버튼의 OnClick에 등록할 기능

public class SkeletonController : MonoBehaviour
{
    public GameObject skeleton;//스켈레톤 오브젝트를 여기로 드래그해서 연결할수있음
    /* public void 메소드명()
      {
           이 메소드를 실행할 경우 실행할 명령문을 작성하는 위치
      }*/
    public void LButtonEnter()//밖에서 쓸꺼니까 public, void - 기능만 수행하고싶을때(일반 자료형)
    {
        skeleton.transform.Translate(1, 0, 0);//transform.Translate(-1,0,0)그냥 이대로 하면 버튼이 움직인다
    }

    public void RButtonEnter()
    {
        skeleton.transform.Translate(-1, 0, 0);//버튼을 누르면 변수 skeleton에 입력된 오브젝트가 좌표대로 움직인다
    }
}
