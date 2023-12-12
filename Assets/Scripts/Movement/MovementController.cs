using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using static AnimationsController;
using static CameraController;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    public static MovementController movementInstance;
    private void Awake() => movementInstance = this;
    public GameObject player;
    public float walkSpeed = 25f;
    public float runSpeed = 75f;
    //public float jumpPower = 1f; // not needed for now
    //public float gravity = 10f; // not needed for now
    public float lookSpeed = 2f;
    public float lookXLimit = 70f;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;
    public CharacterController characterController;
    public float rotationSpeed = 250.0f; // Added rotation speed
    public float moveSpeed = 25.0f; // Added move speed
    public float sprintSpeed = 75.0f; // Added sprint speed
    private Vector2 movement; // Added movement input
    public bool isFacingWall = false;
    
    public float gravity = -9.81f;
    private Vector3 velocity;
    
    public float jumpPower = 5f;

    public bool isJumping = false;
    
    public bool jumped = false;
    // Start is called before the first frame update
    
    public float groundCheckDistance = 0.2f; 
    public LayerMask groundLayer;

    void Start()
    {
        player.SetActive(false);
        player.SetActive(true);
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = IsCharacterGrounded();
        
        // Check if the character is grounded
        if (isGrounded)
        {
                velocity.y = -2f; // Small downward force to ensure character stays on the ground
                if (Input.GetKey(KeyCode.Space))
                {
                    isJumping = true;
                    jumped = true;
                    Debug.Log("Am sarit" + Time.frameCount);
                    StartCoroutine(Jump());
                    velocity.y = jumpPower;
                    velocity.y += gravity * Time.deltaTime;
                }
        }
        else
        {
            if (isJumping == false)
            {
                velocity.y -= 0.6f;
                Debug.Log("Am facut velociatea negariva" + Time.frameCount);
                // Apply gravity to the velocity
                // Since gravity is an acceleration, it affects the velocity over time, not instantaneously.
                velocity.y += gravity * Time.deltaTime;
            }
        }
        if (isJumping)
        {
            velocity.y += 1f;
            velocity.y += gravity * Time.deltaTime;
        }
        // Move the character with the accumulated velocity
        characterController.Move(velocity * Time.deltaTime);
        
        // Rotate the character based on mouse input.
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        
        // Check for sprint input (Shift key).
        float currentSpeed;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }
    
        // Move the character using WASD input.
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        // Check if there is an obstacle in front of the player.
        RaycastHit hit;
        if (direction.z > 0 && Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit, 7f))
        {
            // If there is an obstacle, stop the player from moving forwards.
            direction.z = 0;
            isFacingWall = true;
        }
        else
        {
            isFacingWall = false;
        }

        // Apply movement with the adjusted speed.
        if (canMove && direction.magnitude >= 0.1f)
        {
            characterController.Move(transform.TransformDirection(direction) * currentSpeed * Time.deltaTime);

            // Set animation triggers based on input
            animationsInstance.SetAnimationTriggers(direction);
        }
        else
        {
            // Reset all animation triggers if no movement
            animationsInstance.ResetAnimationTriggers();
        }

        // Handles Rotation
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        cameraInstance.playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.2f);
        isJumping = false;
    }
    
         bool IsCharacterGrounded()
     {
         // Cast a ray downward to check for ground contact with tolerance
         Vector3 origin = transform.position + characterController.center;
         Vector3 offset1 = new Vector3(0,0,4.5f);
         Vector3 frontCorner = transform.position + characterController.center + offset1;
         Vector3 offset2 = new Vector3(0, 0, -4.5f);
         Vector3 backCorner = transform.position + characterController.center + offset2;
         Vector3 offset3 = new Vector3(4.5f, 0, 0);
         Vector3 rightCorner = transform.position + characterController.center + offset3;
         Vector3 offset4 = new Vector3(-4.5f, 0, 0);
         Vector3 leftCorner = transform.position + characterController.center + offset4;
         float radius = characterController.radius;
         float distance = groundCheckDistance + radius; // Add the radius as tolerance

         if (Physics.SphereCast(origin, radius, Vector3.down, out RaycastHit hitInfo, distance, groundLayer) ||
             Physics.SphereCast(frontCorner, radius, Vector3.down, out RaycastHit hitInfo1, distance, groundLayer) ||
             Physics.SphereCast(backCorner, radius, Vector3.down, out RaycastHit hitInfo2, distance, groundLayer) ||
             Physics.SphereCast(rightCorner, radius, Vector3.down, out RaycastHit hitInfo3, distance, groundLayer) ||
             Physics.SphereCast(leftCorner, radius, Vector3.down, out RaycastHit hitInfo4, distance, groundLayer) )
         {
             return true;
         }
         else
         {
             return false;
         }
     }
}

