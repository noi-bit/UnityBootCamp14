using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public GameObject player;
    public Text text;
    private int score = 00;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 00;
        text.text = "Score : "+score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        //�浹ü�� ���� ������Ʈ�� �±װ� Item Box���?
        if (player.gameObject.CompareTag("Item Box"))
        {
            score += 10;
            text.text = "Score : " + score;
        }
        if (player.gameObject.CompareTag("obstacle"))
        {

            score += 10;
            text.text = "Score : " + score;
        }
    }

}
