using UnityEngine;
using TMPro;

public class DangerZoneScript : MonoBehaviour
{
    public GameObject warningText;
    public Light sceneLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningText.SetActive(true);

            // Enable fog
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.05f;

            // Darken light
            sceneLight.intensity = 0.3f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningText.SetActive(false);

            // Disable fog
            RenderSettings.fog = false;

            // Restore light
            sceneLight.intensity = 1f;
        }
    }
}