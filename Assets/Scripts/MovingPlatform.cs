using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


    [SerializeField] private float speed = 3.0f; // Speed of the escalator movement
    [SerializeField] private float distance = 8.0f; // Total distance covered by the escalator
    [SerializeField] private bool moveUp = true; // Initial direction of movement

    private Vector3 startPosition;
    private float elapsedTime = 0.0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on time and speed
        float movement = Mathf.PingPong(elapsedTime * speed, distance);
        Vector3 newPosition = startPosition + (moveUp ? Vector3.up : Vector3.down) * movement;

        // Update the position of the GameObject
        transform.position = newPosition;

        // Update the elapsed time
        elapsedTime += Time.deltaTime;
    }

}
