using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of movement
    public float distance = 5f; // Distance from center to move

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    void Update()
    {
        // Move the target object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the target object has reached the target position, set a new random target position
        if (transform.position == targetPosition)
        {
            SetNewTargetPosition();
        }
    }

    // Set a new random target position within a specified distance from the initial position
    void SetNewTargetPosition()
    {
        float randomX = Random.Range(-distance, distance);
        float randomY = Random.Range(-distance, distance);

        targetPosition = initialPosition + new Vector3(randomX, randomY, 0);
    }

    // When hit by a ball, stop moving
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // You can add any additional actions here, such as playing a sound or triggering an animation
            Debug.Log("Hit by ball!");
            enabled = false; // Disable this script to stop movement
        }
    }
}

