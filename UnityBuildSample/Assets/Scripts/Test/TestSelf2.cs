using System;
using UnityEngine;
using UnityEngine.UI;

public class TestSelf2 : MonoBehaviour
{
    //public EventHandler<TestSelf1> onTest;

    //EventSample event_sample = GetComponent<EventSample>();

    public Text itemtext;

    void Start()
    {
        TestSelf1 test1 = GetComponent<TestSelf1>();
        
    }

    void Update()
    {
        
    }

    public void Item(object sender, EventArgs e)
    {
        int a = UnityEngine.Random.Range(1, 7);
        
        if (a == 3 || a == 4)
        {
            itemtext.text = "�������� ������ϴ�";
        }
        else
        {
            itemtext.text = "�������� �������߽��ϴ�";
        }
    }
}
