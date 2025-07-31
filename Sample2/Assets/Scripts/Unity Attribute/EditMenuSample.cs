using UnityEngine;

//에디터모드 상태에서 Update, OnEnable, OnDisable의 실행을 진행할 수 있다
//Play를 누르지 않아도 Editor 내에서 Update 등에 설계한 기능들을 실행해 볼 수 있다
//[ExecuteInEditMode]
public class EditMenuSample : MonoBehaviour
{
    void Update()
    {
        //에디터에서만 실행해보는 코드(실제 플레이에서는 실행할수 없게)
        //별도로 테스트해야하는 상황일 시 사용할수 있을듯?
        if(!Application.isPlaying)
        {
            Vector3 pos = transform.position;//이 스크립트를 낀 오브젝트의 transform.position
            pos.y = 0;
            transform.position = pos;

            Debug.Log("Editor Test...(이 스크립트를 낀 오브젝트는 y축이 0으로 고정됩니다.)");
        }
    }
}
