using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script
    public Image[] hearts;            // An array of Image references to your heart icons
    public Sprite fullHeart;          // Sprite for a full heart
    public Sprite emptyHeart;         // Sprite for an empty heart

    void Update()
    {
        // For each heart slot, show full or empty depending on currentHearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.currentHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
