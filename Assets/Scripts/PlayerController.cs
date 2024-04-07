using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashForcex;
    public float dashForcey;
    public LayerMask groundLayer;

    public float spikeDamage;

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

    public GameObject selectedCharacter;
    public PlayerStats playerStats;

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
        //HandleDash();
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Spike")
        {
            print("Should be taking damage");
            TakeDamage(spikeDamage);
        }
    }
    void TakeDamage(float amount)
    {
        playerStats.oxygen -= amount;
    }
    private void HandleDash()
    {
        if(Input.GetMouseButtonDown(1))
        {
            spriteRenderer.sprite = ballSprite;
            //isDashing = true;
            dashArrow.SetActive(true);
            rb.useGravity = false;
            rb.drag = 100;
            //mainCollider.enabled = false;

        }

        if(Input.GetMouseButtonUp(1))
        {
            float dashAngle = dashScript.GetComponent<DashArrow>().dashAngle;
            rb.drag = 0;
            spriteRenderer.sprite = normalSprite;
            //isDashing = false;
            rb.useGravity = true;
            dashArrow.SetActive(false);
            Dash();
            //StartCoroutine(WaitToTurnOnCollider());
        }
    }
    IEnumerator WaitToTurnOnCollider()
    {
        yield return new WaitForSeconds(0.5f);
        mainCollider.enabled = true;
        rb.useGravity = true;
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

    private void Dash()
    {
        rb.velocity = new Vector2(0, 0);
        // Convert the angle to radians
        float angleInRadians = dashArrow.GetComponent<DashArrow>().dashAngle * Mathf.Deg2Rad;

        // Calculate the direction based on the angle
        Vector2 dashDirection = new Vector2(Mathf.Cos(angleInRadians) * dashForcex, Mathf.Sin(angleInRadians) * dashForcey);

        // Apply force in the calculated direction
        //rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        rb.AddForce(dashDirection, ForceMode.Impulse);
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
        print(dashDirection);
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
