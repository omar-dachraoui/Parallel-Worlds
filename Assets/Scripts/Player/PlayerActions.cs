using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    
    
    
    
    [SerializeField] private Transform specialAttackPoint;
    [SerializeField] private Transform specialAttackPrefab;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    
    
    [SerializeField] private int specialAttackMaxAmmo = 4;
    [HideInInspector]public int specialAttackAmmo ;

    public int health = 4;

    public int numberOfCoins = 0;
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
                if(specialAttackAmmo>0)
                {
                    Instantiate(specialAttackPrefab, specialAttackPoint.position, specialAttackPoint.rotation);
                    specialAttackAmmo--;
                }
                break;
        }
    }
    public void TakeDamage()
    {
        
    }
}
