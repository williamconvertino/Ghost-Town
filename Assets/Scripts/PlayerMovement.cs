using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //horizontal speed of character
    public float speed = 5f;

    //public float jumpSpeed = 8f;
    private float direction = 0f;

    //height of jump 
    public float jumpHeight= 3;

    //how fast you go up
    public float gravityScale = 10;

    //how fast you call 
    public float fallingGravityScale = 45;

    private Rigidbody2D player;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxisRaw("Horizontal");

        float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * player.gravityScale));

        //left right movement 
        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //jumping movement 
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //controlling how quickly it goes up and goes down 
        if (player.velocity.y >= 0)
        {
            player.gravityScale = gravityScale;
        }
        else if (player.velocity.y < 0)
        {
            player.gravityScale = fallingGravityScale; 
        }
    }
}
