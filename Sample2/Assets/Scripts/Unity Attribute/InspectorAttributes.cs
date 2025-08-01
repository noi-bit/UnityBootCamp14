using System.Collections.Generic; //C#���� �������ִ� �ڷᱸ��(List<T>, dictionary<K,V> ���� ��) ��� ����
using System;
using UnityEngine;

public class InspectorAttributes : MonoBehaviour
{
    [System.Serializable]
    public struct BOOK //����� ���� Ÿ�� / Value Ÿ�� / GC �ʿ� ����(���� �������� ������ ���� �Ҵ�/�����ϴ� �������� Ȱ�� ex) Vector3)
    {                  //���� ����ȭ�� ���� ���ȴ�
        public string name;
        public string description;
    }

    [Serializable]
    public class Item // ��ü�� ���� ���赵(�Ӽ�(������)�� ���(����)�� ����) / ����Ƽ������ class ��� ����, �������� �� ����
    {                 // ���� ���������� �Ǽ� �߻� ���ɼ� X
        public string name;
        public string description;
    }
    
    [Header("Score")]
    public int point;
    public int max_point;
    [Header("Information")]
    public string nickname;
    public Job myjob;

    //�ν����Ϳ� �����ϱ� ���� ���� ���� ����
    [HideInInspector]
    public int value = 5;

    //*����ȭ(Serialization) : �����͸� ���� ������ �������� ��ȭ�ϴ� �۾�
    //�� ��ȯ�� ���� ��, ������, ���� � �����ϰ� �����ϴ� �۾��� ������ �� �ִ�

    //public                        --> ���� + ���� ����
    //private                       --> ���� X ���� X
    //[SerializeField] + private    --> ���� X, but �ν����Ϳ����� ���� ����
    
    //����ȭ ����
    //1. public or [SerializeField]
    //2. static�� �ƴ� ���(static�� ������ �� ��ü�� �ܺο��� ���ٰ��� - new�� �ҷ����� �ʰ� �ٷ� ��밡��)(�̹� �ܺο��� ����/����� �����ϱ⿡ ����ȭ�� �ʿ䰡X)
    //2-1.  static(������) - ����ƽ�� ��(������ ������..����) �̹����� ��������
    //3. ����ȭ "������" Ÿ���� ���
    //3-1.  ����ȭ �Ұ����� ������
    //      a. Dictionary<K,V> (��й�ȣ? �������� �ڵ�)
    //      b. Interface (�������̽�, Ŭ�������� �Ѵܰ� ��)(�̿ϼ� ������)
    //      c. static Ű���尡 ���� �ʵ�
    //      d. abstract Ű���尡 ���� Ŭ����
    //3-2. ����ȭ ������ ������
    //      a. �⺻ ������(int, float, bool, string...)
    //      b. ����Ƽ���� �������ִ� ����ü(Vector3, Quaternion, Color)
    //      c. ����Ƽ ��ü ����(GameObject, Transform, Material)
    //      d. [Serializable] �Ӽ��� ���� Ŭ����
    //      e. �迭/����Ʈ
    [SerializeField]//�����Ϳ� ������ �� �ֵ��� ����ȭ�Ѵ�, ����Ƽ���� �����(private) �ʵ带 �ν����Ϳ� �����Ű�� ����Ƽ�� ����ȭ �ý��ۿ� ���Խ�Ŵ
    //private int value2 = 7;


    //Space(����) : ���� ���̸�ŭ ������ ����
    //[TextArea]���ڿ��� �幮�� ��� ������ �Ӽ�, [TextArea]�� ����� ��� ���� �� �Է��� ������ ���°� �˴ϴ�.
    //[TextArea(�⺻ ǥ�� ��, �ִ� ��)]��ȣ�� ������ �ִ�, �ּҸ� ���� �� �ִ�
    //���ڿ� ���̿� ���� �������� �κ��� ����
    [Space(30)][TextArea(3,5)]
    public string quest_info;

    public BOOK book;
    public Item item;

    //����Ƽ �ν����Ϳ����� �迭�� ����Ʈ�� ������ �˴ϴ�
    //����Ʈ<T>�� T ������ �����͸� �������� ���������� ������ �� �ִ� �������Դϴ�
    //�������� �˻�, �߰�, ���� ���� ����� �����˴ϴ�
    //<Item> �ȿ� �迭�� ������ �ִ� 
    //�����͸� ���� ���� �����ϴ�(�������� ���� ����)
    public List<Item> item_list;
    public BOOK[] books = new BOOK[5];//start�� ������ �ټ����� ����ִ� ĭ�� �����Ǵ°���
    //List<>�� �迭�� ����Ƽ ������ �ȿ��� �Ȱ��� ��޵ȴ�


    //���� : ����, ����, �ü�, ������
    public enum Job//Ŭ���� �ܺο� public enum Job���� public�� ������ ����� ���� - �׷��� �ܺο����� ���� ����
    {
        ����,
        ����,
        �ü�,
        ������
    }

    //[Range(�ּ�,�ִ�)] �� ���� �ش� ���� �����Ϳ��� �ּҰ��� �ִ밪�� �����Ǿ��ִ� ��ũ�� ������ ������ �����(������ ���� ����)
    [Range(0,100)]public int bg;
    [Range(0,100)]public float sfx;

}
