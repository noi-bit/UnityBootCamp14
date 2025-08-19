using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Melee")]
public class MeleeAttack : ScriptableObject, IAttackStrategy
{
    public void Attack(GameObject target)
    {
        Debug.Log("[���� ����!] " + target.name );
    }
}
