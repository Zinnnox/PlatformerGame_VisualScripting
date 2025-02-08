using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;     // How many hearts total
    public int currentHearts;     // How many hearts remain

    void Start()
    {
        // Start with full health
        currentHearts = maxHearts;
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        if (currentHearts < 0)
        {
            currentHearts = 0;
        }
        Debug.Log("Player took damage! Hearts left: " + currentHearts);
    }

    // Example for healing
    public void Heal(int amount)
    {
        currentHearts += amount;
        if (currentHearts > maxHearts)
        {
            currentHearts = maxHearts;
        }
        Debug.Log("Player healed! Hearts left: " + currentHearts);
    }
}
