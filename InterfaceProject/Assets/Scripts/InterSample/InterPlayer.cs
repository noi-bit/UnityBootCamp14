using UnityEngine;
using UnityEngine.UI;

public class InterPlayer : MonoBehaviour
{
    //SerializeField �ν����� ������ ���� ����(���� ������ ����)
    //�ܺο��� ���� �Ұ�(�Ժη� �� ���� ����� �뵵)
    [SerializeField] private ScriptableObject attackObject;
    
    private IDamageinput strategy; //�������̽��� �ν��Ͻ��� ���� ���� ����
    public int damage;

    private void Awake()
    {
        strategy = attackObject as IDamageinput;

        if(strategy == null )
        {
            Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
        }
    }
   
    public void ActionPrefromed(GameObject target)
    {         //Ÿ�ٿ� ���� �׼� ���� - ��ư���� ���� ����
        strategy?.Attack(target);
        strategy?.Damage(target, damage);
        //Nullable<T> or T? �� Value �� ���� null ����� ���� ����(null�̶�� ǥ���� �� �ְ� ���� int����)
    }
}
