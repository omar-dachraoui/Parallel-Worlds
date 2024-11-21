using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtPositionButtonCheck : MonoBehaviour
{

    [SerializeField] float yRange = 0.5f;
    public bool playerAtPosition = false;

    


    void OnTriggerEnter2D (Collider2D other)
    {
        PlayerActions playerActions = other.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            playerAtPosition = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - yRange, this.transform.position.z);
        }
        
    }   
}
