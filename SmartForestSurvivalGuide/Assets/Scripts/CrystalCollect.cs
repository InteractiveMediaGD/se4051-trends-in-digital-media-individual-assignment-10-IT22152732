using UnityEngine;
using TMPro;

public class CrystalCollect : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject effect;

    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            score++;
            scoreText.text = "Score: " + score;

            // Play effect
            Instantiate(effect, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
        }
    }
}