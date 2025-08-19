using UnityEngine;
using System;

//1. EventArgs�� ����� Ŀ���� Ŭ���� ����
public class DamageEventArgs : EventArgs
{
    //������ ���� ���� ����(property�� �۾��ϸ�, get ��ɸ� �ַ� Ȱ��ȭ �մϴ�.)

    public int Value { get; } //Value�� ���� ���ٸ� ����

    public string EventName { get; }

    //EventArgs�� ���� ������ �߻��ϸ� ���� �����˴ϴ�(������)
    public DamageEventArgs(int value, string eventName)
    {
        Value = value;
        EventName = eventName;
    }
}

public class EventSample4 : MonoBehaviour
{
//2. DamageEventArgs Ŭ������ Unity���� ������ �� �ְ� ����

    public EventHandler<DamageEventArgs> OnDamaged; //�������� �޾��� ���� ���� �̺�Ʈ �ڵ鷯(���� �������� �����ϰڴ�)
    //public �̺�Ʈ�ڵ鷯<Ŭ�����̸�> ��ü����;

    public void TakeDamage(int value, string eventName)
    {
        //���޹��� ���� �������� ������ �̺�Ʈ �Ű������� ������, �ڵ鷯 ȣ�� ���� ������ �����մϴ�.
        OnDamaged?.Invoke(this, new DamageEventArgs(value, eventName));

        Debug.Log($"<color=red>[���!] [{eventName}]�÷��̾ {value}�� �޾ҽ��ϴ�</color>");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) //��Ŭ�� value�� ���� ������������ ����
        {
            TakeDamage(UnityEngine.Random.Range(10, 200), "���� ����");
        }
    }
}
