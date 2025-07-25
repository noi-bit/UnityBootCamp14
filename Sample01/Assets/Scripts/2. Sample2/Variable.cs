using System;
using UnityEngine;
//이 파일은 인스펙터에서 변수에 대한 표현을 확인하는 코드로 사용

public enum TYPE //enum : 열거형 , 상수를 이름을 붙혀 작성하는 기능
{
    불,물,풀
}

//Flag : 여러 개를 선택하는 기능
//값을 2의 제곱수로 넣어줘야 Flag가 작동함
//2의 제곱수는 비트 연산으로 표현하기가 쉽습니다 n<<1 이면 n, n<<2면 n의 2제곱
[Flags] //enum에서 Flag가 붙으면 이진법으로 계산이 된다
public enum TYPE2
{
    독 = 1 <<0, 
    고스트 = 1<<1, //1에서 1칸 이동하겠습니다.(비트 연산)
    드래곤 = 1<<2,
    얼음 = 1<<3,
    융 //독 과 얼음이 나오는데 그것들과의 상관관계는??, 만약 고스트와 드래곤을 하고싶으면?
}

public class Variable : MonoBehaviour
{
    //정수(int/uint - int : +-양수,음수 합한 범위 ,uint : 양수 범위만 의미)

    //유니티/C# 기본 데이터 타입(primitive)
    //정수(int)
    //실수(float)
    //논리(bool)
    //문자열(string)
    //널 값 허용(nullable) - null은 "값이 없음" 을 나타내는 값(0이나 empty("")와 다른 개념)
    //자료형? 로 작성하면 해당 값은 null값을 사용할 수 있음
    public int Integer; //(public int? Integer = null; / 자료형 앞에 ?를 붙이면 null값을 사용 가능)
    public float Float;
    public string Sentence;
    public bool isDead;
    public TYPE type;
    public TYPE2 type2;
}
