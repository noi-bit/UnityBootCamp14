using UnityEngine;

public class UnityIRandom : MonoBehaviour
{
    [ContextMenuItem("랜덤 값 호출","MenuAttributesMethod")]
    public int rand;

    public void MenuAttributesMethod()
    {
        //Random.Range() : 유니티의 랜덤
        //최소값 범위포함~ 최대값 포함X (정수일경우)

        //최소값 범위 포함~ 최대값 포함O (실수일경우)
        rand = Random.Range(0, 11);//0~10
    }
}
