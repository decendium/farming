using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    private Vector3 lastMovementDirection = Vector3.forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Moves the player based on W, A, S, and D inputs
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + movement);

        // If the player is moving, rotate them towards where they are going
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        if (moveDirection != Vector3.zero)
        {
            lastMovementDirection = moveDirection.normalized;
            RotatePlayer(lastMovementDirection);
        }
        else if (rb.velocity.magnitude < 0.1f)
        {
            RotatePlayer(lastMovementDirection);
        }

    }

    // Rotates the player towards the desired direction
    void RotatePlayer(Vector3 targetDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
    }
}
