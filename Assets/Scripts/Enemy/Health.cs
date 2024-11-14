using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string HIT_ANIMATION_TRIGGER = "IsHit";

    public EventHandler OnDammageTaken;


    public int health = 4;
    
    public int teamId = 1;
    //Animator animator;

    private void Awake()
    {
        
    }



    public void TakeDamage()
    {
        OnDammageTaken?.Invoke(this, EventArgs.Empty);
        health--;
        
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

