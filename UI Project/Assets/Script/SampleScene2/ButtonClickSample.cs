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
        //button01.Ŭ��on.����߰�(OnUpgradeBtnClick);
        //AddListener - ����Ƽ�� UI�� �̺�Ʈ�� ����� �������ִ� �ڵ�
        //������ �� �ִ� ���� ���°� ����������
        //�ٸ� ���·� �� ���(�Ű������� �ٸ� ���) delegate�� Ȱ��
        //���� ����� ���� �̺�Ʈ�� ����� �����ϸ� ����Ƽ �ν����Ϳ��� ����Ȯ���� X
        //���ν����� ����� ���� �ʰ� ���� ã�� ������ �߸� ���� Ȯ�� ������
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
