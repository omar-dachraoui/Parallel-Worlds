using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBallEffect : MonoBehaviour
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
        IDamagebale CanBeDammaged = other.GetComponent<IDamagebale>();
        if(CanBeDammaged != null)
        {
            CanBeDammaged.TakeDamage();
            Destroy(this.gameObject);
        }
        
    }
    
}
