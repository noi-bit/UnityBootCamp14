using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{//�갡 ���� �������� �ʰ� Scene�� �ڽĵ��� �پ �³װ� ȣ����
    public EnumData.Scene SceneType { get; protected set; }

    void Awake()
    {
        Init();
    }
    
    protected virtual void Init()
    {
        //GameManager.Resources./*SO�������� �ҷ����� �Լ� �ۼ�*/;
    }

    protected virtual void MoveScene()
    {
        Debug.Log("���� �̵��մϴ�");
    }

    public abstract void Clear();
}
