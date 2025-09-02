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

    /*public void BFS(int start) //-> ������ ��ŸƮ?
    {
        found = new bool[6]; //�湮���
                             //->�� ������ �� ����?

        Queue<int> queue = new Queue<int>(); //������

        //1.�����Ͽ� �����ϱ�
        //�����Ͽ� ���������� ����Ѵ�
        queue.Enqueue(start);

        //start �湮 ó��
        found[start] = true;
        parent[start] = start;
        distance[start] = 0;

        while (queue.Count > 0)
        {
            //2.�����Ͽ��� ������ �����ͼ�
            int now = queue.Dequeue();
            Console.WriteLine($"BFS - {now}�� �湮�߾�~");
            //���� ���� ���� vertex�� ���� �����ϱ�
            for (int next = 0; next < 6; next++)
            {
                //������ �ȵǾ������� �ѱ��(continue)
                if (adj[now, next] == 0)
                    continue;

                //������ �Ǿ������� ������ �Ǿ��ִ��� Ȯ��,
                //������ �Ǿ������� �ѱ��
                if (found[next] == true)
                    continue;

                //�����ϱ�
                queue.Enqueue(next);

                //�����ѳ� ã�������� ����
                found[next] = true;

                //ã������ �θ�� now
                parent[next] = now;

                //ã������ �Ÿ��� �θ� + 1�� ���ָ� ��
                //����ġ�� �ִٸ� �� �ش� ����ġ �迭�� index�� �߰��ϸ� �ǰ���?
                distance[next] = distance[now] + 1;
                Console.WriteLine(distance[next]);
            }
        }
    }*/
}
