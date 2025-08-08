using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button button01;
    public Text message;
    public Text icon_text;

    //미쿠
    public UnitStat unitStat;
    public UnitInventory unitInventory;

    public Text nameText;//미쿠이름
    public Text verText;//미쿠버전
    public Text lineText;//미쿠대사
    public Text money;//미쿠머니
    public Text indList;//미쿠재료
    
    //재료

    //자료형[] 배열이름 = new 자료형[] {값, 값1, 값2...};
    // ㄴ> 배열이 그 값들을 가진 채로 생성됩니다
    public string[] materials = new string[] //private static readonly string[] materials = new string[] => static readonly를 붙이면 런타임 시 한번만 초기화, 값 수정 X
    {
        "100",
        "100+USB",
        "100+헤드폰+마이크",
        "최대 강화 완료"
    };
    //max_level을 사용할 경우 배열의 길이 -1의 값을 가지게 됨

    private int upgrade;//강화수치
    private int max_level => materials.Length-1; //materials 배열의 길이가 바뀌면, max_level도 자동으로 그에 맞게 반영됨 //3
    //배열에는 인덱스라는 개념이 존재합니다
    //ex)materials가 하나의 묶음이고 , 거기서 두번쨰 데이터는? materials[1] => 카운트를 0부터 셈

    private void Start()
    {
        button01.onClick.AddListener(OnUpgradeBtnClick);
        //button01.클릭on.기능추가(OnUpgradeBtnClick);
        //AddListener - 유니티의 UI의 이벤트에 기능을 연결해주는 코드
        //전달할 수 있는 값의 형태가 정해져있음
        //다른 형태로 쓸 경우(매개변수가 다를 경우) delegate를 활용
        //※이 기능을 통해 이벤트에 기능을 전달하면 유니티 인스펙터에서 연결확인은 X
        //※인스펙터 등록을 하지 않고 직접 찾기 때문에 잘못 넣을 확율 낮아짐

        upgrade = 0;
        UpdateUI(); //시작 시 UI에 대한 렌더링 설정
                    //ㄴ>처음 시작할 때 UpdateUI()로 시작하고싶기 때문에(Scene에서 설정한 텍스트와 이미지가 나오면 안되니까?)
        Ingredient();
        discountcold();
    }

    //버튼 클릭시 호출할 메소드
    private void OnUpgradeBtnClick()
    {
        if(upgrade < max_level)
        {
            upgrade++;
            UpdateUI();
            discountcold();
        }
    }

    //private void mikuhave()
    //{
    //    money.text = $"{unitInventory.gold} gold";
    //}

    private void Ingredient()
    {
        indList.text = " ";
        unitInventory.ingredient = unitInventory.ingredientList.Split(',');
        //UnitInventory.Ingredient_control.핸드폰;
        foreach (string item in unitInventory.ingredient)
        {
            indList.text += $"{item} ";
        }
    }

    public void discountcold()
    {
        unitInventory.gold -= upgrade*100;
        money.text = $"{unitInventory.gold} gold";
    }

    private void UpdateUI()
    {
        if (upgrade < 3)
        {
            icon_text.text = $"{unitStat.mikuname} + {upgrade}";
        }
        else if(upgrade == 3)
        {
            icon_text.text = $"MAX upgrade!";
        }
        message.text = materials[upgrade];
        nameText.text = unitStat.mikuname;
        verText.text = $"{unitStat.version[upgrade]}.ver"; //{ "V3.0", "V3.1", "V4X", "NT" };
        lineText.text = $"-- {unitStat.line[upgrade]} --";  //{ "HI!","I'm miku","upgrade!","歌いたい" };
    }
}
