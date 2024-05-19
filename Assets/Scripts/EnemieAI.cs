using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieAI : MonoBehaviour
{
    PlayerActions playerActions;
    public Transform enemieCenterTransform;
   
    Animator enemieAnimator ; 
    // Start is called before the first frame update
    void Start()
    {
        enemieAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        playerActions = other.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            Debug.Log("Player detected");
            this.transform.position = Vector2.MoveTowards(this.transform.position, playerActions.transform.position, 0.3f);

        }
    }

    
    
    


    void DamagePlayer()
    {
        playerActions.TakeDamage();
    }
}
