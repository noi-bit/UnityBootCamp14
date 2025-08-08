using System.Collections.Generic; //<T>를 사용하려면
using UnityEngine;

public class DTrigger : MonoBehaviour
{
    public List<Dialog> scripts; //여기서 scripts 는 영단어 뜻 자체로 대사
    
    public void OnDTriggerEnter()
    {
        if(scripts != null && scripts.Count > 0)
        {
            DialogManager.Instance.StartLine(scripts);
            //클래스명.Instance.메소드명()과 같이 클래스의 값을 바로 사용할 수 있다(왠만하면 Instance는 Instance라는 이름으로 통일)
            //static이기 때문에 GetComponent나 public 등으로 등록할 필요 X
            
        }
    }
}
