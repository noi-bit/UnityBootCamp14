using UnityEngine;
//6-1번째 스크립트
//풀링을 사용하려면 최소한 3개
    //풀 만들어줄 스크립트
    //풀 사용할 스크립트
    //발사하는 물체의 스크립트

//이 코드는 총알에 대한 발사(생성) 기능만 담당
public class Fire : MonoBehaviour
{
    //총알 발사를 위한 풀
    public BulletPool pool;

    //총알 발사 지점
    public Transform pos;

    //총알 발사 속도
    public float speed = 2f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = pool.GetBullet();
            bullet.transform.position = pos.position;
            bullet.transform.rotation = pos.rotation;
        }
    }

}
