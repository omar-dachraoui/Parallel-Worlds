using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    Health playerHealth;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth = other.GetComponent<Health>();
        if (playerHealth != null && playerHealth.teamId == 1)
        {
            playerHealth.TakeDamage();
        }
    }
    
}
