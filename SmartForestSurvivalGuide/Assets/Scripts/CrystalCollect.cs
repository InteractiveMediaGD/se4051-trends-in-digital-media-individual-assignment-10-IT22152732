using UnityEngine;

public class CrystalCollect : MonoBehaviour
{
    public GameObject effect;
    public GameObject completeText;

    private bool collected = false;
    private AudioSource audioSource;

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

            // ? Add score globally
            GameManager.instance.AddScore();

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
            }

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}