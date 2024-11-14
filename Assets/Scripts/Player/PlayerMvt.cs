using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvt : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler playerInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    private float horizontalInput = 0f;  
   

    



    private void Update()
    {
        horizontalInput = playerInput.horizontal;
        // Continuously update velocity based on horizontal input
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        

        
        if(playerInput!=null)
        {
            
            switch (playerInput.playerState)
            {
            case PlayerInputHandler.PlayerState.Idle:
                
                break;
            case PlayerInputHandler.PlayerState.Walking:
                
                
                break;
            case PlayerInputHandler.PlayerState.Jumping:
               
                Jump();
                break;
            case PlayerInputHandler.PlayerState.NormalAttacking:
                
                
                break;
            case PlayerInputHandler.PlayerState.SpecialAttacking:
                
                
                break;
            }
        }

        
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        else if (rb.velocity.y > 0f )
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}






















