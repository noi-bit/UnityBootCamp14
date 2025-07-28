# 250728

## 유니티의 생명주기
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
