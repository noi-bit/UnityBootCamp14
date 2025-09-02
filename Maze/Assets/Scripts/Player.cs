using NUnit.Framework;
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

    enum Dir
    {
        Up = 0,
        Left = 1,
        Down = 2,
        Right = 3
    }

    int _dir = (int)Dir.Up;

    List<Pos> _points = new List<Pos>();


    //우수법 - (미로를 탈출하기 위한)오른손 법칙
    public void Initialze(int posY, int posX, Board board)
    {
        PosY = posY;
        PosX = posX;
        _board = board;

        transform.position = new Vector3(PosX, 0, -PosY);

        // 내가 바라보는 방향 기준 앞 방향 타일을 확인하기 위한 좌표
        int[] _frontY = new int[] { -1, 0, 1, 0};
        int[] _frontX = new int[] { 0, -1, 0, 1};

        // 내가 바라보는 방향 기준 오른쪽 방향 타일을 확인하기 위한 좌표
        int[] _rightY = new int[] {0, -1, 0, 1 };
        int[] _rightX = new int[] {1, 0, -1, 0 };

        _points.Add(new Pos(PosY, PosX));

        //목적지 계산 전 까지 계속 실행
        while (PosY != board.DestY || PosX != board.DestX) //보드의 목적지(보드 크기의 x,y에서 -2 한 값)까지 도달하지 않았으면 반복
        {
            // 1.현재 바라보는 방향 기준으로 오른쪽의 타일이 wall이 아니면? -> 갈수있으면 오른쪽으로 회전 한 후 한 칸 간다!
            //      ㄴ> 내가 보는 방향 기준의 "오른쪽" 타일을 확인해야함
            if (board.Tiles[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
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
            else if (board.Tiles[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
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
        _isBoardCreated = true;
    }

    private const float MOVE_TICK = 0.1f;
    private int _lastIndex = 0;
    private float _sumTick = 0;

    private void Update()
    {
        if (_lastIndex >= _points.Count)
            return;

        if (_isBoardCreated == false)
            return;
            
        _sumTick += Time.deltaTime;

        if (_sumTick < MOVE_TICK) //1초까지 기다린다
            return;

        _sumTick = 0;

        //int dir = Random.Range(0, 4); //위아래왼쪽오른쪽으로 움직이는것 0,1,2,3

        //int NextY = PosY;
        //int NextX = PosX;

        //switch (dir)
        //{
        //    case 0:
        //        NextY = PosY - 1;
        //        break;
        //    case 1:
        //        NextY = PosY + 1;
        //        break;
        //    case 2:
        //        NextX = PosX - 1;
        //        break;
        //    case 3:
        //        NextX = PosX + 1;
        //        break;
        //}

        //if (NextY < 0 || NextY >= _board.Size) return;
        //if (NextX < 0 || NextX >= _board.Size) return; //맵 빠져나가는거 방지
        //if (_board.Tiles[NextY, NextX] == TileType.Wall) return; //벽으로 이동하는것 방지

        //PosY = NextY;
        //PosX = NextX;

        PosY = _points[_lastIndex].Y;
        PosX = _points[_lastIndex].X;
        _lastIndex++;
        
        transform.position = new Vector3(PosX, 0 ,-PosY);
    }
}
