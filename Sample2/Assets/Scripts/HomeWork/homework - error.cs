using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ItemHomeWork : MonoBehaviour//아이템이름(제일큰거에 붙이기)
{
    public Text fullupgrade;
    public Text text;
    public Text attack;
    public Text UpCount;
    public Text UpPro;
    public Text blessing;
    public Image ghost;
    private int 강화수치;
    private int 공격력 = 50;
    private int 강화횟수 = 0;
    private int 강화확률 = 100;
    private int a = 10;
    private int rand;

    //public int attackvalue()
    //{
    //    공격력 = 공격력 + 강화수치 * 5;
    //    return 공격력;
    //}
    //public int upgradecount()
    //{
    //    bool keyinput = Input.GetKey(KeyCode.Space);
    //    if(keyinput)
    //    {
    //        ++강화횟수;
    //    }
    //    else if (강화횟수 == 10)
    //    {
    //        return 강화횟수;
    //    }
    //    return 강화횟수 ;
    //}
    public void random()
    {
        //attackvalue();
        //upgradecount();
          rand = Random.Range(1, 11);

          
          if (rand <=a)//강화성공
          {
              --a;
              ++강화수치;
              text.text = $"안경의 수호(+ {강화수치})";
              attack.text = $"공격력 : ({공격력+강화수치 * 5}, +{강화수치 * 5})";
              UpCount.text = $"강화횟수 : {++강화횟수}";
              UpPro.text = $"강화확률 : {강화확률-=10}%";
                 if (a == 0)//여기서 Max가 바로 안뜨고 강화 성공시의 텍스트가 뜨고 그다음 또 엔터눌러야 Max
                       //가 뜨는데 이 이유를 모르겠음
                {        //풀강화시 
                fullupgrade.text = "축하합니다! 모든 강화에 성공하셨습니다!";
                text.text = $"안경의 수호(+ {강화수치}, MAX)";
                attack.text = $"공격력 : ({공격력 + 강화수치 * 5}, MAX)";
                UpCount.text = $"강화횟수 : {강화횟수}";
                UpPro.text = $"강화확률 : {강화확률}%";
                blessing.text = "당신에게 안경의 수호 능력이 부여됩니다.. 당신의 길에 축복이 가득하길..";

                 }
        }
          else if(rand>a)//강화실패
          {
              text.text = $"안경의 수호(실패)";
              attack.text = $"공격력 : ({공격력+강화수치 * 5})";
              UpCount.text = $"강화횟수 : {++강화횟수}";
             UpPro.text = $"강화확률 : {강화확률}%";
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
