using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private const string JUMPING_ANIMATION_TRIGGER = "IsJumping";
    private const string RUNNING_ANIMATION_BOOL = "IsRunning";
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private string inputAxis;
    [SerializeField] Animator playerAnimator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private InputMode inputMode = InputMode.SecondPlayer;
    enum InputMode
    {
        SecondPlayer,
        Horizontal
    }

    private void Awake()
    {
        
        switch (inputMode)
        {
            case InputMode.SecondPlayer:
                inputAxis = "SecondPlayer";
                break;
            case InputMode.Horizontal:
                inputAxis = "Horizontal";
                break;
        }
    }

    void Update()
    {
       horizontal = Input.GetAxisRaw(inputAxis);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //playerAnimator.SetBool(JUMPING_ANIMATION_TRIGGER, true);
        }
        

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
           // playerAnimator.ResetTrigger(JUMPING_ANIMATION_TRIGGER);
        }
        

        Flip();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
     private void UpdateAnimator()
    {
        bool isRunning = Mathf.Abs(horizontal) > 0.1f;
        playerAnimator.SetBool(RUNNING_ANIMATION_BOOL, isRunning);
        bool isJumping = Mathf.Abs(rb.velocity.y) > 0.1f;
        playerAnimator.SetBool(JUMPING_ANIMATION_TRIGGER, isJumping);
    }
    

    
}
