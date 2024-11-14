using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    
    public enum PlayerState
    {
        Idle,
        Walking,
        Jumping,
        NormalAttacking,
        falling,
        SpecialAttacking
    }

    
    enum InputMode
    {
        SecondPlayer,
        Horizontal
    }

   
   string inputAxis;

    [HideInInspector] public  float horizontal;
    
    
    [HideInInspector] public PlayerState  playerState ;
    [SerializeField] private InputMode inputMode = InputMode.SecondPlayer;
    [SerializeField] private PlayerMvt playerMvt;
    
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



    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxisRaw(inputAxis);
        
        if (Input.GetButtonDown("Jump"))
        {
            
            playerState = PlayerState.Jumping;
            
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            playerState = PlayerState.NormalAttacking;
           
        }
        else if(Input.GetKeyDown(KeyCode.C) )
        {         
            playerState = PlayerState.SpecialAttacking;  
        }
        else if (Mathf.Abs(horizontal) > 0.1f )
        {
            
            playerState = PlayerState.Walking;
        }
        else if(!playerMvt.IsGrounded())
        {
            playerState = PlayerState.falling;
        }
        else
        {
            playerState = PlayerState.Idle;
        }
        


       

        
    }

    
}
