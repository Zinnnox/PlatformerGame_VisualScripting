using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScriptTest : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;  // Horizontal movement speed.
    public float jumpForce = 10f; // Force applied for jumping.
    public int maxJumps = 2;      // Maximum number of jumps allowed.

    [Header("Ground Check")]
    public Transform groundCheck; // Transform to check if the player is on the ground.
    public float groundCheckRadius = 0.2f; // Radius of the ground check sphere.
    public LayerMask groundLayer; // Layer mask to identify ground.

    private Rigidbody2D rb; // Reference to the player's Rigidbody2D.
    private bool isGrounded; // Whether the player is currently grounded.
    private int remainingJumps; // Tracks remaining jumps.

    void Start()
    {
        // Get the Rigidbody2D component attached to the player.
        rb = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps; // Initialize jumps.
    }

    void Update()
    {
        // Handle horizontal movement.
        float moveInput = Input.GetAxis("Horizontal"); // Get input (A/D, Left/Right keys).
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player's sprite based on movement direction.
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Check if the player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Reset jumps if grounded.
        if (isGrounded)
        {
            remainingJumps = maxJumps;
        }

        // Handle jumping.
        if (Input.GetButtonDown("Jump") && remainingJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            remainingJumps--; // Decrease remaining jumps by 1.
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the ground check radius in the editor.
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
