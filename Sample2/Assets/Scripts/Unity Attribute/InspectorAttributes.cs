using System.Collections.Generic; //C#에서 제공해주는 자료구조(List<T>, dictionary<K,V> 같은 값) 사용 가능
using System;
using UnityEngine;

public class InspectorAttributes : MonoBehaviour
{
    [System.Serializable]
    public struct BOOK //사용자 정의 타입 / Value 타입 / GC 필요 없음(작은 데이터의 묶음을 자주 할당/복사하는 개념으로 활용 ex) Vector3)
    {                  //거의 최적화를 위해 사용된다
        public string name;
        public string description;
    }

    [Serializable]
    public class Item // 객체를 위한 설계도(속성(변수들)과 기능(동작)을 포함) / 유니티에서는 class 사용 권장, 안정성이 더 높다
    {                 // 복사 과정에서의 실수 발생 가능성 X
        public string name;
        public string description;
    }
    
    [Header("Score")]
    public int point;
    public int max_point;
    [Header("Information")]
    public string nickname;
    public Job myjob;

    //인스펙터에 공개하기 싫은 값에 대한 설정
    [HideInInspector]
    public int value = 5;

    //*직렬화(Serialization) : 데이터를 저장 가능한 형식으로 변화하는 작업
    //이 변환을 통해 씬, 프리펩, 에셋 등에 저장하고 복원하는 작업을 수행할 수 있다

    //public                        --> 노출 + 접근 가능
    //private                       --> 노출 X 접근 X
    //[SerializeField] + private    --> 노출 X, but 인스펙터에서는 접근 가능
    
    //직렬화 조건
    //1. public or [SerializeField]
    //2. static이 아닌 경우(static이 붙으면 그 자체로 외부에서 접근가능 - new로 불러오지 않고 바로 사용가능)(이미 외부에서 접근/사용이 가능하기에 직렬화할 필요가X)
    //2-1.  static(퍼진다) - 스태틱의 검(번개가 퍼지는..ㅋㅋ) 이미지로 생각하자
    //3. 직렬화 "가능한" 타입인 경우
    //3-1.  직렬화 불가능한 데이터
    //      a. Dictionary<K,V> (비밀번호? 보안적인 코드)
    //      b. Interface (인터페이스, 클래스보다 한단계 위)(미완성 데이터)
    //      c. static 키워드가 붙은 필드
    //      d. abstract 키워드가 붙은 클래스
    //3-2. 직렬화 가능한 데이터
    //      a. 기본 데이터(int, float, bool, string...)
    //      b. 유니티에서 제공해주는 구조체(Vector3, Quaternion, Color)
    //      c. 유니티 객체 참조(GameObject, Transform, Material)
    //      d. [Serializable] 속성이 붙은 클래스
    //      e. 배열/리스트
    [SerializeField]//데이터에 접근할 수 있도록 직렬화한다, 유니티에서 비공개(private) 필드를 인스펙터에 노출시키고 유니티의 직렬화 시스템에 포함시킴
    //private int value2 = 7;


    //Space(높이) : 적은 높이만큼 간격이 생김
    //[TextArea]문자열이 장문일 경우 유용한 속성, [TextArea]만 등록할 경우 여러 줄 입력이 가능한 상태가 됩니다.
    //[TextArea(기본 표시 줄, 최대 줄)]괄호를 붙히면 최대, 최소를 정할 수 있다
    //문자열 길이에 대한 제한적인 부분은 없다
    [Space(30)][TextArea(3,5)]
    public string quest_info;

    public BOOK book;
    public Item item;

    //유니티 인스펙터에서는 배열도 리스트로 나오게 됩니다
    //리스트<T>는 T 형태의 데이터를 묶음으로 순차적으로 저장할 수 있는 데이터입니다
    //데이터의 검색, 추가, 삭제 등의 기능이 제공됩니다
    //<Item> 안에 배열도 넣을수 있다 
    //데이터를 많이 쓸때 유용하다(묶음으로 관리 가능)
    public List<Item> item_list;
    public BOOK[] books = new BOOK[5];//start에 넣으면 다섯개의 비어있는 칸이 생성되는거임
    //List<>와 배열은 유니티 에디터 안에서 똑같이 취급된다


    //직업 : 전사, 도적, 궁수, 마법사
    public enum Job//클래스 외부에 public enum Job으로 public을 붙혀서 만들수 있음 - 그러면 외부에서도 접근 가능
    {
        전사,
        도적,
        궁수,
        마법사
    }

    //[Range(최소,최대)] 를 통해 해당 값을 에디터에서 최소값과 최대값이 설정되어있는 스크롤 형태의 값으로 변경됨(실제로 범위 제한)
    [Range(0,100)]public int bg;
    [Range(0,100)]public float sfx;

}
