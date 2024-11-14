using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string JUMPING_ANIMATION_TRIGGER = "IsJumping";
    private const string IDLE_ANIMATION_TRIGGER = "isIdle";
    private const string RUNNING_ANIMATION_BOOL = "IsRunning";
    private const string ATTACK_ANIMATION_TRIGGER= "NormalAttack";
    private const string SPECIAL_ATTACK_ANIMATION_TRIGGER= "SpecialAttack";
    private const string FALLING_ANIMATION_TRIGGER= "isFalling";


    [SerializeField] private PlayerInputHandler playerInput;
    [SerializeField] private PlayerMvt playerMvt;
    [SerializeField] Animator playerAnimator;
    [SerializeField] private AudioSource specialAttackSound;
    private bool isFacingRight = true;
    



   

    private void Flip(float horizontal)
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.rotation.eulerAngles;
            localScale.y += 180f;
            transform.rotation = Quaternion.Euler(localScale);
            //localScale.x *= -1f;
            //transform.localScale = localScale;
        }
    }




    private void Update()
    {
        //playerAnimator.SetBool(FALLING_ANIMATION_TRIGGER, !playerMvt.IsGrounded());
        
        if(playerInput.playerState == PlayerInputHandler.PlayerState.Idle)
        {
            playerAnimator.SetBool(IDLE_ANIMATION_TRIGGER, true);
        }
        else
        {
            playerAnimator.SetBool(IDLE_ANIMATION_TRIGGER, false);
        }

        
        if(playerInput.playerState == PlayerInputHandler.PlayerState.Walking)
        {
            playerAnimator.SetBool(RUNNING_ANIMATION_BOOL, true);
            Flip(playerInput.horizontal);
        }
        else
        {
            playerAnimator.SetBool(RUNNING_ANIMATION_BOOL, false);
        }


        if(playerInput.playerState == PlayerInputHandler.PlayerState.Jumping)
        {
            playerAnimator.SetTrigger(JUMPING_ANIMATION_TRIGGER);
        }
        else
        {
            playerAnimator.ResetTrigger(JUMPING_ANIMATION_TRIGGER);
        }


        if(playerInput.playerState == PlayerInputHandler.PlayerState.NormalAttacking)
        {
            playerAnimator.SetTrigger(ATTACK_ANIMATION_TRIGGER);
        }
        else
        {
            playerAnimator.ResetTrigger(ATTACK_ANIMATION_TRIGGER);
        }


        if(playerInput.playerState == PlayerInputHandler.PlayerState.SpecialAttacking)
        {
            playerAnimator.SetTrigger(SPECIAL_ATTACK_ANIMATION_TRIGGER);
            specialAttackSound.Play();
        }
        else
        {
            playerAnimator.ResetTrigger(SPECIAL_ATTACK_ANIMATION_TRIGGER);
        }


        if(playerInput.playerState == PlayerInputHandler.PlayerState.falling)
        {
            playerAnimator.SetBool(FALLING_ANIMATION_TRIGGER, true);
        }
        else
        {
            playerAnimator.SetBool(FALLING_ANIMATION_TRIGGER, false);
        }


    }



    
}
