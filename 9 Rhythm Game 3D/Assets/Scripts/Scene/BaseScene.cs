using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{//�갡 ���� �������� �ʰ� Scene�� ���� �ڽĵ��� �긦 ȣ����
    public EnumData.Scene SceneType { get; protected set; }

    void Awake()
    {
        Init();
    }
    
    protected virtual void Init()
    {
        if(SceneType == EnumData.Scene.Title)
        Debug.Log("Ÿ��Ʋ �� ����");
        if (SceneType == EnumData.Scene.Game)
        Debug.Log("���� �� ����");

        //GameManager.Resources./*SO�������� �ҷ����� �Լ� �ۼ�*/;
    }

    protected virtual void MoveScene()
    {
        Debug.Log("���� �̵��մϴ�");
    }

    public abstract void Clear();
}
