using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T> //싱글톤들의 베이스클래스 - 나를 상속받는 녀석이 T로 들어가는 객체만 들어올 수 있음
{
    protected bool m_IsDestroyOnLoad = false; //OnDestroyOnLoad 여부(true면 유지 false면 삭제가능)

    // 이 클래스의 스태틱 인스턴스 변수
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
            Destroy(gameObject); //이미 싱글톤이 만들어져있으면 Destroy
        }
    }

    //객체가 파괴될때 호출
    protected virtual void OnDestroy()
    {
        Dispose();
    }

    //객체 파괴될때 처리할 작업
    protected virtual void Dispose()
    {
        m_Instance = null;
    }

}
