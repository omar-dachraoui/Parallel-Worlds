using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelCompletedTrigger : MonoBehaviour
{
    PlayerActions playerActions ;
   void OnTriggerEnter2D(Collider2D other)
    {
       playerActions = other.GetComponent<PlayerActions>();
       if(playerActions != null)
       {
           Debug.Log("Level completed!");
       }
    }
}
