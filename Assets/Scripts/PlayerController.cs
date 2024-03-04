using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    public bool isGrounded;
    public bool facingRight = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundLayer = LayerMask.GetMask("Ground"); // Set the layer for your ground objects
    }

    private void Update()
    {
        // Check if the player is grounded using raycasting
        CheckGround();

        // Handle player input
        HandleMovement();

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Apply movement forces in FixedUpdate for better physics behavior
        Move();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Normalize movement to prevent faster diagonal movement
        movement.Normalize();

        // Flip the player model based on the direction
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }
    }

    private void Move()
    {
        // Apply horizontal movement
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, 0f);
    }

    private void Jump()
    {
        // Apply vertical force for jumping
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
    }


    void CheckGround()
    {
        // Perform a raycast straight down to check for ground
        float raycastDistance = 2.5f;
        RaycastHit hit;
        if( Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
