using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

class Pos
{
    public Pos(int y, int x) { Y = y; X = x; }
   
    public int Y;
    public int X;
}

public class Player : MonoBehaviour
{
    public int PosY { get; set; }
    public int PosX { get; set; }

    private Board _board;
    private bool _isBoardCreated = false;

    private const float MOVE_TICK = 0.1f;
    private int _lastIndex = 0;
    private float _sumTick = 0;

    enum Dir
    {
        Up = 0,
        Left = 1,
        Down = 2,
        Right = 3
    }

    int _dir = (int)Dir.Up;

    List<Pos> _points = new List<Pos>();

    public void Initialze(int posY, int posX, Board board)
    {
        PosY = posY;
        PosX = posX;
        _board = board;

        //                                X         Y
        transform.position = new Vector3(PosX, 0, -PosY);

        _points.Clear(); //리스트 초기화 - Create누를 때마다 미로 재생성
        _lastIndex = 0;

        //BFS();
        AStar();
        _isBoardCreated = true;
    }

    struct PQNode : IComparable<PQNode>
    { 
        //struct 로 만든 이유
        //1. 값형식이라 힙 할당/GC 부담 down
        // -> class는 참조형식이라 new로 생성할때마다 힙에 객체가 생기고, GC의 관리가 생기기 때문
        //2. struct는 값 형식이라 스택(stack)이나 배열 내부에 바로 저장됨
        // -> 우선순위큐에서 엄청 많은 노드를 push/pop 할때, GC Alloc이 줄고 성능이 좋아질 수 있음
        //3. 크기가 작은 데이터 묶음이기 때문에 struct가 적절하다
        // -> PQNode가 담고 있는 필드가 몇개 안될거고, struct가 그런 변수들의 묶음 덩어리로 사용됨
        // -> .net의 디자인가이드에도 구조체가 16byte 이내라면 클래스보다 struct가 성능상 유리하다 나와있다.
    
        public int F; //총점
        public int G;
        public int Y;
        public int X;

        public int CompareTo(PQNode other)
        {
            if (F == other.F)
                return 0;

            return F < other.F ? 1 : -1;
            //나의 F가 other.F와 비교해서 더 작다는건? 나의 F위치가 목적지와 좀 더 가깝다
            // ----> 그래서 가산점 1을 반환한다
        }
    }

