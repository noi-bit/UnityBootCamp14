using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Ranged")]
public class RangedAttack : ScriptableObject, IAttackStrategy , IDamageinput
{
    SpriteRenderer sr;
    //public GameObject RangeTarget;

    public void Attack(GameObject target)
    {
        Debug.Log("[마법 공격!] " + target.name);
    }

    public void Damage(GameObject target, int damage)
    {
        sr = target.GetComponent<SpriteRenderer>();
        Debug.Log($"{target.name}가 {damage}만큼의 피해를 입었다!");
        sr.color = Color.red;
    }
   
}
