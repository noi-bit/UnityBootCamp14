using System;
using UnityEngine;
//�� ������ �ν����Ϳ��� ������ ���� ǥ���� Ȯ���ϴ� �ڵ�� ���

public enum TYPE //enum : ������ , ����� �̸��� ���� �ۼ��ϴ� ���
{
    ��,��,Ǯ
}

//Flag : ���� ���� �����ϴ� ���
//���� 2�� �������� �־���� Flag�� �۵���
//2�� �������� ��Ʈ �������� ǥ���ϱⰡ �����ϴ� n<<1 �̸� n, n<<2�� n�� 2����
[Flags] //enum���� Flag�� ������ ���������� ����� �ȴ�
public enum TYPE2
{
    �� = 1 <<0, 
    ��Ʈ = 1<<1, //1���� 1ĭ �̵��ϰڽ��ϴ�.(��Ʈ ����)
    �巡�� = 1<<2,
    ���� = 1<<3,
    �� //�� �� ������ �����µ� �װ͵���� ��������??, ���� ��Ʈ�� �巡���� �ϰ������?
}

public class Variable : MonoBehaviour
{
    //����(int/uint - int : +-���,���� ���� ���� ,uint : ��� ������ �ǹ�)

    //����Ƽ/C# �⺻ ������ Ÿ��(primitive)
    //����(int)
    //�Ǽ�(float)
    //��(bool)
    //���ڿ�(string)
    //�� �� ���(nullable) - null�� "���� ����" �� ��Ÿ���� ��(0�̳� empty("")�� �ٸ� ����)
    //�ڷ���? �� �ۼ��ϸ� �ش� ���� null���� ����� �� ����
    public int Integer; //(public int? Integer = null; / �ڷ��� �տ� ?�� ���̸� null���� ��� ����)
    public float Float;
    public string Sentence;
    public bool isDead;
    public TYPE type;
    public TYPE2 type2;
}
