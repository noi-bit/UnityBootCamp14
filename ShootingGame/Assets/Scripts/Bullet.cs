using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet : 지속적으로 위로 올라가는 코드
    public float speed = 5;


    private void Update()
    {
        Vector3 dir = Vector3.up; //위로 가는 방향

        transform.position += dir * speed * Time.deltaTime;
    }

}
