using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class LoadPlayerInfoinNewScene : MonoBehaviour
{
    public Camera Camera;
    public Image playerinfo;
    Vector3 mouseposition;
    float maxdistance = 100f;

    public Text p_name;
    public Text p_gender;
    public Text p_work;
    public Text p_level;
    
    

    private void Start()
    {
        p_name.text = $"Player : ";
        p_gender.text = $"gender : ";
        p_work.text = $"work : ";
        p_level.text = $"level : ";
        playerinfo.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseposition = Input.mousePosition;
            mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
            RaycastHit2D hit = Physics2D.Raycast(mouseposition, transform.forward, maxdistance);
           
            if(hit)
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.yellow;
                playerinfo.gameObject.SetActive(true);
                LoadPlayerInfo();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerinfo.gameObject.SetActive(false);
        }
    }

    public void LoadPlayerInfo()
    {
        string pname = PlayerPrefs.GetString("nameInput", "?");
        string pgender = PlayerPrefs.GetString("gender", "?");
        string pwork = PlayerPrefs.GetString("work", "?");
        string plevel = PlayerPrefs.GetString("level", "설마");
        p_name.text = $"Player : {pname}";
        p_gender.text = $"성별 : {pgender}";
        p_work.text = $"직업 : {pwork}";
        p_level.text = $"Lv : {plevel}";
    }
}
