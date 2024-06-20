using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public EPlayer player;
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    public bool isGrounded = false;

    private void Update()
    {
        bool isPlayer1 = player == EPlayer.Player1;
        float hor = Input.GetAxis(isPlayer1 ? "HorizontalP1" : "HorizontalP2");

        Vector2 velocity = new Vector2(hor * speed, rb.velocity.y);
        rb.velocity = velocity;

        if (Input.GetButtonDown(isPlayer1 ? "JumpP1" : "JumpP2"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public enum EPlayer
    {
        Player1,
        Player2
    }
}
