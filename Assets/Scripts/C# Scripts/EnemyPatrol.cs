using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public LayerMask groundLayer;     // Which layer is considered ground
    public float speed = 2f;          // Speed of the enemy
    public float patrolDistance = 5f; // Distance to patrol before flipping
    
    private bool movingRight = true;
    private Rigidbody2D rb;
    private Vector2 startPosition; // Initial position of the enemy
    
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }
    
    void Update()
    {
        // Move enemy horizontally
        float moveDirection = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
    
        // Check if the enemy has reached the patrol distance
        if (movingRight && rb.position.x >= startPosition.x + patrolDistance)
        {
            Flip();
        }
        else if (!movingRight && rb.position.x <= startPosition.x - patrolDistance)
        {
            Flip();
        }
    }
    
    void Flip()
    {
        // Switch direction
        movingRight = !movingRight;
    
        // Flip the sprite horizontally
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
