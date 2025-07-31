# 250728

### 유니티의 생명주기
> 유니티에서 사용되는 이벤트함수(생명주기) - 유니티에서는 프로그램의 실행부터 종료까지의 작업 명령을 함수로 제공합니다.
> 유니티에서는 스크립트의 실행, 활성화, 프레임 당 호출 등 상황에 맞게 작업할 수 있는 작업공간이 존재합니다.


```cs
using UnityEngine;
 private void Awake()
 {
     Debug.Log("[Awake]");
     Debug.Log("씬이 시작될 때 호출되는 영역입니다.");
     Debug.Log("해당 스크립트가 비활성화 되어있어도 이 위치의 작업은 실행됩니다.");
     Debug.Log(@"각 스크립트 기준 한 번만 호출이 되고, 다른 개체의 초기화가 안료 된 후
         호출되는 영역이기 때문에 다른 컴포넌트에 대한 참조를 만들어야 하는 경우 이 위치에서 만들면
         안전하게 처리됩니다.");
     Debug.Log("해당 영역에서 코루틴으로 실행이 불가능합니다.");
}
```
> **코루틴(Coroutine)** : 코드를 일시중지하고 특정 조건이 충족될 때까지 실행을 delay 시킬수 있는 기능(ex. 3초 뒤 오브젝트 파괴)


```cs
private void OnEnable() //반대의 개념은 OnDisable() - 이벤트에 대한 접속해제
{
    Debug.Log("[OnEnable])");
    Debug.Log("해당 위치는 오브젝트 또는 스크립트가 활성화 될 때 호출됩니다.");
    Debug.Log("이벤트에 대한 연결에 사용됩니다.");
    Debug.Log("해당 위치에서는 코루틴 사용이 불가능합니다.");
}
```
>**OnEnable()/OnDisable()** : 이벤트에 대한 접속/ 접속해제(on/off)(ex. 몬스터가 다시 리스폰될때 OnEnable로 체력 등이 초기화 될수 있게하고, OnDisable로 사라질때 한번만 실행하면 되는 명령을 넣는다)


 ```cs
void Start()
 {
     Debug.Log("[Start]");
     Debug.Log("해당 영역에서 코루틴에 대한 실행이 가능합니다.");
 }
```
>**Awake/Start 의 공통점** : 둘다 기본적으로 값에 대한 초기화(할당)을 수행하는 위치입니다. 어떤것을 사용해도 상관 없지만 상황에 따라 알맞게 설계합니다.
>>**Awake** : 변수 초기화, 값 참조
>>
>>**Start** : 게임 로직에 대한 실행, 초기화된 데이터를 기반으로 작업 수행, 코루틴 작업 O


 ```cs
void Update()
 {
 }
```
>**Update** : 화면에 렌더링되는 주기가 1초에 약 60번(하드웨어 성능에 따라 차이가 난다)
>
>Time.deltaTime을 통해 이전 프레임 ~ 현재 프레임까지의 시간 차이로 보정값을 주거나
정규화/단위 벡터를 이용해 작업을 처리합니다.
기본적으로 계산에 보정값들이 많이 사용됩니다.

>프로그램 내에서 핵심적으로 계속 사용되는 메인 로직을 짜는 위치로 사용됩니다.(ex.키 입력등을 기반으로 움직임(지속적인 업데이트 요구))
>
>매 프레임마다 실행되는 구간이기 때문에 업데이트에서 무조건 실행되야하는 상황이 아니라면, 다른영역에서 작업을 하게 설계하는것이
업데이트의 부담을 줄여줄 수 있고 성능의 향상으로 이어집니다.-->업데이트의 사용을 피할수록 성능이 올라가긴 하나, 제대로 알고 사용하는것이 중요
>
>**업데이트를 대체할 수 있는 수단**
>>1. 상황에 맞는 유니티 생명주기 코드
>>2. 코루틴
>>3. 이벤트시스템(버튼 클릭/충돌감지 등..)
>>4. C#의 가상 함수 개념(Update를 대신해 특정 클래스에서 업데이트 로직을 처리함)
 특정 하나의 관리 클래스(manager)에 Update의 로직을 위임해 관리해서 사용


 ```cs
void FixedUpdate()
 {
 }
```
>**FixedUpdate** : 일정한 발생 주기가 보장되어야하는 로직에서 사용.
>물리연산(rigidbody)
>
>프레임을 기반으로 처리되는것이 아닌 Fixed TimeStep(프로젝트 세팅에서 설정 가능)이라는 설정된 값에 의해 일정간격으로 호출
>
>TimeScale(시간비율)이 0으로 설정된 경우 멈춥니다.


 ```cs
void LateUpdate()
 {
 }
```
>**LateUpdate** : 모든 Update함수가 호출된 다음에 마지막으로 호출되는 영역입니다.
>
>후처리 작업에 사용됩니다.
>
>LateUpdate가 여러개일 경우 상황에 맞는 호출순서가 중요합니다.


