using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    [SerializeField] private float yOffSet = 5f;

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y +yOffSet, this.transform.position.z);
        }
        
    }
}
