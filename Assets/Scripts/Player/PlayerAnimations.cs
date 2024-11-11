using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string JUMPING_ANIMATION_TRIGGER = "IsJumping";
    private const string RUNNING_ANIMATION_BOOL = "IsRunning";
    private const string ATTACK_ANIMATION_TRIGGER= "NormalAttack";
    private const string SPECIAL_ATTACK_ANIMATION_TRIGGER= "SpecialAttack";


    [SerializeField] private PlayerInput playerInput;
    [SerializeField] Animator playerAnimator;
    [SerializeField] private AudioSource specialAttackSound;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnJumpInputDetected += PlayerInput_OnJumpInputDetected;
        playerInput.OnMoveLeftDetected += PlayerInput_OnMoveLeftDetected;
        playerInput.OnMoveRightDetected += PlayerInput_OnMoveRightDetected; 
        playerInput.OnSimpleAttackDetected += PlayerInput_OnSimpleAttackDetected;
        playerInput.OnSpecialAttackDetected += PlayerInput_OnSpecialAttackDetected;
    }

    private void PlayerInput_OnSpecialAttackDetected(object sender, EventArgs e)
    {
        playerAnimator.SetTrigger(SPECIAL_ATTACK_ANIMATION_TRIGGER);
        specialAttackSound.Play();

    }

    private void PlayerInput_OnSimpleAttackDetected(object sender, EventArgs e)
    {
        playerAnimator.SetTrigger(ATTACK_ANIMATION_TRIGGER);
    }

    private void PlayerInput_OnMoveRightDetected(object sender, EventArgs e)
    {
        playerAnimator.SetBool(RUNNING_ANIMATION_BOOL, true);
        Flip(1f);
    }

    private void PlayerInput_OnMoveLeftDetected(object sender, EventArgs e)
    {
        playerAnimator.SetBool(RUNNING_ANIMATION_BOOL, true);
        Flip(-1f);
    }

    private void PlayerInput_OnJumpInputDetected(object sender, EventArgs e)
    {
        playerAnimator.SetBool(JUMPING_ANIMATION_TRIGGER, true);
    }

    private void Flip(float horizontal)
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }




    private void Update()
    {
        // Reset running animation if no horizontal input
        if (playerInput.horizontal == 0)
        {
            playerAnimator.SetBool(RUNNING_ANIMATION_BOOL, false);
        }
    }

    
}
