using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string HIT_ANIMATION_TRIGGER = "IsHit";

    public EventHandler OnDammageTaken;
    public EventHandler OnDeath;

    [SerializeField] private float deathDelay = 2f;
    public int health = 4;
    
    public int teamId = 1;
    



    public void TakeDamage()
    {
        health--;
        
        
        if(health > 0)
        {
            OnDammageTaken?.Invoke(this, EventArgs.Empty);
            
        }
        else
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
            
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

