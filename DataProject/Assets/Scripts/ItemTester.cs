using UnityEngine;

public class ItemTester : MonoBehaviour
{
    public SoMaker somaker;
    
    void Start()
    {
        Debug.Log(somaker.description);
    }
    
    public void LevelUp()
    {
        somaker.level++;
        Debug.Log($"������ �����߽��ϴ�, {somaker.level}");
    }
}
