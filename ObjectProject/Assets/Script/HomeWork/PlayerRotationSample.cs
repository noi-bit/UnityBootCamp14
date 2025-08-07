using UnityEngine;
using UnityEngine.UI;

public class PlayerRotationSample : MonoBehaviour
{
    public int PlayerLife = 5;
    public float speed = 3.0f;
    public Text Life;
    public Text gameover;
    public GameObject effect_prefab;//이펙트 프리팹

    private void Start()
    {
        PlayerLifeCount();
    }

    // Update is called once per frame
    void Update()
    {
        float horizon =  Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(vertical,0, -horizon)*speed*Time.deltaTime); // 움직임 구현 어려움 ㅠㅠ
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(effect_prefab, transform.position, Quaternion.identity);
            Playerdestroy();
            PlayerLifeCount();
        }
    }
    public void Playerdestroy()
    {
        PlayerLife -= 1;
        
        if (PlayerLife <= 0)
        {
            gameObject.SetActive(false);
            GameOver();
        }
    }
    public void PlayerLifeCount()
    {
        if (PlayerLife >= 0)
        {
            Life.text = new string('★', PlayerLife);
        }
    }
    public void GameOver()
    {
        if(PlayerLife<=0)
        {
            gameover.text = "Game Over!!!";
        }
    }
}
