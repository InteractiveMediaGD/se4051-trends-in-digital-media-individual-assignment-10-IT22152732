using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    public GameObject safeText;
    public Light sceneLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            safeText.SetActive(true);
            RenderSettings.fog = false;
            sceneLight.intensity = 1.4f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            safeText.SetActive(false);
            sceneLight.intensity = 1f;
        }
    }
}