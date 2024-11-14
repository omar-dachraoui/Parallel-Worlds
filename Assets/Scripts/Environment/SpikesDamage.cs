using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    PlayerActions playerActions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        playerActions = other.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            playerActions.TakeDamage();
        }
    }
    
}
