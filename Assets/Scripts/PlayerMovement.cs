using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string JUMPING_ANIMATION_TRIGGER = "IsJumping";
    private const string WALKING_ANIMATION_TRIGGER = "Speed";
    
    private Transform playerTransform;
    private Animator playerAnimator;
    float speed = 0f;
    



    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }



    
    private  void Movement()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerTransform.position += new Vector3(0, 100f, 0)* Time.deltaTime;
            playerAnimator.SetTrigger(JUMPING_ANIMATION_TRIGGER);
        }
        else
        {
            playerAnimator.ResetTrigger(JUMPING_ANIMATION_TRIGGER);
        }
      
        if(Input.GetKey(KeyCode.A))
        {

            playerTransform.position += new Vector3(-1f, 0, 0)*Time.deltaTime;
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
            speed = 1;
            playerAnimator.SetFloat(WALKING_ANIMATION_TRIGGER, speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            playerTransform.position += new Vector3(1f, 0, 0)*Time.deltaTime;
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
            speed = 1;
            playerAnimator.SetFloat(WALKING_ANIMATION_TRIGGER, speed);
        }
        else
        {
            
            speed = 0;
            playerAnimator.SetFloat(WALKING_ANIMATION_TRIGGER, speed);
        }

    }

    

    
}
