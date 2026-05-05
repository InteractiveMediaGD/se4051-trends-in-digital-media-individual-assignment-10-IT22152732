using UnityEngine;
using TMPro;

public class CrystalCollect : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject effect;
    public GameObject completeText;

    private int score = 0;
    private AudioSource audioSource;
    private bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (completeText != null)
        {
            completeText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;

            score++;
            scoreText.text = "Score: " + score;

            if (effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }

            if (completeText != null)
            {
                completeText.SetActive(true);

                TMP_Text txt = completeText.GetComponent<TMP_Text>();
                txt.text = "Mission Complete: Forest Energy Restored!";
            }

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}