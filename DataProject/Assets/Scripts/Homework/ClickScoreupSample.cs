using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickScoreupSample : MonoBehaviour
{
    public Camera Camera;
    Vector3 mouseposition;
    public float maxdistance = 20.0f;
    public int score = 0;
    public Text ScoreText;

    private void Start()
    {
        
        ScoreText.text = $"Score : {score}";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseposition = Input.mousePosition;
            mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
            RaycastHit2D hit = Physics2D.Raycast(mouseposition, transform.forward,maxdistance);
            if (hit)
            {
                score++;
                ScoreText.text = $"Score : {score}";
                hit.transform.GetComponent<SpriteRenderer>().color = Color.mintCream;
            }
        }
    }

    
    //public GameObject sphere;
    //public Button Button;

    //void Start()
    //{

    //}

    //void Update()
    //{
    //    Button.onClick.AddListener(SphereClickScoreUP);
    //}

}
