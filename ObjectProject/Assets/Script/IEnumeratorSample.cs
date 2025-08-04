using System.Collections;
using UnityEngine;
// 3 ��° ��ũ��Ʈ

public class IEnumeratorSample : MonoBehaviour
{
    class CustomCollection : IEnumerable
    {
        int[] numbers = { 6, 7, 8, 9, 10 };

        // GetEnumerator�� ���� ��ȸ ������ �����͸� IEnumerator ������ ��ü�� ��ȯ
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i<numbers.Length; i++)
            {
                yield return numbers[i];
            }
        }
    }
    
    int[] numbers = {1,2,3,4,5}; // �׳� �����Ҷ� ������ �����͸� ����� Enumerator�� �����ָ� �� ������� �ٲ���?

    void Start()
    {
        // numbers ��� �迭�� ��ȸ�� �� �ִ� IEnumerator ������ �����ͷ� ��ȯ
        IEnumerator enumerator = numbers.GetEnumerator();

        while(enumerator.MoveNext()) // ���� ���� �������� �ݺ�, ���ٸ� ����
        {
            Debug.Log(enumerator.Current); // Current : ���� ��ȸ�ϰ��ִ� �����Ϳ� ���� ����
        }

        CustomCollection collection = new CustomCollection(); // Ŀ���� �÷��� ����

        // foreach�� ��ȯ ������ �����͸� ���������� �۾��� �� ����ϴ� for�� - ���� ��������
        foreach(int number in collection)
        {
            Debug.Log(number);
        }

        IEnumerator enumerator1 = numbers.GetEnumerator();

        foreach (var data in GetMessage())
        {
            Debug.Log(data.ToString());
        }
    }

    // yield�� C#���� �ѹ��� �ϳ��� ���� �ѱ��, �޼ҵ尡 �Ͻ����� �Ǹ� �ļ� ������ 
    // ���������� ��ȯ�ϰ� �� - �ݺ����� �۾�, �������� ������ ó���� ����

    // yield �� yield return; , yield break; �� ����
    
    // yield return�� �޼ҵ尡 ���� ��ȯ�ϸ鼭 �� �������� �޼ҵ� ������ �Ͻ����� ��Ŵ
    // --> ȣ���ڰ� ���� ���� �䱸�� ������ �����

    // yield break�� �޼ҵ忡���� �ݺ��� �����ϴ� �ڵ� - �Ϻ��ϰ� ������ �����

    // yield return�� ����ϴ� �޼ҵ�-- IEnumerable , IEnumerator �������̽��� �����ϰ� ��
    // �÷����� �ڵ����� ��ȸ�ϴ� foreach(Ȥ�� while)�� ���� ����

    // -- IEnumerable : �ݺ������� �÷����� ��Ÿ���� �������̽�
    // (�ݺ����� ��Ÿ��) �� ����� ������ Ŭ������ �ݺ��� �� �ִ� ��ü�� �Ǹ�, 
    //                  foreach ��� �������� Ž���� ������ �� �ְ� ��
    //                  �ش� �������̽��� �����ϱ� ���ؼ��� GetEnumerator() �޼ҵ带 �����ϰ�,
    //                  ����ڰ� �����ؾ� ��

    // -- IEnumerator : �ݺ��� �����ϴ� �������̽�
    //    (�ݺ� ����)    �÷��ǿ��� �ϳ��� �׸���� ��ȯ�ϰ�, �� ���¸� �����ϴ� ������ ������
    //                  MoveNext()�� ���ؼ� ���� ���� ����, Current�� ���ؼ� ���� �� Ȯ��
    //                  Reset()�� ���ؼ� ���� ��� ó��

    // ���� : ���� �ʿ�� �� ������ ����� �̷�� ���(�޸� ȿ���� ����, ū �����͸� ó���ϱ� ����)
    //        ��> ��� �����͸� �����ϴ°� �ƴ� �ʿ��� �κи� ó���� �� �ְԵǱ� ����
    static IEnumerable GetMessage()
    {
        Debug.Log("�޼ҵ� ����!");
        yield return "�߾ƾƾ�"; // �߾ƾƾ� �� ��������, �ٽ� �ش� �޼ҵ�� ���ƿɴϴ�
        Debug.Log("Ż�� �ߴٰ� ���ƿ� 1");
        yield return "ȣ";
        Debug.Log("Ż�� �ߴٰ� ���ƿ� 2");
        yield break; // ��ȯ �۾� ����

        //-----Unreachable Code -----(���� �Ұ� - �̹� break�� ��ȯ ����)
        //Debug.Log("Ż�� �ߴٰ� ���ƿ� 3");
        //yield return "!!!";
    }
}
