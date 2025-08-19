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
        Debug.Log("[�����!]" + target.name + "[����]");
        sr.color = Color.darkRed;
        tr.Translate(0, 3, 0);
    }

    public void DamageOutText(Text text, int damage)
    {
        text.text = "����� �߻�!! ������ :" + damage;
    }
}
