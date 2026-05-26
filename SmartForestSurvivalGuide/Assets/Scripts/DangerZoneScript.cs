using UnityEngine;

public class DangerZoneScript : MonoBehaviour
{
    public GameObject warningText;
    public GameObject safeText;
    public GameObject completeText;

    public Light sceneLight;
    public HealthManager healthManager;

    public AudioSource dangerAudio;
    public AudioClip dangerClip;

    public AudioSource backgroundMusic;

    private void Start()
    {
        if (warningText != null)
            warningText.SetActive(false);

        if (dangerAudio == null)
            dangerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show only danger text
            if (warningText != null)
                warningText.SetActive(true);

            if (safeText != null)
                safeText.SetActive(false);

            if (completeText != null)
                completeText.SetActive(false);

            // Play danger sound
            if (dangerAudio != null)
            {
                if (backgroundMusic != null)
                {
                    backgroundMusic.volume = 0.05f;
                    Invoke(nameof(RestoreBackgroundMusic), 2.5f);
                }

                if (dangerClip != null)
                {
                    dangerAudio.PlayOneShot(dangerClip, 1f);
                }
                else if (dangerAudio.clip != null)
                {
                    dangerAudio.PlayOneShot(dangerAudio.clip, 1f);
                }
            }

            // Environment effect
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.12f;
            RenderSettings.fogColor = Color.gray;

            if (sceneLight != null)
            {
                sceneLight.color = Color.red;
                sceneLight.intensity = 0.1f;
            }

            if (healthManager != null)
                healthManager.ReduceHealth(20);

            UnityEngine.Debug.Log("DANGER ZONE ENTERED");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (warningText != null)
                warningText.SetActive(false);

            RenderSettings.fog = false;

            if (sceneLight != null)
            {
                sceneLight.color = Color.white;
                sceneLight.intensity = 1f;
            }
        }
    }

    private void RestoreBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = 0.25f;
        }
    }
}