**오브젝트 캐싱(Object cashing)에 대하여**
>캐시(Cashe) - 자주 사용되는 데이터나 값을 미리 복사해두는 임시 장소
> 
>캐시 사용 이유
>>1. 시간 지역성 : 가장 최근에 사용된 값이 다시 사용될 가능성이 높다.
>>2. 공간 지역성 : 최근에 접근한 주소와 인접한 주소의 변수가 사용될 가능성이 높다.
>> 
*ex)*
```cs
public class Sample03 : MonoBehaviour
{ 
    Rigidbody rb;
    Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(pos * 5);      
    }
```
>rb = GetComponent<Rigidbody>(); - 캐싱(cashing) : 임시 저장 데이터를 만들어놓는 행위
        변수로 저장해놔 매번 불러오는 수고를 던다
>
>GetComponent<Rigidbody>().AddForce(pos * 5); - 프레임마다 호출 :
         매 프레임마다 GetComponent로 정보를 가져오니 그만큼 성능 저하
        일시적으로 한번만 불러올 때는 사용 ㅇㅋ(웬만하면 update에서 사용 x)


### 벡터
> 벡터는 크기와 방향을 가진 물리량으로 유니티에서 위치(Position), 이동(Movement), 방향(Direction), 힘(Force)
> 등을 표현할 때 사용합니다
> 
> Vector3 -> x,y,z(3D)
> 
> Vector2 -> x,y(2D)
>
>>예시(게임 오브젝트의 Transform을 이용해 Vector값 구하기)
```cs
public Transform A_CUBE;
public Transform B_CUBE;

void Start()
{
Vector3 posA = A_CUBE.position;
Vector3 posB = B_CUBE.position;
//큐브 위치설정

Vector BtoA = posB-posA;
Vector AtoB = posA-posB;
//두 벡터의 차 => "방향 벡터"
```
>>거리 측정(Distance의 수학적 로직)
>>
>>a = (ax, ay, az), b = (bx, by, bz)라고 할 때,
>>
>>두 벡터 사이의 거리는 각 축에 대한 차에 제곱의 합에 대한 루트 값
>>> √((bx-ax)^2 + (by-ay)^2 + (bz-az)^2)
>>
>>유니티의 Mathf 클래스를 기반으로 바꾸면?
```cs
 Vector3 dif = posB - posA;
 float distance = Mathf.Sqrt(dif.x * dif.x + dif.y * dif.y + dif.z * dif.z);
 Debug.Log(distance);

 distance = Vector3.Distance(posA, posB); //== √((bx-ax)^2 + (by-ay)^2 + (bz-az)^2)
 Debug.Log(distance);
```


>벡터의 요소
>x : x축의 값
>y : y축의 값
>z : z축의 값
>w : 셰이더나 수학 계산 등에서 사용되는 Vector4에서의 w축
>
>※ 값(value) vs 참조(reference)
 값 : 변수의 데이터가 직접 저장됩니다.(ex. int a = 5; / a에 5라고 하는 데이터가 바로 저장되어있다)
 참조 : 변수에 데이터가 저장된 메모리 주소 값이 저장되는 경우.
        ex) VectorSample a = new VectorSample(); - 클래스는 대표적인 참조 타입.(위치가 중요하다)
>
> ※ 메모리 저장 영역 / 프로그램 실행 개념
프로그램이 실행되기 위해서는 운영체제(OS)가 프로그램의 정보를 메모리에 로드해야 합니다.
프로그램이 실행되는 동안 중앙제어장치(CPU)가 코드를 처리하기 위해 메모리가 명령어와 데이터들을 저장하고 있어야 함


