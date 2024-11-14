using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    PlayerActions playerActions;


    [SerializeField] private float fallDelay = 1f;
    [SerializeField]  private float destroyDelay = 2f;
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerActions = collision.gameObject.GetComponent<PlayerActions>();
        if (playerActions != null)
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}