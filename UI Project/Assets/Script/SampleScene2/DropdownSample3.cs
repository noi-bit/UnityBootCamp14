using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//��� �ٿ��� �������
//1. Template : ��� �ٿ��� �������� ��, ���̴� ����Ʈ �׸�
//2. Caption/ Item Text : ���� ���õ� �׸�/ ����Ʈ �׸� ������ ���� �ؽ�Ʈ
//      TMP�� ���� ���, �ѱ� ����� ���� Label�� Item Label���� ������� ��Ʈ�� ������ ��� ��
//3. Options : ��Ӵٿ ǥ�õ� �׸� ���� ����Ʈ
//      �ν����͸� ���� ���� ����� ����
//      ����ϸ� �ٷ� ����Ʈ�� �����
//4. On Value Changed : ����ڰ� �׸��� �������� �� ȣ��Ǵ� �̺�Ʈ
//      �ν����͸� ���� ���� ����� �� �ִ�
//      ��� �ٿ� ���� ���� ���� �߻� �� ȣ���


public class DropdownSample3 : MonoBehaviour
{
    public TMP_Dropdown style;
    public PlayerInfoSample stylelist;

    //Options�� ����� ���� ���ڿ�


    //����Ʈ<T> ����Ʈ�� = new ����Ʈ��<T> {���1, ���2, ���3}; 
    //��Ӵٿ� �ɼǿ� �� ��ҵ� A,B,C

    private void Start()
    {

        style.ClearOptions();//��Ӵٿ��� Option ����� �����ϴ� �ڵ�
        style.AddOptions(stylelist.playerstyle);//�غ�� ��ܿ� �߰��ϴ� ���
                                                 //dropdown.onValueChanged.AddListener(OnDropdownValueChanged);//�̺�Ʈ ��� �� �䱸�ϴ� �Լ��� ���´�� �ۼ��� �ƴٸ�,
                                                 //�Լ��� �̸��� �־� ����� �� ����
    }
}