using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : EnemyDetection
{
    
    
    
    
    [SerializeField] private Transform specialAttackPoint;
    [SerializeField] private Transform specialAttackPrefab;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private Health health;
    
    
    public int specialAttackMaxAmmo = 4;
    [HideInInspector]public int specialAttackAmmo ;
    [HideInInspector]public int numberOfCoins = 0;
    // Start is called before the first frame update
    void Awake()
    {
        specialAttackAmmo = specialAttackMaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerInputHandler.playerState)
        {
            case PlayerInputHandler.PlayerState.SpecialAttacking:
               SpecialAttack();
            break;
        }
    }



    void SpecialAttack()
    {
        if(specialAttackAmmo>0)
        {
            Instantiate(specialAttackPrefab, specialAttackPoint.position, specialAttackPoint.rotation);
            specialAttackAmmo--;
        }
    }



   


    public void NormalAttack()
    {
        Debug.Log(isPlayerInRange);
        if(isPlayerInRange && enemyHasHealth.teamId != health.teamId)
        {
            enemyHasHealth.TakeDamage();
        }
    }
}
