using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    CharacterController controller;
    Vector2 movement;
    public float moveSpeed = 5.0f; // Regular movement speed.
    public float sprintSpeed = 10.0f; // Sprinting movement speed.
    public float rotationSpeed = 2.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Rotate the character based on mouse input.
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // Check for sprint input (Shift key).
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        // Move the character using WASD input.
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;
        if (direction.magnitude >= 0.1f)
        {
            // Apply movement with the adjusted speed.
            controller.Move(transform.TransformDirection(direction) * currentSpeed * Time.deltaTime);
        }
    }
}