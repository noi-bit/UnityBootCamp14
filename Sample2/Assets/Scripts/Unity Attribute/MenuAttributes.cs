using UnityEngine;
//Attribute : [AddComponentMenu(**)]처럼 클래스나 함수, 변수 앞에 붙는[]들을 Attribute(속성)이라고 함
//에디터에 대한 확장이나 사용자 정의 툴 제작에서 제공되는 기능들
//사용 목적 : 사용자가 에디터를 더 직관적으로, 편의적으로 사용하기 위해서



//AddComponentMenu - 유니티의 Component창에서 사용할수 있게 함
//AddComponentMenu("그룹이름/기능이름")
//Editor의 Component에 메뉴를 추가하는 기능 , 그룹을 적을 경우 그룹이 지정되며, 아닐 경우에는 기능만 지정된다
//순서 같은 경우는 다음과 같이 정렬 기준을 가지고 있다
//1. !,@,#,$ 와 같은 특수문자가 맨 앞
//2. 숫자
//3. 대문자
//4. 소문자
[AddComponentMenu("00_Sample/AddComponentMenu")]
public class MenuAttributes : MonoBehaviour
{
    //함수의 이름 자체로 함수에 접근할 수 있다
    //[ContextMenuItem("기능으로 표현할 이름", "함수의 이름")]
    //message를 대상으로 MessageReset 기능을 에디터에서 사용할 수 있다
    [ContextMenuItem("메세지초기화","MessageReset")]//컴포넌트 내에서 값을 조절하기 가능
    public string message = "안녕하세요!";//static(처음에 컴포넌트 실행되었을 때 띄워짐)
    
    public void MessageReset()
    {
        message = "안돼";
        
    }

   
    [ContextMenu("경고 메세지 호출")]//컴포넌트 이름 - 우클릭으로 적용 가능
    public void MenuAttribute()//접근을 위해 public 적어줌
    {
        Debug.LogWarning("경고 메세지!");
    }

    [ContextMenu("귀여운 메세지 호출")]
    public void CuteMessage()//접근을 위해 public 적어줌
    {
        Debug.LogWarning("너무 귀여워!! > <");
    }

}