// using System.Collections;
// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using static AnimationsController;
// using static CameraController;
//
// [RequireComponent(typeof(CharacterController))]
// public class MovementController : MonoBehaviour
// {
//     public static MovementController movementInstance;
//     private void Awake() => movementInstance = this;
//     public GameObject player;
//     public float walkSpeed = 25f;
//     public float runSpeed = 75f;
//     //public float jumpPower = 1f; // not needed for now
//     //public float gravity = 10f; // not needed for now
//     public float lookSpeed = 2f;
//     public float lookXLimit = 70f;
//     Vector3 moveDirection = Vector3.zero;
//     float rotationX = 0;
//     public bool canMove = true;
//     public CharacterController characterController;
//     public float rotationSpeed = 250.0f; // Added rotation speed
//     public float moveSpeed = 25.0f; // Added move speed
//     public float sprintSpeed = 75.0f; // Added sprint speed
//     private Vector2 movement; // Added movement input
//     public bool isFacingWall = false;
//     
//     public float gravity = -9.81f;
//     private Vector3 velocity;
//     
//     public float jumpPower = 5f;
//
//     public bool isJumping = false;
//     
//     public bool jumped = false;
//     
//     public float groundCheckDistance = 0.2f;
//     public LayerMask groundLayer;
//     
//     // Start is called before the first frame update
//     void Start()
//     {
//         player.SetActive(false);
//         player.SetActive(true);
//         characterController = GetComponent<CharacterController>();
//         Cursor.visible = false;
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         bool isGrounded = IsCharacterGrounded();
//         // Check if the character is grounded
//         // Debug.Log(velocity.y + "  " + Time.frameCount + "  " );
//         if (!isGrounded)
//              Debug.Log( characterController.transform.position.y);
//         if (isGrounded)
//         {
//                 velocity.y = -2f; // Small downward force to ensure character stays on the ground
//                 if (Input.GetKeyDown(KeyCode.Space))
//                 {
//                     isJumping = true;
//                     jumped = true;
//                     Debug.Log("Am sarit" + Time.frameCount);
//                     StartCoroutine(Jump());
//                     velocity.y = jumpPower;
//                     velocity.y += gravity * Time.deltaTime;
//                 }
//                 
//         }
//         else
//         {
//             if (isJumping == false)
//             {
//                 velocity.y -= 0.6f;
//                 // Apply gravity to the velocity
//                 // Since gravity is an acceleration, it affects the velocity over time, not instantaneously.
//                     velocity.y += gravity * Time.deltaTime;
//             }
//         }
//         if (isJumping)
//         {
//             velocity.y += 1f;
//             velocity.y += gravity * Time.deltaTime;
//         }
//         // Move the character with the accumulated velocity
//         characterController.Move(velocity * Time.deltaTime);
//         
//         
//         
//         // Rotate the character based on mouse input.
//         float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
//         transform.Rotate(Vector3.up * mouseX);
//         
//         // Check for sprint input (Shift key).
//         float currentSpeed;
//         if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
//         {
//             currentSpeed = sprintSpeed;
//         }
//         else
//         {
//             currentSpeed = moveSpeed;
//         }
//     
//         // Move the character using WASD input.
//         movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
//         Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;
//
//         // Check if there is an obstacle in front of the player.
//         RaycastHit hit;
//         if (direction.z > 0 && Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit, 7f))
//         {
//             // If there is an obstacle, stop the player from moving forwards.
//             direction.z = 0;
//             isFacingWall = true;
//         }
//         else
//         {
//             isFacingWall = false;
//         }
//
//         // Apply movement with the adjusted speed.
//         if (canMove && direction.magnitude >= 0.1f)
//         {
//             characterController.Move(transform.TransformDirection(direction) * currentSpeed * Time.deltaTime);
//
//             // Set animation triggers based on input
//             animationsInstance.SetAnimationTriggers(direction);
//         }
//         else
//         {
//             // Reset all animation triggers if no movement
//             animationsInstance.ResetAnimationTriggers();
//         }
//
//         // Handles Rotation
//         rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
//         rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
//         cameraInstance.playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
//     }
//
//     IEnumerator Jump()
//     {
//         yield return new WaitForSeconds(0.2f);
//         isJumping = false;
//     }
//     
//     bool IsCharacterGrounded()
//     {
//         // Cast a ray downward to check for ground contact with tolerance
//         Vector3 origin = transform.position + characterController.center;
//         float radius = characterController.radius;
//         float distance = groundCheckDistance + radius; // Add the radius as tolerance
//
//         if (Physics.SphereCast(origin, radius, Vector3.down, out RaycastHit hitInfo, distance, groundLayer))
//         {
//             return true;
//         }
//         else
//         {
//             return false;
//         }
//     }
// }

