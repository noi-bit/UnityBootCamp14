using UnityEngine;

//ť�� �������� ������
public enum TileType
{
    Empty,//�����
    Wall,
    Goal
}

public class Board : MonoBehaviour
{
    public TileType[,] Tiles;
    public int Size { get; set; }

    public int DestY { get; set; }
    public int DestX { get; set; }

    Material emptyMat;
    Material wallMat;
    Material goalMat;

    public void initialze()
    {
        DestY = Size - 2;
        DestX = Size - 2; //������ ����

        emptyMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        emptyMat.color = Color.gray;

        wallMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        wallMat.color = Color.white;

        goalMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        goalMat.color = Color.green;

        Tiles = new TileType[Size, Size];
        Size = Size;

        for(int y = 0; y< Size; y++)
        {
            for(int x = 0; x< Size; x++)
            {
                if(x%2==0 || y%2==0)
                {
                    Tiles[y, x] = TileType.Wall;
                }
                else
                {
                    Tiles[y, x] = TileType.Empty;
                }
            }
        }

        GeneratebySideWinder();
        Camera.main.transform.position = new Vector3(Size / 2, Size, -Size / 2);
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }

    private void GeneratebySideWinder()
    {
        //�ϴ� �� �� ����
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                {
                    Tiles[y, x] = TileType.Wall;
                }

                else if(x==DestX && y==DestY)
                {
                    Tiles[y, x] = TileType.Goal;
                }

                else
                {
                    Tiles[y, x] = TileType.Empty;
                }
            }
        }

        //�������� ���� Ȥ�� �Ʒ��� ���� ����
        for(int y=0;y< Size;y++)
        {
            int count = 1;
            for(int x=0;x< Size;x++)
            {
                //�Ʊ� ������ ���� �༮�� �ǳʶڴ�
                if (x % 2 == 0 || y % 2 == 0)
                    continue;

                //���� ������ �̰� ���� �Ʒ��� ���� �ִ� �ǳʶڴ�
                if(y==Size-2 && x==Size-2)
                    continue;

                //���� ������ ���̸� ������ �� Ǯ�� ���
                if(y==Size-2)
                {
                    Tiles[y, x + 1] = TileType.Empty;
                    continue;
                }

                //���� �Ʒ��� ���̸� ������ �� Ǯ�� ���
                if (x == Size - 2)
                {
                    Tiles[y+1 , x] = TileType.Empty;
                    continue;
                }

                //�ᱹ x,y ��ǥ�� ��� Ȧ���� �ֵ��� �������
                //0�� 1�� ���� ����
                //0�̸� ������ �� �հ� ī��Ʈ 1 ����
                if(Random.Range(0,2)==0)
                {
                    Tiles[y, x + 1] = TileType.Empty ;
                    count++;
                }

                //1�̸� �Ʒ��� �� �մµ� ���±��� ���������� �վ��� x�� �Ѱ��� ��� ����
                else
                {
                    //            x - ��°� ���� ������ ���ʿ��� ���������� �հ��־��� ����
                    //                                       * 2 ���� ������ ¦����ǥ �ֵ��� �ֱ� ������ 2�� ���ؾ� ��
                    //                ��, ���������� 3�� ���� ���¶�� -> 0 ,1 ,2�߿� �ϳ��� ���ð��̰�
                    //                                                 ���� 2�� ������ *2�� �ؼ� x-4 => ��, �� ���ʿ��� �Ʒ��� ���� ����
                    Tiles[y + 1, x - Random.Range(0, count) * 2] = TileType.Empty;

                    //�׸��� ī��Ʈ�� �ʱ�ȭ �����ش�
                    count = 1;
                }
            }
        }
    }

    public void Spawn()
    {
        for(int y = 0; y< Size; y++)
        {
            for(int x = 0; x< Size; x++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(x, 0, -y);
                go.transform.parent = transform;

                if (Tiles[y,x] == TileType.Empty || Tiles[y, x] == TileType.Goal)
                    go.transform.localScale = new Vector3(1, 0.1f, 1);
                else
                    go.transform.localScale = new Vector3(1f,2f,1f);

                go.GetComponent<MeshRenderer>().sharedMaterial = GetTileColor(Tiles[y, x]);
            }
        }
    }

    private Material GetTileColor(TileType type)
    {
        switch(type)
        {
            case TileType.Empty:
                return emptyMat;
            case TileType.Wall:
                return wallMat;
            case TileType.Goal:
                return goalMat;
        }
        return wallMat;
    }

    
}
