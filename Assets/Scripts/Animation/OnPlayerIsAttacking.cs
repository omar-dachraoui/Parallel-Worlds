using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerIsAttacking : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions; 
    

    void SimpleAttack()
    {
        playerActions.NormalAttack();
    }
}
