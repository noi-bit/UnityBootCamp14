using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T> //�̱������ ���̽�Ŭ���� - ���� ��ӹ޴� �༮�� T�� ���� ��ü�� ���� �� ����
{
    protected bool m_IsDestroyOnLoad = false; //OnDestroyOnLoad ����(true�� ���� false�� ��������)

    // �� Ŭ������ ����ƽ �ν��Ͻ� ����
    protected static T m_Instance;

    public static T instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        if(m_Instance == null)
        {
            m_Instance = (T)this;

            if(!m_IsDestroyOnLoad)
            {
                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(gameObject); //�̹� �̱����� ������������� Destroy
        }
    }

    //��ü�� �ı��ɶ� ȣ��
    protected virtual void OnDestroy()
    {
        Dispose();
    }

    //��ü �ı��ɶ� ó���� �۾�
    protected virtual void Dispose()
    {
        m_Instance = null;
    }

}
