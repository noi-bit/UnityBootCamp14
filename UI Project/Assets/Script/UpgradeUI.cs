using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button button01;
    public Text message;
    public Text icon_text;

    //����
    public UnitStat unitStat;
    public UnitInventory unitInventory;

    public Text nameText;//�����̸�
    public Text verText;//�������
    public Text lineText;//������
    public Text money;//����Ӵ�
    public Text indList;//�������
    
    //���

    //�ڷ���[] �迭�̸� = new �ڷ���[] {��, ��1, ��2...};
    // ��> �迭�� �� ������ ���� ä�� �����˴ϴ�
    public string[] materials = new string[] //private static readonly string[] materials = new string[] => static readonly�� ���̸� ��Ÿ�� �� �ѹ��� �ʱ�ȭ, �� ���� X
    {
        "100",
        "100+USB",
        "100+�����+����ũ",
        "�ִ� ��ȭ �Ϸ�"
    };
    //max_level�� ����� ��� �迭�� ���� -1�� ���� ������ ��

    private int upgrade;//��ȭ��ġ
    private int max_level => materials.Length-1; //materials �迭�� ���̰� �ٲ��, max_level�� �ڵ����� �׿� �°� �ݿ��� //3
    //�迭���� �ε������ ������ �����մϴ�
    //ex)materials�� �ϳ��� �����̰� , �ű⼭ �ι��� �����ʹ�? materials[1] => ī��Ʈ�� 0���� ��

    private void Start()
    {
        button01.onClick.AddListener(OnUpgradeBtnClick);
        //button01.Ŭ��on.����߰�(OnUpgradeBtnClick);
        //AddListener - ����Ƽ�� UI�� �̺�Ʈ�� ����� �������ִ� �ڵ�
        //������ �� �ִ� ���� ���°� ����������
        //�ٸ� ���·� �� ���(�Ű������� �ٸ� ���) delegate�� Ȱ��
        //���� ����� ���� �̺�Ʈ�� ����� �����ϸ� ����Ƽ �ν����Ϳ��� ����Ȯ���� X
        //���ν����� ����� ���� �ʰ� ���� ã�� ������ �߸� ���� Ȯ�� ������

        upgrade = 0;
        UpdateUI(); //���� �� UI�� ���� ������ ����
                    //��>ó�� ������ �� UpdateUI()�� �����ϰ�ͱ� ������(Scene���� ������ �ؽ�Ʈ�� �̹����� ������ �ȵǴϱ�?)
        Ingredient();
        discountcold();
    }

    //��ư Ŭ���� ȣ���� �޼ҵ�
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
        //UnitInventory.Ingredient_control.�ڵ���;
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
        lineText.text = $"-- {unitStat.line[upgrade]} --";  //{ "HI!","I'm miku","upgrade!","ʰ������" };
    }
}
