using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieAI : MonoBehaviour
{
    private const string ATTACK_ANIMATION_TRIGGER= "IsAttacking";
    private const string RUN_ANIMATION_TRIGGER= "IsRunning";
    public float detectionRadius = 5f; // The radius of the detection circle
    public LayerMask playerLayer; // Layer mask to filter only enemy colliders
    PlayerActions playerActions;
    
    bool isPlayerInRange ;
    [SerializeField] private float speed = .8f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset = 1f;
    
   
    Animator enemieAnimator ; 
    // Start is called before the first frame update
    void Awake()
    {
        enemieAnimator = GetComponent<Animator>();
        playerActions = playerTransform.GetComponent<PlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectEnemies())
        {
            Flip();
            Debug.Log("Enemy detected!");
            
            if(this.transform.position.x != playerTransform.position.x + offset)
            {
                MoveTowardsPlayer();
            }
           
            
            if(isPlayerInRange)
            {
                enemieAnimator.SetBool(ATTACK_ANIMATION_TRIGGER, true);
                enemieAnimator.SetBool(RUN_ANIMATION_TRIGGER, false);
            }
            else
            {
                enemieAnimator.SetBool(ATTACK_ANIMATION_TRIGGER, false);
                enemieAnimator.SetBool(RUN_ANIMATION_TRIGGER, true);
            }

        }
        else
        {
            enemieAnimator.SetBool(ATTACK_ANIMATION_TRIGGER, false);
            enemieAnimator.SetBool(RUN_ANIMATION_TRIGGER, false);
        }
     
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        playerActions = other.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            isPlayerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        playerActions = other.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            isPlayerInRange = false; 
        }
    }

     bool DetectEnemies()
    {
        // Define the center of the circle (in this case, the position of the GameObject this script is attached to)
        Vector2 center = transform.position;

        // Perform the OverlapCircle check
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, detectionRadius, playerLayer);

        // Check if any collider is detected
        return hitColliders.Length > 0;
    }

    
    
    


    void DamagePlayer()
    {
        playerActions.TakeDamage();
    }

    void MoveTowardsPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position,playerTransform.position, speed * Time.deltaTime);
        enemieAnimator.SetBool(RUN_ANIMATION_TRIGGER, true);
        Debug.Log("Moving towards player");
    }

    void Flip()
    {
       if(this.transform.position.x < playerTransform.position.x)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
    }

    
}
