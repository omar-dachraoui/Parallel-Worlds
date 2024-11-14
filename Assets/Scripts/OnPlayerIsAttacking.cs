using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerIsAttacking : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler playerInputHandler;
    

    void SimpleAttack()
    {
        Debug.Log("Simple Attack");
    }
}