>컴퓨터 메모리는 바이트(Byte) 단위로 번호가 새겨진 선형 공간을 의미합니다.
낮은 주소부터 높은 주소까지의 저장되는 영역이 다르게 설정되어 있습니다.
낮은 주소 : 메모리의 시작 부분(비교적 가벼운 데이터들로 구성)
높은 주소 : 메모리의 끝 부분(높은 주소로 갈수록 순차적으로 무거운 데이터들로 구성)


>대표적인 메모리 공간
>>1. 코드 영역(code) : 실행할 프로그램 코드가 저장되는 영역(텍스트 영역)
                      CPU에서 저장된 명령을 하나씩 가져가서 처리합니다.
                      "프로그램 시작부터 종료까지 계속 남아있는 데이터."

>>2. 데이터 영역(data) : 프로그램에서 전역 변수, 정적 변수가 저장되는 영역
    >>>전역 변수(global) : 프로그램 어디서나 접근 가능한 변수(C#에서는 전역 대신 클래스 수준의 정적 변수를 사용합니다.)
    >>>정적 변수(static) : static 키워드가 붙은 변수는 별도의 객체 생성 없이 클래스명.변수명으로 직접 접근하는것이 가능.
                      프로그램 시작 시에 할당이 되고 그 이후부터 종료 시점까지 유지(용량 커질 가능성이 있다)

>>3. 힙(heap) : 프로그래머가 직접 저장공간에 대한 할당과 해제를 진행하는 영역
              값에 대한 등록도, 값에 대한 제거도 프로그래머가 설계합니다.
         특징) 참조 타입은 힙에 저장됩니다.
         C# 힙 영역의 데이터는 GC에 의해 자동으로 관리됩니다.
         저장 순서, 정렬에 대한 작업을 따로 신경 쓸 필요가 X
         단, 메모리가 크고 GC에 의해 자동으로 처리되는만큼 많이 사용되면 성능이 저하되고 통제가 어렵다.
         접근 속도가 느린 편입니다.

>>4. 스택(stack) : 프로그램이 자동으로 사용하는 임시 메모리 영역 //스택오버플로우
                함수 호출 시 생성되는 변수(지역변수, 매개변수)가 저장되는 영역
                함수의 호출이 완료되면 사라지는 데이터, 이때의 호출 정보 == stack frmae(스택 프레임)
                매우 빠른 속도로 접근이 가능합니다.(할당과 해제의 비용이 사실상 없다)
                데이터가 먼저 들어온 데이터가 누적되고 가장 마지막에 남은 데이터가 먼저 제거되는 방식(LIFO)
>벡터의 특징
1. 값 타입(value)으로 참조가 아닌 값 그 자체를 의미한다.(구조체 struct)
 --> 계산이 빠르게 처리됩니다.
2. 값을 복사할 경우 값 그 자체를 복사하기만 하면 된다.
3. 벡터에 대한 계산 보조기능이 많이 제공됩니다.(magnitude, normalized, Dot, Cross ,,,)
4. 벡터는 스택(stack) 영역의 메모리에서 저장이 됩니다.

###선형 보간, 구면 선형 보간
>선형 보간
```cs
public class LinearInter : MonoBehaviour //선형 보간(linear interpolate) - Cube a
{
    //Vector3.Lerp(start,end,t);
    //start -> end까지 t에 따라 선형 보간합니다.
    //--> 해당 방향으로 일정 간격 천천히 이동하는 코드
    //t의 범위(0 ~ 1 -- float 값으로)

    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0.0f; //(0부터 1까지의 범위를 가지고있다)


    private void Start()
    {
        start_position = transform.position; //해당 스크립트를 가지고있는 오브젝트 - Cube a
    }

    private void Update()
    {
        //보간이 끝나지 않았을 때만 이동을 진행하겠습니다, t가 1이면 끝이라는 뜻
        if(t<1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start_position, target.position, t);
        }
    }
}
```
>구면 선형 보간
```cs
public class Sphericalnter : MonoBehaviour //구면 선형 보간(Spherically interpolate) - Cube b
{
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0.0f; //(0부터 1까지의 범위를 가지고있다)


    private void Start()
    {
        start_position = transform.position; //해당 스크립트를 가지고있는 오브젝트 - Cube a
    }

    private void Update()
    {
        if (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(start_position, target.position, t);
        }
    }
}
```
