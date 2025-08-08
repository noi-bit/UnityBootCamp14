using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSample : MonoBehaviour
{
    public Button change;
    public GameObject settingwindow;

    private void Start()
    {
        settingwindow.SetActive(false);
        settingwindow = GetComponent<GameObject>();
        change.onClick.AddListener(ButtontoChange);
        //button01.클릭on.기능추가(OnUpgradeBtnClick);
        //AddListener - 유니티의 UI의 이벤트에 기능을 연결해주는 코드
        //전달할 수 있는 값의 형태가 정해져있음
        //다른 형태로 쓸 경우(매개변수가 다를 경우) delegate를 활용
        //※이 기능을 통해 이벤트에 기능을 전달하면 유니티 인스펙터에서 연결확인은 X
        //※인스펙터 등록을 하지 않고 직접 찾기 때문에 잘못 넣을 확율 낮아짐
    }
    //private void Update()
    //{
    //    ButtontoChange();
    //}
    void ButtontoChange()
    {
        settingwindow.SetActive(true);
    }
}
