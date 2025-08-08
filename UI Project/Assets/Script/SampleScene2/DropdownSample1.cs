using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//드롭 다운의 구성요소
//1. Template : 드롭 다운이 펼쳐졌을 때, 보이는 리스트 항목
//2. Caption/ Item Text : 현재 선택된 항목/ 리스트 항목 각각에 대한 텍스트
//      TMP를 쓰는 경우, 한글 사용을 위해 Label과 Item Label에서 사용중인 폰트를 수정해 줘야 함
//3. Options : 드롭다운에 표시될 항목에 대한 리스트
//      인스펙터를 통해 직접 등록이 가능
//      등록하면 바로 리스트에 적용됨
//4. On Value Changed : 사용자가 항목을 선택했을 때 호출되는 이벤트
//      인스펙터를 통해 직접 등록할 수 있다
//      드롭 다운 값에 대한 변경 발생 시 호출됨


public class DropdownSample1 : MonoBehaviour
{
    public TMP_Dropdown gender;
    public PlayerInfoSample genderlist;

    //Options에 등록할 값은 문자열


    //리스트<T> 리스트명 = new 리스트명<T> {요소1, 요소2, 요소3}; 
    //드롭다운 옵션에 들어갈 요소들 A,B,C

    private void Start()
    {

        gender.ClearOptions();//드롭다운의 Option 명단을 제거하는 코드
        gender.AddOptions(genderlist.playergender);//준비된 명단에 추가하는 기능
                                                   //dropdown.onValueChanged.AddListener(OnDropdownValueChanged);//이벤트 등록 시 요구하는 함수의 형태대로 작성이 됐다면,
                                                   //함수의 이름을 넣어 사용할 수 있음
    }

    //C#에서 --> System.Int32 == int
    //           System.Int64 == long
    //           System.UInt32 == uint(unsigned int, - 부호가 없는 32비트 정수)
    //void OnDropdownValueChanged(Int32 idx)
    //{
    //    Debug.Log("현재 선택된 메뉴는 " + dropdown.options[idx].text);//옵션 리스트의 idx번째 값에 대한 텍스트
    //}
}
