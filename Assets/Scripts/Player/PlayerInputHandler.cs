using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    
    public enum PlayerState
    {
        Idle,
        Dead,
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
    [SerializeField] private Health playerHealth;
    
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
        playerHealth.OnDeath += PlayerHealth_OnDeath;
    }

    private void PlayerHealth_OnDeath(object sender, EventArgs e)
    {
        playerState = PlayerState.Dead;
    }



    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxisRaw(inputAxis);
        if(playerState != PlayerState.Dead)
        {
            if(Input.GetButtonDown("Jump"))
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

    
}
