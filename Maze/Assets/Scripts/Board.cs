using UnityEngine;

//큐브 모음들을 만들자
public enum TileType
{
    Empty,//빈공간
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
        DestX = Size - 2; //목적지 설정

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
        //일단 길 다 막음
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

        //랜덤으로 우측 혹은 아래로 길을 뚫음
        for(int y=0;y< Size;y++)
        {
            int count = 1;
            for(int x=0;x< Size;x++)
            {
                //아까 벽으로 막은 녀석은 건너뛴다
                if (x % 2 == 0 || y % 2 == 0)
                    continue;

                //가장 오른쪽 이고 가장 아래쪽 끝인 애는 건너뛴다
                if(y==Size-2 && x==Size-2)
                    continue;

                //가장 오른쪽 끝이면 무조건 벽 풀고 길로
                if(y==Size-2)
                {
                    Tiles[y, x + 1] = TileType.Empty;
                    continue;
                }

                //가장 아래쪽 끝이면 무조건 벽 풀고 길로
                if (x == Size - 2)
                {
                    Tiles[y+1 , x] = TileType.Empty;
                    continue;
                }

                //결국 x,y 좌표가 모두 홀수인 애들을 대상으로
                //0과 1중 랜덤 뽑음
                //0이면 오른쪽 길 뚫고 카운트 1 증가
                if(Random.Range(0,2)==0)
                {
                    Tiles[y, x + 1] = TileType.Empty ;
                    count++;
                }

                //1이면 아래쪽 길 뚫는데 여태까지 오른쪽으로 뚫었던 x중 한개를 골라서 뚫음
                else
                {
                    //            x - 라는건 지금 진행이 왼쪽에서 오른쪽으로 뚫고있었기 때문
                    //                                       * 2 해준 이유는 짝수좌표 애들이 있기 때문에 2를 곱해야 함
                    //                즉, 오른쪽으로 3번 뚫은 상태라면 -> 0 ,1 ,2중에 하나가 나올것이고
                    //                                                 만약 2가 나오면 *2를 해서 x-4 => 즉, 맨 왼쪽에서 아래로 길이 난다
                    Tiles[y + 1, x - Random.Range(0, count) * 2] = TileType.Empty;

                    //그리고 카운트를 초기화 시켜준다
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
