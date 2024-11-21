using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialAttackPickUP : MonoBehaviour
{
    

    [SerializeField] PlayerActions otherPlayerActions;
    

    void OnTriggerEnter2D(Collider2D other)
    {
       PlayerActions playerActions =other.gameObject.GetComponent<PlayerActions>() ;
        if (playerActions != null && otherPlayerActions != null)
        {
            if(otherPlayerActions.specialAttackAmmo < otherPlayerActions.specialAttackMaxAmmo)
            {
                otherPlayerActions.specialAttackAmmo++;
                
                
            }
            Destroy(gameObject);
           
        }
    }
}
