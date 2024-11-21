using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    

    public EventHandler OnDammageTaken;
    public EventHandler OnDeath;

    
    public int health = 4;
    
    public int teamId = 1;

    public bool isDead = false;
    



    public void TakeDamage()
    {
        health--;
        
        
        if(health <= 0)
        {
            
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
        else
        {
           
            OnDammageTaken?.Invoke(this, EventArgs.Empty);
            
        }
    }

    public void Hide()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}

