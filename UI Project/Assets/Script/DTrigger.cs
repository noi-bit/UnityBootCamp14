using System.Collections.Generic; //<T>�� ����Ϸ���
using UnityEngine;

public class DTrigger : MonoBehaviour
{
    public List<Dialog> scripts; //���⼭ scripts �� ���ܾ� �� ��ü�� ���
    
    public void OnDTriggerEnter()
    {
        if(scripts != null && scripts.Count > 0)
        {
            DialogManager.Instance.StartLine(scripts);
            //Ŭ������.Instance.�޼ҵ��()�� ���� Ŭ������ ���� �ٷ� ����� �� �ִ�(�ظ��ϸ� Instance�� Instance��� �̸����� ����)
            //static�̱� ������ GetComponent�� public ������ ����� �ʿ� X
            
        }
    }
}
