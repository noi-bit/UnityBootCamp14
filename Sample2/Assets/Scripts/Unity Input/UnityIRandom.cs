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
        rand = Random.Range(0, 10);//0~9
        // 0 1 2 3 4 5 6 7 8 9
        // 이중에서 9보다 작은 값이 뽑힐 확률? 90%
    }
}
