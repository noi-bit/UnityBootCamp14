using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);
                if (Mathf.Abs(transform.position.y) > 0.25f)
                   { GameManager.instance.NormalHits();
                    GameManager.instance.noteCheck.text = "Normal!";
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                //GameManager.instance.NoteHit();
                else if(Mathf.Abs(transform.position.y)>0.05f)
                   { GameManager.instance.GoodHits();
                    GameManager.instance.noteCheck.text = "Good!";
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                    { GameManager.instance.PerfectHits();
                    GameManager.instance.noteCheck.text = "Perfect!";
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
        else if(other.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
