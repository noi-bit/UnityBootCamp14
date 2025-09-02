using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SliderControler _sliderControler;
    [SerializeField] private Button _createMazeButton;
    [SerializeField] private Text _text;

    [SerializeField] private Board _board;
    [SerializeField] private Player _player;

    private void Start()
    {
        _sliderControler.SliderValueChange += SetSlideValue;
        _createMazeButton.onClick.AddListener(CreateMaze);
    }

    private void SetSlideValue(float val)
    {
        _text.text = val.ToString();
        _board.Size = (int)val;
    }

    private void CreateMaze()
    {
        _board.initialze();
        _board.Spawn();

        _player.Initialze(1,1,_board);
    }

    /*public void BFS(int start) //-> 보드의 스타트?
    {
        found = new bool[6]; //방문목록
                             //->각 지점의 끝 개수?

        Queue<int> queue = new Queue<int>(); //예약목록

        //1.예약목록에 예약하기
        //예약목록에 시작지점을 등록한다
        queue.Enqueue(start);

        //start 방문 처리
        found[start] = true;
        parent[start] = start;
        distance[start] = 0;

        while (queue.Count > 0)
        {
            //2.예약목록에서 예약을 꺼내와서
            int now = queue.Dequeue();
            Console.WriteLine($"BFS - {now}를 방문했어~");
            //아직 예약 안한 vertex들 전부 예약하기
            for (int next = 0; next < 6; next++)
            {
                //연결이 안되어있으면 넘기고(continue)
                if (adj[now, next] == 0)
                    continue;

                //연결이 되어있으면 예약이 되어있는지 확인,
                //예약이 되어있으면 넘긴다
                if (found[next] == true)
                    continue;

                //예약하기
                queue.Enqueue(next);

                //예약한놈 찾은놈으로 설정
                found[next] = true;

                //찾은놈의 부모는 now
                parent[next] = now;

                //찾은놈의 거리는 부모 + 1을 해주면 됨
                //가중치가 있다면 그 해당 가중치 배열의 index를 추가하면 되겠지?
                distance[next] = distance[now] + 1;
                Console.WriteLine(distance[next]);
            }
        }
    }*/
}
