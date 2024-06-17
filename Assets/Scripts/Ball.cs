using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null && collision.collider.tag == "Ground")
        {
            bool player1Scored = transform.position.x > 0;
            gameManager.Score(player1Scored);
        }
    }
}
