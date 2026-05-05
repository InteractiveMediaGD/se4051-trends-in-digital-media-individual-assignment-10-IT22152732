using UnityEngine;

public class DangerZoneScript : MonoBehaviour
{
    public GameObject warningText;
    public GameObject safeText;
    public GameObject completeText;

    public Light sceneLight;
    public HealthManager healthManager;

    private void Start()
    {
        warningText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show only danger text
            warningText.SetActive(true);
            safeText.SetActive(false);
            completeText.SetActive(false);

            // Environment effect
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.12f;
            RenderSettings.fogColor = Color.gray;

            sceneLight.intensity = 0.1f;

            if (healthManager != null)
                healthManager.ReduceHealth(20);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningText.SetActive(false);

            RenderSettings.fog = false;
            sceneLight.intensity = 1f;
        }
    }
}