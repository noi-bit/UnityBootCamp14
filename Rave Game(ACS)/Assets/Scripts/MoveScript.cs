using UnityEngine;

public class MoveScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    
    public ScoreManager scoreManager;

    private bool lastMove = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        inputAction();
    }

    public void inputMove(bool flip)
    {
        if (lastMove == flip)
            return;

        lastMove = flip;

        scoreManager.Scoreup(1);
        if (scoreManager.score > scoreManager.comboScore)
        { 
            scoreManager.ComboImage.gameObject.SetActive(true);
            scoreManager.ScoreCombo(1);
            //scoreManager.ScrollValuedown();
        }
    }

    public void inputAction()
    {
        if (c)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = false;
            }
            inputMove(spriteRenderer.flipX);
        }

    }


}
