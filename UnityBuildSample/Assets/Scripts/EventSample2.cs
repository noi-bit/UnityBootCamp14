using System;
using UnityEngine;

//EventSample�� ������Ʈ�� �پ��ִ� ��ü�� ����
public class EventSample2 : MonoBehaviour
{
    void Start()
    {
        //�ٸ� Ŭ�������� �̺�Ʈ�� �����ϴ� ���

        //Ŭ���� ����
        EventSample event_sample = GetComponent<EventSample>();
        
        //Ŭ������ ���� �̺�Ʈ�� �߰�
        event_sample.OnSpaceEnter += OnSpaceButton;
        //event_Sample.OnSpaceEnter -= event_sample.Debug_OnSpaceEnter();
    }

    private void OnSpaceButton(object sender, EventArgs e)
    {
        Debug.Log("<color=blue>Sample2���� ����� ���!</color>");
    }
}
