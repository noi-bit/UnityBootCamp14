using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Attack Strategy/Wongiiokk")]
public class CastedAttack : ScriptableObject, Wongiiokk
{
    SpriteRenderer sr;
    Transform tr;
    public void Attack(GameObject target)
    {
        sr = target.GetComponent<SpriteRenderer>();
        tr = target.GetComponent<Transform>();
        Debug.Log("[원기옥!]" + target.name + "[공격]");
        sr.color = Color.darkRed;
        tr.Translate(0, 3, 0);
    }

    public void DamageOutText(Text text, int damage)
    {
        text.text = "원기옥 발사!! 데미지 :" + damage;
    }
}
