using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ItemHomeWork : MonoBehaviour//�������̸�(����ū�ſ� ���̱�)
{
    public Text fullupgrade;
    public Text text;
    public Text attack;
    public Text UpCount;
    public Text UpPro;
    public Text blessing;
    public Image ghost;
    private int ��ȭ��ġ;
    private int ���ݷ� = 50;
    private int ��ȭȽ�� = 0;
    private int ��ȭȮ�� = 100;
    private int a = 10;
    private int rand;

    //public int attackvalue()
    //{
    //    ���ݷ� = ���ݷ� + ��ȭ��ġ * 5;
    //    return ���ݷ�;
    //}
    //public int upgradecount()
    //{
    //    bool keyinput = Input.GetKey(KeyCode.Space);
    //    if(keyinput)
    //    {
    //        ++��ȭȽ��;
    //    }
    //    else if (��ȭȽ�� == 10)
    //    {
    //        return ��ȭȽ��;
    //    }
    //    return ��ȭȽ�� ;
    //}
    public void random()
    {
        //attackvalue();
        //upgradecount();
          rand = Random.Range(1, 11);

          
          if (rand <=a)//��ȭ����
          {
              --a;
              ++��ȭ��ġ;
              text.text = $"�Ȱ��� ��ȣ(+ {��ȭ��ġ})";
              attack.text = $"���ݷ� : ({���ݷ�+��ȭ��ġ * 5}, +{��ȭ��ġ * 5})";
              UpCount.text = $"��ȭȽ�� : {++��ȭȽ��}";
              UpPro.text = $"��ȭȮ�� : {��ȭȮ��-=10}%";
                 if (a == 0)//���⼭ Max�� �ٷ� �ȶ߰� ��ȭ �������� �ؽ�Ʈ�� �߰� �״��� �� ���ʹ����� Max
                       //�� �ߴµ� �� ������ �𸣰���
                {        //Ǯ��ȭ�� 
                fullupgrade.text = "�����մϴ�! ��� ��ȭ�� �����ϼ̽��ϴ�!";
                text.text = $"�Ȱ��� ��ȣ(+ {��ȭ��ġ}, MAX)";
                attack.text = $"���ݷ� : ({���ݷ� + ��ȭ��ġ * 5}, MAX)";
                UpCount.text = $"��ȭȽ�� : {��ȭȽ��}";
                UpPro.text = $"��ȭȮ�� : {��ȭȮ��}%";
                blessing.text = "��ſ��� �Ȱ��� ��ȣ �ɷ��� �ο��˴ϴ�.. ����� �濡 �ູ�� �����ϱ�..";

                 }
        }
          else if(rand>a)//��ȭ����
          {
              text.text = $"�Ȱ��� ��ȣ(����)";
              attack.text = $"���ݷ� : ({���ݷ�+��ȭ��ġ * 5})";
              UpCount.text = $"��ȭȽ�� : {++��ȭȽ��}";
             UpPro.text = $"��ȭȮ�� : {��ȭȮ��}%";
           }

    }

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            random();
            
        }
    }
}
