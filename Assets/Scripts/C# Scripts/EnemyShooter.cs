using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint; // empty child object from where projectiles spawn
    public EnemyDetection playerDetector;
    public float shootCooldown = 2f;
    private float shootTimer;

    void Update()
    {
        shootTimer -= Time.deltaTime;

        // If player is in range and we can shoot again
        if (playerDetector.playerInRange && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    void Shoot()
    {
        // Instantiate projectile at the shoot point
        Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Debug.Log("Enemy shoots a projectile!");
    }
}
