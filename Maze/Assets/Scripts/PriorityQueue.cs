using System;
using System.Collections.Generic;
using UnityEngine;

class PriorityQueue<T> where T : IComparable<T> //<= 얘를 상속받아 구현한 클래스만 T로써 역할 가능
{
    List<T> _heap = new List<T>();

    public void Push(T data)//InQueue가 아닌 Push로 넣어준다
                            //삽입
    {
        //일단 노드를 맨 아래에 추가
        _heap.Add(data);

        //추가된 데이터 기준으로 위로 올라가며 비교를 함
        //그럴려면 현재 위치가 필요함
        int now = _heap.Count - 1; //인덱스로 List(0)이니까 "위치"인 거임
        while (now > 0) //now의 위치가 더이상 올라갈수 없는 위치가 될 때까지
        {
            //부모 구하기
            int next = (now - 1) / 2;
            if (_heap[now].CompareTo(_heap[next]) < 0) //부모와 비교해서
                break; //부모가 더 크면 걍 가만히 있음

            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp; //부모와 나의 위치를 스왑함

            now = next; //검사 위치 이동(포인터 이동) "위치를 next의 위치로 바꿔줌"
        }
    }

    public T Pop()
    {
        T ret = _heap[0]; //가장 큰 값, 반환 데이터 저장

        //루트 자식들의 위치를 업데이트함
        int lastIndex = _heap.Count - 1; //마지막인덱스라는 "포인터"를 가져옴
        _heap[0] = _heap[lastIndex]; //루트 노드의 데이터를 마지막 데이터로 교체하기
        _heap.RemoveAt(lastIndex); //마지막 인덱스를 삭제해줌
        lastIndex--; //마지막인덱스 값도 하나 줄여줌

        //맨 위를 밑으로 내려가면서 자리바꾸기를 해줌
        int now = 0;
        while (true)
        {
            //왼쪽 자식노드 구하기
            int left = (2 * now) + 1;
            //오른쪽 자식노드 구하기
            int right = (2 * now) + 2;


            int next = now; //next에 now를 넣어줌,
                            //그리고 left와 비교함. left가 더 크면 left를 next로 해줌
            if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                next = left; //left가 lastIndex 범위 안에 있는지, left가 next보다 크면

            if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                //위의 if문을 통과한 next(==left)와 right를 비교해서 next{==left)가 작다면 right와 자리 변경
                next = right;

            //--만약, 왼쪽 오른쪽이 모두 now보다 작다면 종료한다
            if (next == now) //next를 계속 왼 오와 비교하며 내려왔는데 그 값이 now와 같아졌다 - break
                             //밑에서 now에 next값을 주고, 다시 while에서 next에 now를 넣어주는데,
                             //next값이 변경되지 않고 now와 값이 같은 채로 내려오면 break
                break;

            //이제 두 값을 교체한다
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;

            now = next;
        }
        //바로 밑 자식 - 왼쪽 노드와 오른쪽 노드를 비교

        return ret; //가장 큰 값 뽑아줌
    }

    public int Count { get { return _heap.Count; } }
}
