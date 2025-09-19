using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text TimerText;

     void Start()
     {
        StartCoroutine(CountDownFunc((int)GameManager.instance.Globaldelay));
     }

     private IEnumerator CountDownFunc(int count)
     {
        for(int i = count; i>=0; i--)
        {
            TimerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
            if(i == 1)
            {
                TimerText.gameObject.SetActive(false);
            }
        }
     }
    
}
