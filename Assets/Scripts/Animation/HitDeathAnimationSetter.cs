using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDeathAnimationSetter : MonoBehaviour
{
    

    [SerializeField] private Health health;


    private void PlayerIsDead()
    {
        health.Hide();
    }
}
