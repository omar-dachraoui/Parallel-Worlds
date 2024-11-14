using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialAttackEffect : MonoBehaviour
{
  
   [SerializeField] float maxDistance = 10f;
   [SerializeField] float speed = 5f;
   

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        if(this.transform.position.x > maxDistance)
        {

            Destroy(this.gameObject);
        }

       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Health CanBeDammagedByPlayer = other.GetComponent<Health>();
        if(CanBeDammagedByPlayer != null && CanBeDammagedByPlayer.teamId != 1)
        {
            CanBeDammagedByPlayer.TakeDamage();
            Destroy(this.gameObject);
        }
        
    }
    
}
