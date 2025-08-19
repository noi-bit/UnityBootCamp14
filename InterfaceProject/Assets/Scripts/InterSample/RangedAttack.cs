using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Ranged")]
public class RangedAttack : ScriptableObject, IAttackStrategy , IDamageinput
{
    SpriteRenderer sr;
    //public GameObject RangeTarget;

    public void Attack(GameObject target)
    {
        Debug.Log("[���� ����!] " + target.name);
    }

    public void Damage(GameObject target, int damage)
    {
        sr = target.GetComponent<SpriteRenderer>();
        Debug.Log($"{target.name}�� {damage}��ŭ�� ���ظ� �Ծ���!");
        sr.color = Color.red;
    }
   
}
