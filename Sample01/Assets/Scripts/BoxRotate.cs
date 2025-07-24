using UnityEngine;

public class BoxRotate : MonoBehaviour
{
    public Vector3 pos;

    private void Start()
    {
        pos = new Vector3(0, 40, 10);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(pos*Time.deltaTime);
        //델타타임 : 이전 프레임부터 현재 프레임까지 걸린 시간
        //update에서의 보정 값으로 활용
        //해당 좌표만큼 게임 오브젝트를 회전시킵니다(이 스크립트가 적용되는 오브젝트)
    }
}
