using System;
using System.Collections.Generic;
using UnityEngine;

class PriorityQueue<T> where T : IComparable<T> //<= �긦 ��ӹ޾� ������ Ŭ������ T�ν� ���� ����
{
    List<T> _heap = new List<T>();

    public void Push(T data)//InQueue�� �ƴ� Push�� �־��ش�
                            //����
    {
        //�ϴ� ��带 �� �Ʒ��� �߰�
        _heap.Add(data);

        //�߰��� ������ �������� ���� �ö󰡸� �񱳸� ��
        //�׷����� ���� ��ġ�� �ʿ���
        int now = _heap.Count - 1; //�ε����� List(0)�̴ϱ� "��ġ"�� ����
        while (now > 0) //now�� ��ġ�� ���̻� �ö󰥼� ���� ��ġ�� �� ������
        {
            //�θ� ���ϱ�
            int next = (now - 1) / 2;
            if (_heap[now].CompareTo(_heap[next]) < 0) //�θ�� ���ؼ�
                break; //�θ� �� ũ�� �� ������ ����

            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp; //�θ�� ���� ��ġ�� ������

            now = next; //�˻� ��ġ �̵�(������ �̵�) "��ġ�� next�� ��ġ�� �ٲ���"
        }
    }

    public T Pop()
    {
        T ret = _heap[0]; //���� ū ��, ��ȯ ������ ����

        //��Ʈ �ڽĵ��� ��ġ�� ������Ʈ��
        int lastIndex = _heap.Count - 1; //�������ε������ "������"�� ������
        _heap[0] = _heap[lastIndex]; //��Ʈ ����� �����͸� ������ �����ͷ� ��ü�ϱ�
        _heap.RemoveAt(lastIndex); //������ �ε����� ��������
        lastIndex--; //�������ε��� ���� �ϳ� �ٿ���

        //�� ���� ������ �������鼭 �ڸ��ٲٱ⸦ ����
        int now = 0;
        while (true)
        {
            //���� �ڽĳ�� ���ϱ�
            int left = (2 * now) + 1;
            //������ �ڽĳ�� ���ϱ�
            int right = (2 * now) + 2;


            int next = now; //next�� now�� �־���,
                            //�׸��� left�� ����. left�� �� ũ�� left�� next�� ����
            if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                next = left; //left�� lastIndex ���� �ȿ� �ִ���, left�� next���� ũ��

            if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                //���� if���� ����� next(==left)�� right�� ���ؼ� next{==left)�� �۴ٸ� right�� �ڸ� ����
                next = right;

            //--����, ���� �������� ��� now���� �۴ٸ� �����Ѵ�
            if (next == now) //next�� ��� �� ���� ���ϸ� �����Դµ� �� ���� now�� �������� - break
                             //�ؿ��� now�� next���� �ְ�, �ٽ� while���� next�� now�� �־��ִµ�,
                             //next���� ������� �ʰ� now�� ���� ���� ä�� �������� break
                break;

            //���� �� ���� ��ü�Ѵ�
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;

            now = next;
        }
        //�ٷ� �� �ڽ� - ���� ���� ������ ��带 ��

        return ret; //���� ū �� �̾���
    }

    public int Count { get { return _heap.Count; } }
}
