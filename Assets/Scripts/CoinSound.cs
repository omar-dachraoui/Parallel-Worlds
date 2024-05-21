using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    AudioSource audioSource ;
    PlayerActions playerActions;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
   void OnTriggerEnter2D(Collider2D other)
    {
        playerActions = other.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            audioSource.Play();
            Destroy(gameObject, 0.15f);
        }
    }
}
