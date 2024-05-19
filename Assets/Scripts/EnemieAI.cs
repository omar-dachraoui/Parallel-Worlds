using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieAI : MonoBehaviour
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
    { playerActions = other.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            Debug.Log("Player detected");
        }
    }
}