    void AStar() //다익스트라와 비슷하면서도 다름?
                 //시작, 끝 지점을 주고 - 처음부터 목적지까지 가는 비용계산 & 목적지까지 얼마나 가까워지고있는지에 대한 가산점을 부여해
                 //목적지로 유도함
    {
        //                    위  왼 아래 오른, + 위왼 아래왼 아래오른 위오른
        int[]  dY = new int[] { -1, 0, 1, 0 , -1, 1, 1, -1};
        int[]  dX = new int[] { 0, -1, 0, 1 , -1, -1, 1, 1};
        int[] cost = new int[] {10,10,10,10, 14, 14, 14, 14}; //가중치(G값과 연관되어있다)

        //점수 매기기 - 매 칸마다의 점수임
        //F = G + H 
        //F - 최종 점수를 의미함 - 작을수록 좋음, 경로에 따라 달라짐
        //G - 시작점에서 해당 좌표까지 이동하는데 소요되는 비용(작을수록 좋음, 경로에 따라 달라짐)
        //H - 목적지에서 얼마나 가까운지(작을수록 좋음, 고정)
        //상하좌우을 예약하는데 그 후보 중에서 가장 좋은 점수가 확인되는 곳을 골라 이동한다

        //(y,x) 이미 방문 했는지 여부(방문 = closed 상태)
        bool[,] closed = new bool[_board.Size, _board.Size]; //CloseList, 기존에는 visited, found 등 으로 지었었음


        //(y,x) 가는 길을 한번이라도 발견 했었는지에 대한 배열, 발견X 라면 => MaxValue로 설정 해둠
        //발견했다면 F = G + H
        int[,] open = new int[_board.Size, _board.Size]; //OpenList
        for(int y=0; y< _board.Size; y++)
        {
            for (int x = 0; x < _board.Size; x++)
            {
                open[y, x] = Int32.MaxValue; //모든 칸에 발견하지 못했다는 의미로 MaxValue 넣어 초기화 시켜줌
            }
        }

        Pos[,] parent = new Pos[_board.Size, _board.Size];

        //openList에 있는 정보들 중에서 가장 좋은 후보를 빠르게 뽑아오기 위한 우선순위 큐
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>(); //-> 점수가 가장 낮은 것을 찾아오기 위한

        //시작점 발견(예약 진행) - H값을 넣어줘야함 
        /*F값 = */open[PosY, PosX] = /*G = 0 , H = */10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX)); //목적지에서 각각 x,y 좌표를 제외한 절대값
        //         시작점은 본인 자신이기 때문에 G = 0
        pq.Push(new PQNode() 
        { 
            F = 10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX)), 
            G = 0,
            Y = PosY, 
            X = PosX 
        });

        parent[PosY, PosX] = new Pos(PosY, PosX); //부모의 좌표를 찝어준다

        while(pq.Count>0)
        {
            //제일 좋은 후보 찾기
            PQNode node = pq.Pop(); //-> 가장 최소값

            //동일한 좌표를 여러 경로로 찾아서, 더 빠른 경로로 인해서 이미 방문(closed) 된 경우, 스킵
            //우리가 만든 PriorityQueue는 DecreaseKey가 없는 단순 Push/Pop이다. 
            // -> 그래서 같은 큐에 같은 키가 들어왔을 때(중복), 최적의 키만 남기고 더 나쁜 키는 버리는 기능이 없다
            // -> 중복되는 키가 생길수도 있어서 그걸 방지하기 위한 코드
            if (closed[node.Y, node.X])
                continue;

            //방문한다
            closed[node.Y, node.X] = true;

            //목적지에 도착하면 바로 종료 - 다른 길은 계산하지 않게
            if (node.Y == _board.DestY && node.X == _board.DestX)
                break;

            //방문한 좌표에서 상하좌우 등 이동할 수 있는 좌표인지 확인해서 예약(open)한다
            for(int i = 0; i< dY.Length/*8방향*/; i++)
            {
                //현재 위치에서 상,하,좌,우 를 확인하는거다
                int nextY = node.Y + dY[i]; 
                int nextX = node.X + dX[i];

                //유효범위 벗어나면 스킵
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                    continue;

                //벽으로 막혀있으면 스킵(연결이 끊기면 스킵)
                if (_board.Tiles[nextY, nextX] == TileType.Wall)
                    continue;

                //이미 방문했으면 스킵
                if (closed[nextY, nextX] == true)
                    continue;

                //비용계산
                int g = /*시작지점에서 여기까지 오는데의 비용*/ node.G + cost[i]; //?나를 꺼내온 부모의 G값에다가 나의 1 점수를 더해줌?
                int h = /*현재 나의 위치에서 골인까지 몇칸이 떨어져 있는지에 대한 점수*/10 * (Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestY + nextX));

                //다른 경로에서 더 빠른길을 이미 찾았으면 스킵
                if (open[nextY, nextX] < g + h)//--> 더 좋은값이 있다는 의미 , open배열에는 총점들이 다 저장되어있는거임!!!
                    continue;

                //예약 진행해줌
                open[nextY, nextX] = g + h;
                //큐에 삽입
                pq.Push(new PQNode() { F = g + h, G = g, Y = nextY, X = nextX });

                parent[nextY, nextX] = new Pos(node.Y, node.X); 
            }
        }
        CalcPathFromParent(parent);
    }

    void BFS()
    {
        int[] deltaY = new int[] { -1,0,1,0 };
        int[] deltaX = new int[] { 0,-1,0,1 };

        bool[,] found = new bool[_board.Size, _board.Size];
        Pos[,] parent = new Pos[_board.Size, _board.Size];

        //Stack<Pos> _points = new Stack<Pos>();

        Queue<Pos> queue = new Queue<Pos>();
        queue.Enqueue(new Pos(PosY, PosX));
        found[PosY, PosX] = true;
        parent[PosY, PosX] = new Pos(PosY, PosX);//자기자신을 부모로 설정해줌

        while (queue.Count > 0)
        {
            Pos pos = queue.Dequeue(); //첫 지점을 끄집어내서
            int nowY = pos.Y;
            int nowX = pos.X; //정수 형태로 만든다

            for(int i = 0; i<4;  i++)
            {
                int nextY = nowY + deltaY[i]; //i가 0일때 위, 1일때 아래,,.뭐 이런식으로 for문이 돌아가면서 모든 방향을 확인?
                int nextX = nowX + deltaX[i];

                //맵의 크기를 초과하지 않는지
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                    continue;

                //체크 하려는 점이 갈수 있는 점인지
                if (_board.Tiles[nextY, nextX] == TileType.Wall)
                    continue;

                //이미 찾았던 점이라면
                if (found[nextY, nextX] == true)
                    continue;

                queue.Enqueue(new Pos(nextY, nextX));
                found[nextY,nextX] = true;
                parent[nextY, nextX] = new Pos(nowY, nowX);
            }
        }

        CalcPathFromParent(parent);

        int y = _board.DestY;
        int x = _board.DestX;

        while (parent[y,x].Y != y ||  parent[y,x].X != x) //목적지 좌표부터 하나하나 거슬러 올라간다 시작지점까지 -> 최초지점이 아닐때만 반복임
        {
            //[0] -> 목적지
            //[1] -> 목적지의 부모
            //.....
            //[마지막인덱스] -> 최초 지점

            _points.Add(new Pos(y, x));
            Pos pos = parent[y,x];
            y = pos.Y;
            x = pos.X;
        }
        _points.Add(new Pos(y, x));

        _points.Reverse(); //-> 내부에 들어가 있는 정보들이 뒤집히게 된다
                           //[0] -> 최초지점
                           //[1] -> 최초지점 다음
                           //.....
                           //[마지막인덱스] -> 목적 지점
    }

    void CalcPathFromParent(Pos[,] parent)
    {
        int y = _board.DestY;
        int x = _board.DestX;

        while (parent[y, x].Y != y || parent[y, x].X != x) //목적지 좌표부터 하나하나 거슬러 올라간다 시작지점까지 -> 최초지점이 아닐때만 반복임
        {
            //[0] -> 목적지
            //[1] -> 목적지의 부모
            //.....
            //[마지막인덱스] -> 최초 지점

            _points.Add(new Pos(y, x));
            Pos pos = parent[y, x];
            y = pos.Y;
            x = pos.X;
        }
        _points.Add(new Pos(y, x));

        _points.Reverse(); //-> 내부에 들어가 있는 정보들이 뒤집히게 된다
                           //[0] -> 최초지점
                           //[1] -> 최초지점 다음
                           //.....
                           //[마지막인덱스] -> 목적 지점
    }

    //우수법 - (미로를 탈출하기 위한)오른손 법칙
    public void RightHand()
    {
        // 내가 바라보는 방향 기준 앞 방향 타일을 확인하기 위한 좌표
        int[] _frontY = new int[] { -1, 0, 1, 0 };
        int[] _frontX = new int[] { 0, -1, 0, 1 };

        // 내가 바라보는 방향 기준 오른쪽 방향 타일을 확인하기 위한 좌표
        int[] _rightY = new int[] { 0, -1, 0, 1 };
        int[] _rightX = new int[] { 1, 0, -1, 0 };

        _points.Add(new Pos(PosY, PosX));

        //목적지 계산 전 까지 계속 실행
        while (PosY != _board.DestY || PosX != _board.DestX) //보드의 목적지(보드 크기의 x,y에서 -2 한 값)까지 도달하지 않았으면 반복
        {
            // 1.현재 바라보는 방향 기준으로 오른쪽의 타일이 wall이 아니면? -> 갈수있으면 오른쪽으로 회전 한 후 한 칸 간다!
            //      ㄴ> 내가 보는 방향 기준의 "오른쪽" 타일을 확인해야함
            if (_board.Tiles[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
            {
                // 오른쪽 방향으로 90도 회전
                _dir = (_dir - 1 + 4) % 4; //-> 모듈러 연산(modular arithmetic)을 이용한 원형 인덱스(circular index)패턴
                                           // 모듈러 연산 = 나머지 연산 %을 사용해서 값의 범위를 고정하는 수학적 기법
                                           // 원형 인덱스 = 음수나 범위를 벗어난 값이 나오지 않도록 끝에 도달하면 다시 처음으로 돌아가는 구조
                /*switch(_dir)
                {
                    case (int)Dir.Up:
                        _dir = (int)Dir.Right; break;
                    case (int)Dir.Left:
                        _dir = (int)Dir.Up; break;
                    case (int)Dir.Down:
                        _dir = (int)Dir.Left; break;
                    case (int)Dir.Right:
                        _dir = (int)Dir.Down; break;
                }*/ //^이 코드의 축약버전

                // 앞으로 한 칸 전진
                PosY = PosY + _frontY[_dir]; //y축만을 움직이게 한다
                //PosY += _frontY[_dir]; 
                PosX = PosX + _frontX[_dir]; //x축만을 움직이게 한다

                _points.Add(new Pos(PosY, PosX));

            }

            // 2. 현재 바라보는 방향 기준으로 다음 타일이 wall이 아니면? 한 칸 간다!
            //      ㄴ> 오른쪽으로는 못가는거임? ㅇㅅㅇ
            else if (_board.Tiles[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
            {
                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));

                // 앞으로 한 칸 전진
            }
            // 3. 내 오른쪽, 내 앞 모두 벽이 있다면
            else
            {
                _dir = (_dir + 1 + 4) % 4;

                _points.Add(new Pos(PosY, PosX));
                // 왼쪽 방향으로 90도 회전 후 턴 넘기기
            }
        }
    }

    private void Update()
    {
        if (_lastIndex >= _points.Count)
            return;

        if (_isBoardCreated == false)
            return;
            
        _sumTick += Time.deltaTime;
        if (_sumTick < MOVE_TICK) //1초까지 기다리고 움직이게 한다
            return;

        _sumTick = 0;

        /*
        int dir = Random.Range(0, 4); //위아래왼쪽오른쪽으로 움직이는것 0,1,2,3

        int NextY = PosY;
        int NextX = PosX;

        switch (dir)
        {
            case 0:
                NextY = PosY - 1;
                break;
            case 1:
                NextY = PosY + 1;
                break;
            case 2:
                NextX = PosX - 1;
                break;
            case 3:
                NextX = PosX + 1;
                break;
        }

        if (NextY < 0 || NextY >= _board.Size) return;
        if (NextX < 0 || NextX >= _board.Size) return; //맵 빠져나가는거 방지
        if (_board.Tiles[NextY, NextX] == TileType.Wall) return; //벽으로 이동하는것 방지

        PosY = NextY;
        PosX = NextX;*///랜덤 움직임

        PosY = _points[_lastIndex].Y;
        PosX = _points[_lastIndex].X;
        _lastIndex++;
        
        transform.position = new Vector3(PosX, 0 ,-PosY);
    }
}
