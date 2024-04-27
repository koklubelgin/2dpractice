using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    float direction = 0;
    public Rigidbody2D playerRB;
    public Animator animator;
    public float speed = 400;
    bool isFacingRight = true;
    public float jumpForce = 5;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    int numberOfJumps = 0;

    private void Update()
    {
        Debug.Log(numberOfJumps);
    }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed += ctx => Jump();
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 01f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speed",Mathf.Abs(direction));
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        if (isFacingRight && direction < 0 || !isFacingRight && direction >0)
            Flip();
    }






    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }




    void Jump()
    {
        if (isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps = 1; 
        }
        else
        {
            if (numberOfJumps < 2) 
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
            }
        }
    }



}