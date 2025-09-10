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

        _points.Clear(); //����Ʈ �ʱ�ȭ - Create���� ������ �̷� �����
        _lastIndex = 0;

        //BFS();
        AStar();
        _isBoardCreated = true;
    }

    struct PQNode : IComparable<PQNode>
    { 
        //struct �� ���� ����
        //1. �������̶� �� �Ҵ�/GC �δ� down
        // -> class�� ���������̶� new�� �����Ҷ����� ���� ��ü�� �����, GC�� ������ ����� ����
        //2. struct�� �� �����̶� ����(stack)�̳� �迭 ���ο� �ٷ� �����
        // -> �켱����ť���� ��û ���� ��带 push/pop �Ҷ�, GC Alloc�� �ٰ� ������ ������ �� ����
        //3. ũ�Ⱑ ���� ������ �����̱� ������ struct�� �����ϴ�
        // -> PQNode�� ��� �ִ� �ʵ尡 � �ȵɰŰ�, struct�� �׷� �������� ���� ����� ����
        // -> .net�� �����ΰ��̵忡�� ����ü�� 16byte �̳���� Ŭ�������� struct�� ���ɻ� �����ϴ� �����ִ�.
    
        public int F; //����
        public int G;
        public int Y;
        public int X;

        public int CompareTo(PQNode other)
        {
            if (F == other.F)
                return 0;

            return F < other.F ? 1 : -1;
            //���� F�� other.F�� ���ؼ� �� �۴ٴ°�? ���� F��ġ�� �������� �� �� ������
            // ----> �׷��� ������ 1�� ��ȯ�Ѵ�
        }
    }

    void AStar() //���ͽ�Ʈ��� ����ϸ鼭�� �ٸ�?
                 //����, �� ������ �ְ� - ó������ ���������� ���� ����� & ���������� �󸶳� ����������ִ����� ���� �������� �ο���
                 //�������� ������
    {
        //                    ��  �� �Ʒ� ����, + ���� �Ʒ��� �Ʒ����� ������
        int[]  dY = new int[] { -1, 0, 1, 0 , -1, 1, 1, -1};
        int[]  dX = new int[] { 0, -1, 0, 1 , -1, -1, 1, 1};
        int[] cost = new int[] {10,10,10,10, 14, 14, 14, 14}; //����ġ(G���� �����Ǿ��ִ�)

        //���� �ű�� - �� ĭ������ ������
        //F = G + H 
        //F - ���� ������ �ǹ��� - �������� ����, ��ο� ���� �޶���
        //G - ���������� �ش� ��ǥ���� �̵��ϴµ� �ҿ�Ǵ� ���(�������� ����, ��ο� ���� �޶���)
        //H - ���������� �󸶳� �������(�������� ����, ����)
        //�����¿��� �����ϴµ� �� �ĺ� �߿��� ���� ���� ������ Ȯ�εǴ� ���� ��� �̵��Ѵ�

        //(y,x) �̹� �湮 �ߴ��� ����(�湮 = closed ����)
        bool[,] closed = new bool[_board.Size, _board.Size]; //CloseList, �������� visited, found �� ���� ��������


        //(y,x) ���� ���� �ѹ��̶� �߰� �߾������� ���� �迭, �߰�X ��� => MaxValue�� ���� �ص�
        //�߰��ߴٸ� F = G + H
        int[,] open = new int[_board.Size, _board.Size]; //OpenList
        for(int y=0; y< _board.Size; y++)
        {
            for (int x = 0; x < _board.Size; x++)
            {
                open[y, x] = Int32.MaxValue; //��� ĭ�� �߰����� ���ߴٴ� �ǹ̷� MaxValue �־� �ʱ�ȭ ������
            }
        }

        Pos[,] parent = new Pos[_board.Size, _board.Size];

        //openList�� �ִ� ������ �߿��� ���� ���� �ĺ��� ������ �̾ƿ��� ���� �켱���� ť
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>(); //-> ������ ���� ���� ���� ã�ƿ��� ����

        //������ �߰�(���� ����) - H���� �־������ 
        /*F�� = */open[PosY, PosX] = /*G = 0 , H = */10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX)); //���������� ���� x,y ��ǥ�� ������ ���밪
        //         �������� ���� �ڽ��̱� ������ G = 0
        pq.Push(new PQNode() 
        { 
            F = 10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX)), 
            G = 0,
            Y = PosY, 
            X = PosX 
        });

        parent[PosY, PosX] = new Pos(PosY, PosX); //�θ��� ��ǥ�� ����ش�

        while(pq.Count>0)
        {
            //���� ���� �ĺ� ã��
            PQNode node = pq.Pop(); //-> ���� �ּҰ�

            //������ ��ǥ�� ���� ��η� ã�Ƽ�, �� ���� ��η� ���ؼ� �̹� �湮(closed) �� ���, ��ŵ
            //�츮�� ���� PriorityQueue�� DecreaseKey�� ���� �ܼ� Push/Pop�̴�. 
            // -> �׷��� ���� ť�� ���� Ű�� ������ ��(�ߺ�), ������ Ű�� ����� �� ���� Ű�� ������ ����� ����
            // -> �ߺ��Ǵ� Ű�� ������� �־ �װ� �����ϱ� ���� �ڵ�
            if (closed[node.Y, node.X])
                continue;

            //�湮�Ѵ�
            closed[node.Y, node.X] = true;

            //�������� �����ϸ� �ٷ� ���� - �ٸ� ���� ������� �ʰ�
            if (node.Y == _board.DestY && node.X == _board.DestX)
                break;

            //�湮�� ��ǥ���� �����¿� �� �̵��� �� �ִ� ��ǥ���� Ȯ���ؼ� ����(open)�Ѵ�
            for(int i = 0; i< dY.Length/*8����*/; i++)
            {
                //���� ��ġ���� ��,��,��,�� �� Ȯ���ϴ°Ŵ�
                int nextY = node.Y + dY[i]; 
                int nextX = node.X + dX[i];

                //��ȿ���� ����� ��ŵ
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                    continue;

                //������ ���������� ��ŵ(������ ����� ��ŵ)
                if (_board.Tiles[nextY, nextX] == TileType.Wall)
                    continue;

                //�̹� �湮������ ��ŵ
                if (closed[nextY, nextX] == true)
                    continue;

                //�����
                int g = /*������������ ������� ���µ��� ���*/ node.G + cost[i]; //?���� ������ �θ��� G�����ٰ� ���� 1 ������ ������?
                int h = /*���� ���� ��ġ���� ���α��� ��ĭ�� ������ �ִ����� ���� ����*/10 * (Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestY + nextX));

                //�ٸ� ��ο��� �� �������� �̹� ã������ ��ŵ
                if (open[nextY, nextX] < g + h)//--> �� �������� �ִٴ� �ǹ� , open�迭���� �������� �� ����Ǿ��ִ°���!!!
                    continue;

                //���� ��������
                open[nextY, nextX] = g + h;
                //ť�� ����
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
        parent[PosY, PosX] = new Pos(PosY, PosX);//�ڱ��ڽ��� �θ�� ��������

        while (queue.Count > 0)
        {
            Pos pos = queue.Dequeue(); //ù ������ �������
            int nowY = pos.Y;
            int nowX = pos.X; //���� ���·� �����

            for(int i = 0; i<4;  i++)
            {
                int nextY = nowY + deltaY[i]; //i�� 0�϶� ��, 1�϶� �Ʒ�,,.�� �̷������� for���� ���ư��鼭 ��� ������ Ȯ��?
                int nextX = nowX + deltaX[i];

                //���� ũ�⸦ �ʰ����� �ʴ���
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                    continue;

                //üũ �Ϸ��� ���� ���� �ִ� ������
                if (_board.Tiles[nextY, nextX] == TileType.Wall)
                    continue;

                //�̹� ã�Ҵ� ���̶��
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

        while (parent[y,x].Y != y ||  parent[y,x].X != x) //������ ��ǥ���� �ϳ��ϳ� �Ž��� �ö󰣴� ������������ -> ���������� �ƴҶ��� �ݺ���
        {
            //[0] -> ������
            //[1] -> �������� �θ�
            //.....
            //[�������ε���] -> ���� ����

            _points.Add(new Pos(y, x));
            Pos pos = parent[y,x];
            y = pos.Y;
            x = pos.X;
        }
        _points.Add(new Pos(y, x));

        _points.Reverse(); //-> ���ο� �� �ִ� �������� �������� �ȴ�
                           //[0] -> ��������
                           //[1] -> �������� ����
                           //.....
                           //[�������ε���] -> ���� ����
    }

    void CalcPathFromParent(Pos[,] parent)
    {
        int y = _board.DestY;
        int x = _board.DestX;

        while (parent[y, x].Y != y || parent[y, x].X != x) //������ ��ǥ���� �ϳ��ϳ� �Ž��� �ö󰣴� ������������ -> ���������� �ƴҶ��� �ݺ���
        {
            //[0] -> ������
            //[1] -> �������� �θ�
            //.....
            //[�������ε���] -> ���� ����

            _points.Add(new Pos(y, x));
            Pos pos = parent[y, x];
            y = pos.Y;
            x = pos.X;
        }
        _points.Add(new Pos(y, x));

        _points.Reverse(); //-> ���ο� �� �ִ� �������� �������� �ȴ�
                           //[0] -> ��������
                           //[1] -> �������� ����
                           //.....
                           //[�������ε���] -> ���� ����
    }

    //����� - (�̷θ� Ż���ϱ� ����)������ ��Ģ
    public void RightHand()
    {
        // ���� �ٶ󺸴� ���� ���� �� ���� Ÿ���� Ȯ���ϱ� ���� ��ǥ
        int[] _frontY = new int[] { -1, 0, 1, 0 };
        int[] _frontX = new int[] { 0, -1, 0, 1 };

        // ���� �ٶ󺸴� ���� ���� ������ ���� Ÿ���� Ȯ���ϱ� ���� ��ǥ
        int[] _rightY = new int[] { 0, -1, 0, 1 };
        int[] _rightX = new int[] { 1, 0, -1, 0 };

        _points.Add(new Pos(PosY, PosX));

        //������ ��� �� ���� ��� ����
        while (PosY != _board.DestY || PosX != _board.DestX) //������ ������(���� ũ���� x,y���� -2 �� ��)���� �������� �ʾ����� �ݺ�
        {
            // 1.���� �ٶ󺸴� ���� �������� �������� Ÿ���� wall�� �ƴϸ�? -> ���������� ���������� ȸ�� �� �� �� ĭ ����!
            //      ��> ���� ���� ���� ������ "������" Ÿ���� Ȯ���ؾ���
            if (_board.Tiles[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
            {
                // ������ �������� 90�� ȸ��
                _dir = (_dir - 1 + 4) % 4; //-> ��ⷯ ����(modular arithmetic)�� �̿��� ���� �ε���(circular index)����
                                           // ��ⷯ ���� = ������ ���� %�� ����ؼ� ���� ������ �����ϴ� ������ ���
                                           // ���� �ε��� = ������ ������ ��� ���� ������ �ʵ��� ���� �����ϸ� �ٽ� ó������ ���ư��� ����
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
                }*/ //^�� �ڵ��� ������

                // ������ �� ĭ ����
                PosY = PosY + _frontY[_dir]; //y�ุ�� �����̰� �Ѵ�
                //PosY += _frontY[_dir]; 
                PosX = PosX + _frontX[_dir]; //x�ุ�� �����̰� �Ѵ�

                _points.Add(new Pos(PosY, PosX));

            }

            // 2. ���� �ٶ󺸴� ���� �������� ���� Ÿ���� wall�� �ƴϸ�? �� ĭ ����!
            //      ��> ���������δ� �����°���? ������
            else if (_board.Tiles[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
            {
                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));

                // ������ �� ĭ ����
            }
            // 3. �� ������, �� �� ��� ���� �ִٸ�
            else
            {
                _dir = (_dir + 1 + 4) % 4;

                _points.Add(new Pos(PosY, PosX));
                // ���� �������� 90�� ȸ�� �� �� �ѱ��
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
        if (_sumTick < MOVE_TICK) //1�ʱ��� ��ٸ��� �����̰� �Ѵ�
            return;

        _sumTick = 0;

        /*
        int dir = Random.Range(0, 4); //���Ʒ����ʿ��������� �����̴°� 0,1,2,3

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
        if (NextX < 0 || NextX >= _board.Size) return; //�� ���������°� ����
        if (_board.Tiles[NextY, NextX] == TileType.Wall) return; //������ �̵��ϴ°� ����

        PosY = NextY;
        PosX = NextX;*///���� ������

        PosY = _points[_lastIndex].Y;
        PosX = _points[_lastIndex].X;
        _lastIndex++;
        
        transform.position = new Vector3(PosX, 0 ,-PosY);
    }
}
