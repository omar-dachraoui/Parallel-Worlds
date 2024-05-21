using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour, ICanBeDammagedByPlayer
{

    [SerializeField] private float healthOfEnemie = 100f;
    
    [SerializeField] private float damageTakenByPlayer = 10f;



    public void TakeDamageByPlayer()
    {
        healthOfEnemie -= damageTakenByPlayer;
        if(healthOfEnemie <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

