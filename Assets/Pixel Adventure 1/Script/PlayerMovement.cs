using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rd2D; 
    BoxCollider2D coll;
    Animator animator;
    SpriteRenderer spriteRenderer;

    [SerializeField] private LayerMask jumpableGround;

    float dirX; // trục X để láy tọa độ di chuyển qua lại
    [SerializeField] float moveSpedd = 7f; // tốc độ di chuyển
    [SerializeField] float jump = 14f; // độ cao khi nhay 


    enum MovementState
    {
        idle, running, jumping, falling
    }

    // MovementState state = MovementState.idle;


    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Hello Wordl");
        rd2D =GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Cập nhật tọa độ của hướng di chuyển chiều ngang trục X
        dirX = Input.GetAxisRaw("Horizontal");
        rd2D.velocity = new Vector2(dirX * moveSpedd, rd2D.velocity.y);

        // cập nhật tọa độ chiều cao (nhảy) trục Y
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rd2D.velocity = new Vector2(rd2D.velocity.x, jump);
        }

        updateAnimationState();

        //if (Input.GetKeyDown("space"))
        //{
        //    rd2D.velocity = new Vector2(rd2D.velocity.x,14);
        //}

        //if (Input.GetButtonDown("Down"))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector3(7, 0, 0);
        //}

    }


    private void updateAnimationState()
    {

        MovementState state;

        if (dirX > 0f)
        {
            // animator.SetBool("running", true);
            state = MovementState.running;
            spriteRenderer.flipX = false;

        }else if (dirX < 0f)
        {
            //animator.SetBool("running", true);
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            // animator.SetBool("running", false);
            state = MovementState.idle;
        }

        if (rd2D.velocity.y > 1f)
        {
            state = MovementState.jumping;
        }
        else if(rd2D.velocity.y < -1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state",(int)state);

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    
   
}
