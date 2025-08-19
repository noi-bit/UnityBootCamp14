using UnityEngine;
using UnityEngine.Events;
//UnityEngine.Events ���ӽ����̽� ������ �ʼ�

//c#�� evnet���� ������
//1. �ν����Ϳ��� Ȯ���� �����ϴ�
//2. �߰� ���� ����� +=, -=�� ���� �ʰ�, AddListener/RemoveListener�� �����մϴ�.

//                     UnityAction              vs              UnityEvent
//      Ÿ��              delegate                                class
//      ���              �Լ�����                        �����Ϳ��� �ڵ鷯 ���� ��ϰ���
//      ����              +=, -=                          AddListern(), RemoveListener()
//   ����� ��Ȳ       ��ũ��Ʈ �ڵ� �� ó��                  �ν����Ϳ� �̺�Ʈ �ý���
//      �ӵ�                ����                              ����(���� ������ ���� �Ľ� �� ��Ÿ�� ���� ���)
//     �޸�               ����                                    ����
//   GC�߻� ����            ����                                    ����
//      ���Ǽ�         ��ü ���� �ʿ�                         �ٷ� ��� ����(��������)

//          ��UnityAction �� UnityEvent�� ����ϴ� �ڵ带 ������ �� ȿ������
//���Ϲ� delegate�� UnityAction<T>�� ���� Ÿ�Կ� ���� ������ �ȵǾ��־� ���� ���� ����ؾ� ��

//������Ƽ �۾� �� ����� �� �ִ� delegate ���� ������ ������
//  1. c# delegate
//  2. Unity UnityAction
//  3. c# Func<T>, Action<T>

public class EventSample3 : MonoBehaviour
{
    public UnityEvent OnKButtonEnter;
    public UnityAction OnAction;

    private void Start()
    {
        //OnKButtonEnter += Sample; ������
        OnKButtonEnter.AddListener(Sample); //�̷������� �߰������..
        //.AddListener(UnityAction call) ������ �ᱹ Sample�� UnityAction
        OnAction += Sample;//OnAction�� ��������Ʈ�� +=�� �߰� ����
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            OnKButtonEnter?.Invoke();
        }
        //TestSelf1���� ����Ϸ��� if(��ư�� ������?) ����Ƽ�̺�Ʈ �������������?.Invoke(); ��ŸƮ������ �������������.AddListener(�����������ؽ�Ʈ���)
    }

    public void Sample()
    {
        Debug.Log("<color=cyan>����!</color>");
    }

    public void Sample2()
    {
        Debug.Log("<color=green>Sample2 ����!</color>");
    }
}
