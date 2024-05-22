using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour, ICanBeDammagedByPlayer
{
    private const string HIT_ANIMATION_TRIGGER = "IsHit";

    [SerializeField] private float healthOfEnemie = 100f;
    
    [SerializeField] private float damageTakenByPlayer = 10f;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    public void TakeDamageByPlayer()
    {
        animator.SetTrigger(HIT_ANIMATION_TRIGGER);
        healthOfEnemie -= damageTakenByPlayer;
        if(healthOfEnemie <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

