using System.Collections.Generic;
using UnityEngine;
//6번째 스크립트
//오브젝트 풀링(Object Pooling)
//  : 자주 생성되고 소멸되는 오브젝트를 미리 일정량 생성해두고
//    필요할 때 활성화하고 사용하지 않을 때 비활성화 하는식으로 재사용을 진행하는 방식의 설계 패턴

//사용목적) 탄알, 이펙트, 데미지 텍스트, 몬스터 처럼 자주 생성되고 사라지는 값들을
//          매번 new, destroy를 통해 생성 삭제가 발생하면 GC가 많이 호출되고
//          이는 성능 저하로 이어질수 있기에 성능 향상을 목적으로 사용

//EX) 발사 총알 수 30개/ 생성될 몬스터 20마리 - 이런 것들을 미리 한번에 다 생성
//    안쓰는 값들은 비활성화 해놓는다

public class BulletPool : MonoBehaviour
{
    public GameObject bullet_prefab;
    public int size = 30;//총알 30개 생성

    //풀로 자주 사용되는 자료구조
    //1. 리스트(List) : 데이터를 순차적으로 저장하고, 추가, 삭제가 자유롭기 때문에 효과적
    //2. 큐(Queue) : 데이터가 들어온 순서대로 데이터가 빠져나가는 형태의 자료구조
    private List<GameObject> pool;

    private void Start()
    {
        //총알 생성
        pool = new List<GameObject>();//pool -> public Gameobject bullet_prefab;으로 추가적으로 생성된 오브젝트들의 리스트
                                      
        for (int i = 0; i< size; i++)//size(갯수,30개)만큼..0,30 이니 30개
        {
            var bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = transform;//생성된 총알은 현재 스크립트를 가진 오브젝트의 자식으로써 생성됨

            bullet.SetActive(false);//비활성화 설정

            bullet.GetComponent<Bullet>().SetPool(this);//새로 생성된 불릿의 풀은 "여기"라고 말해줌

            pool.Add(bullet);//리스트명.Add(값) -> 리스트에 해당 값을 추가하는 문법
        }
    }

    public GameObject GetBullet()
    {
        //비활성화 되어있는 총알을 찾아서 활성화함
        foreach(var bullet in pool)
        {
            //1. 계층창에서 활성화가 안되어있다면
            if(!bullet.activeInHierarchy)
            {
                //2. bullet을 활성화 시킨 후
                bullet.SetActive(true);
                //3. return 한다
                return bullet;
            }
        }
        //총알이 부족한 경우에는 새롭게 만들어서 리스트(pool)에 등록
        var new_bullet = Instantiate(bullet_prefab);
        new_bullet.transform.parent = transform;
        new_bullet.GetComponent<Bullet>().SetPool(this);
        pool.Add(new_bullet);
        return new_bullet;
    }
    
    public void Return(GameObject bullet)//반납
    {
        bullet.SetActive(false);
    }
}
