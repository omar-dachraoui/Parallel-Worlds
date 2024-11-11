using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvt : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    private float horizontalInput = 0f;  // Track current horizontal input

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to movement events
        playerInput.OnMoveLeftDetected += PlayerInput_OnMoveLeftDetected;
        playerInput.OnMoveRightDetected += PlayerInput_OnMoveRightDetected;
        playerInput.OnJumpInputDetected += PlayerInput_OnJumpInputDetected;
    }

    private void PlayerInput_OnMoveRightDetected(object sender, EventArgs e)
    {
        Debug.Log("Move Right");
       // horizontalInput = 1f; // Right movement input
    }

    private void PlayerInput_OnMoveLeftDetected(object sender, EventArgs e)
    {
        Debug.Log("Move Left");
        //horizontalInput = -1f; // Left movement input
    }

    private void PlayerInput_OnJumpInputDetected(object sender, EventArgs e)
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        else if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void Update()
    {
        horizontalInput = playerInput.horizontal;
        // Continuously update velocity based on horizontal input
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}






















