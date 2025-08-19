using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Bullet Fire")]
    [Tooltip("총알 생산 공장")]public GameObject bulletFactory;
    [Tooltip("총구(발사)")]public GameObject firePosition;

    private void Update()
    {
        //GetKeyXXX : KeyCode에 등록되어있는 키 입력
        //GetButtonXXX : Axes 키에 대한 입력
        //GetMouseButtonXXX : 마우스 클릭 설정
        if(Input.GetButtonDown("Fire1")) //Fire1이라는 버튼을 눌렀을 때
        {
            //총알은 총알생산공장 에서 등록한 총알을 생성
            //총알의 위치는 총구 지점으로 설정
            //별도의 회전 X
            var bullet = Instantiate(bulletFactory, firePosition.transform.position, Quaternion.identity); //bullet생성(bulletFactory)
        }
    }
}
