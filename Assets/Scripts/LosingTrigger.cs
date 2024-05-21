using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LosingTrigger : MonoBehaviour
{
    PlayerActions playerActions;
    // Start is called before the first frame update
   void  OnTriggerEnter2D(Collider2D other)
    {
        playerActions = other.GetComponent<PlayerActions>();
        if(playerActions != null)
        {
            playerActions.health = 0;
        }
      
    }
}
