using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//대화 텍스트 호출 스크립트

[Serializable]//클래스도 인스펙터에서 확인할 수 있다
public class Dialog//대화 1건을 담는 데이터 클래스
{
    public string character;
    public string content; //대화 텍스트

    //클래스 생성 시 호출되는 메소드(생성자) : 우클릭 - 빠른 작업 및 리팩토링 - 생성자 만들기
    public Dialog(string character, string content)//클래스를 관장?하는 생성자(함수) 근데 애초에 void로 만들지 않는 이유?
    {                                               //매개변수로 받아오는 값을 이 클래스의 멤버변수 값들로 사용
        this.character = character;
        this.content = content;
        //this는 클래스 자신을 의미(매개변수로 받아오는 이름과 멤버변수의 이름이 같아서 this가 붙여짐)
        //클래스가 가진 값과 매개변수의 이름이 같아서 구분하기 위한 용도
    }
}

public class DialogManager : MonoBehaviour //매니저도 각 해당 기능을 가진 매니저들로 나눠주는게 좋다?
{
    #region MonoSingleton


    //1) 자기 자신에 대한 인스턴스를 가진다(전역)
    public static DialogManager Instance { get; private set; } //키워드 프로퍼티(가져올수는 있지만 설정할 수는 없다)
    //ㄴ> ??(전역)static Istance 값을 얻어올수 있다 DialogManager 형태의 데이터, set 설정할수 있는 권한을 private로(설정이 불가능한 코드)를 get한다??
    // Instance는 값을 얻어올 수 있습니다(접근 가능)
    // 수정은 할 수 X

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //해당 인스턴스는 자기 자신입니다. 
            DontDestroyOnLoad(gameObject); //DDOL : 해당 위치에 있는 오브젝트가 씬이 넘어가도 파괴되지 않게(이 스크립트가 붙어있는 오브젝트)
                                           //       따로 관리되는 씬의 영역}
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region field
    public GameObject panel;
    public TMP_Text character_name;
    public TMP_Text message;
    public float typing_speed;
    
    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping = false;
    private Dialog current;//현재의 대화 내용 확인
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //이벤트 시스템에 전달된 값이 존재하고, 그 값이 UI위에서 눌려진 상황이라면?
            if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;//작업X
            }//대화창을 먼저 실행하고, "그 대화창 안에서" 스페이스바를 눌렀을때 "대화 중 상태"가 됨

            //스페이스 눌러서 정상적으로 작업 중인 경우(대화 매니저 있고, "대화 중" 상태인 경우
            if(isTyping)//타이핑 중이면
            {
                CompleteLine();//라인 작업에 대한 마무리
            }
            else
            {
                NextLine();//다음 라인으로 이동합니다
            }
        }
    }

    /// <summary>
    /// List<T>나 Queue<T>처럼 열거 형태의 데이터를 다 매개변수로 받을 수 있습니다
    /// </summary>
    /// <param name="lines">대화 데이터에 대한 열거형 묶음 데이터</param>
    public void StartLine(IEnumerable<Dialog> lines)//IEnumerable : 열거형 데이터들을 통합해줄때 사용
    {//대화창에 넣을 문자열을 배치하고 대화창을 키고 NextLine을 불러옴
        queue.Clear();
        foreach(var line in lines)
        {
            queue.Enqueue(line);
        }
        panel.SetActive(true);
        NextLine();
    }

    //다음 작업을 위한 함수
    private void NextLine()
    {   
        //작업할 내용이 더이상 없다면(==0)
        if(queue.Count == 0)
        {
            DialogueExit();//대화의 종료
            return;
        }
        //큐에 저장된 값을 하나 얻어옵니다
        current = queue.Dequeue();
        character_name.text = current.character;//현재 대화 기준 캐릭터 이름으로 변경

        if (typing != null)
            StopCoroutine(typing);//코루틴이 남아있는 상태라면 멈춰줍니다

        typing = StartCoroutine(TypingDialogue(current.content));//현재 대화 데이터의 콘텐츠(대화 내용)을 기준으로 대화 타이핑을 시작합니다
    }

    private IEnumerator TypingDialogue(string line)
    {
        isTyping = true;//타이핑 진행중임을 알림
        StringBuilder stringBuilder = new StringBuilder(line.Length);//컬렉션 코드 StringBuilder
        message.text = "";//내용 비우기

        foreach(char c in line)//string(문자열)은 문자(char)의 배열 안녕하세요? 면 안+녕+하+세+요+? 이렇게 각 하나 글자씩 타이핑
        {
            //message.text += c;
            stringBuilder.Append(c);//Append로 문자들(c)을 문자열로 결합
            message.text = stringBuilder.ToString();
            yield return new WaitForSeconds(typing_speed); //0.1~1 사이 정도의 값으로 넣어줄 것
        }
        isTyping = false;
    }

    //기능
    private void CompleteLine()//기능
    {
        if(typing != null)
            StopCoroutine(typing);

        message.text = current.content;
        isTyping = false;
    }

    private void DialogueExit()
    {
        panel.SetActive(false); //패널 종료
    }
}
