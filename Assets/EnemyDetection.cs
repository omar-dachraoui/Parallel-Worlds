using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    protected Health enemyHasHealth;
    protected bool isPlayerInRange = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        
        enemyHasHealth = other.gameObject.GetComponent<Health>();
        if (enemyHasHealth != null)
        {
            isPlayerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        enemyHasHealth = other.gameObject.GetComponent<Health>();
        if (enemyHasHealth != null)
        {
            isPlayerInRange = false; 
        }
    }
}
