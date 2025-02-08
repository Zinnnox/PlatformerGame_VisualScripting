using Unity;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public EnemyDetection playerDetector;
    public float attackCooldown = 2f;
    private float attackTimer;

    void Update()
    {
        attackTimer -= Time.deltaTime;

        if (playerDetector.playerInRange && attackTimer <= 0f)
        {
            // Perform the melee attack
            Debug.Log("Enemy melees the player!");
            // Reset timer
            attackTimer = attackCooldown;
        }
    }
}
