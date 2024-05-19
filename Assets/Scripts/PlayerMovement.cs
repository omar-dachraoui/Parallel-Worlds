using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string JUMPING_ANIMATION_TRIGGER = "IsJumping";
    private const string WALKING_ANIMATION_TRIGGER = "Speed";
    
    [SerializeField] private Transform groundCheckTransform ;
    [SerializeField] private LayerMask groundLayer;
   
    
    
    private Animator playerAnimator;
    float speed = 0f;
    [SerializeField]private float jumpForce = 1f;

    



    void Awake()
    {
       
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }



    
    private  void Movement()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
            
             this.transform.position += new Vector3(0, jumpForce, 0)*Time.deltaTime;
            
            playerAnimator.SetTrigger(JUMPING_ANIMATION_TRIGGER);
        }
        else
        {
            playerAnimator.ResetTrigger(JUMPING_ANIMATION_TRIGGER);
        }

        if(Input.GetKey(KeyCode.A))
        {

            this.transform.position += new Vector3(-1f, 0, 0)*Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            speed = 1;
            playerAnimator.SetFloat(WALKING_ANIMATION_TRIGGER, speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(1f, 0, 0)*Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            speed = 1;
            playerAnimator.SetFloat(WALKING_ANIMATION_TRIGGER, speed);
        }
        else
        {
            
            speed = 0;
            playerAnimator.SetFloat(WALKING_ANIMATION_TRIGGER, speed);
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position,  0.1f,groundLayer);
    }
    
    

    
}
