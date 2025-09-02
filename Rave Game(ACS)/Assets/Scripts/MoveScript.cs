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

        scoreManager.ScoreUP(1);

        if (scoreManager.score > scoreManager.comboScore)
        { 
            scoreManager.ComboUP(1);
            //scoreManager.ScrollValuedown();
        }
    }

   

    public void inputAction()
    {
        if (!scoreManager.gameEnd)
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
