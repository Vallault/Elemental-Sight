using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    public bool isGrounded;
    public bool facingRight = true;
    public bool isDashing;
    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite ballSprite;
    public GameObject dashArrow;
    public GameObject dashScript;
    public Collider mainCollider;

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
        HandleDash();
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

    private void HandleDash()
    {
        if(Input.GetMouseButtonDown(1))
        {
            spriteRenderer.sprite = ballSprite;
            isDashing = true;
            dashArrow.SetActive(true);
            rb.useGravity = false;
            mainCollider.enabled = false;
        }

        if(Input.GetMouseButtonUp(1))
        {
            spriteRenderer.sprite = normalSprite;
            isDashing = false;
            dashArrow.SetActive(false);
            rb.AddForce(dashArrow.transform.up * dashForce, ForceMode.Impulse);
            rb.useGravity = true;
            StartCoroutine(WaitToTurnOnCollider()); 

        }
    }
    IEnumerator WaitToTurnOnCollider()
    {
        yield return new WaitForSeconds(0.2f);
        mainCollider.enabled = true;
    }
    private void HandleMovement()
    {
        if(isDashing == false)
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

    }

    private void Move()
    {
        if (isDashing == false)
        {
            // Apply horizontal movement
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, 0f);
        }

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
