using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICEBallEffect : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
   [SerializeField] float speed = 5f;
   ICanBeDammagedByPlayer CanBeDammagedByPlayer;

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
        CanBeDammagedByPlayer = other.GetComponent<ICanBeDammagedByPlayer>();
        if(CanBeDammagedByPlayer != null)
        {
            CanBeDammagedByPlayer.TakeDamageByPlayer();
            Destroy(this.gameObject);
        }
        
    }
}
