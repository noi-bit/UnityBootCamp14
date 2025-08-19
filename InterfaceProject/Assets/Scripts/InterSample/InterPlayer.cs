using UnityEngine;
using UnityEngine.UI;

public class InterPlayer : MonoBehaviour
{
    //SerializeField 인스펙터 내에서 접근 가능(내부 데이터 연결)
    //외부에서 접근 불가(함부로 값 쓰지 말라는 용도)
    [SerializeField] private ScriptableObject attackObject;
    
    private IDamageinput strategy; //인터페이스는 인스턴스를 만들 수가 없음
    public int damage;

    private void Awake()
    {
        strategy = attackObject as IDamageinput;

        if(strategy == null )
        {
            Debug.LogError("공격 기능이 구현되지 않았습니다!");
        }
    }
   
    public void ActionPrefromed(GameObject target)
    {         //타겟에 대한 액션 실행 - 버튼에서 연결 가능
        strategy?.Attack(target);
        strategy?.Damage(target, damage);
        //Nullable<T> or T? 는 Value 에 대한 null 허용을 위한 도구(null이라고 표현할 수 있게 해줌 int에도)
    }
}
