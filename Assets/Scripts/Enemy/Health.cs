using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string HIT_ANIMATION_TRIGGER = "IsHit";

    public int health = 4;
    
    public int teamId = 1;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    public void TakeDamage()
    {
        animator.SetTrigger(HIT_ANIMATION_TRIGGER);
        health--;
        
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

