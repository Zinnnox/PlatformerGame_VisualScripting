using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    void Update()
    {
        // Move horizontally
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Damage the player
            Debug.Log("Projectile hit the Player!");
            // Destroy projectile
            Destroy(gameObject);
        }
    }
}
