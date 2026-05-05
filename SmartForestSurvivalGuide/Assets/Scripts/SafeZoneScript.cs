using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    public GameObject safeText;
    public GameObject warningText;
    public GameObject completeText;

    public Light sceneLight;

    private void Start()
    {
        safeText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show only safe text
            safeText.SetActive(true);
            warningText.SetActive(false);
            completeText.SetActive(false);

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