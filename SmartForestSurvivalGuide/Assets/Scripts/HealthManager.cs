using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public TMP_Text healthText;
    public int health = 100;

    public void ReduceHealth(int amount)
    {
        health -= amount;

        if (health < 0)
        {
            health = 0;
        }

        UpdateUI();
    }

    public void RestoreHealth(int amount)
    {
        health += amount;

        if (health > 100)
        {
            health = 100;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
    }
}