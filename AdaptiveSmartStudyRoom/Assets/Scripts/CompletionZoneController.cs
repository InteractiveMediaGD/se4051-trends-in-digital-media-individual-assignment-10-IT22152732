using UnityEngine;
using TMPro;

public class CompletionZoneController : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public Light targetLight;

    public Color completionColor = Color.magenta;
    public float completionIntensity = 4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (statusText != null)
            {
                statusText.text = "Task Complete - Interactive session finished";
            }

            if (targetLight != null)
            {
                targetLight.color = completionColor;
                targetLight.intensity = completionIntensity;
            }

            Debug.Log("Completion zone entered");
        }
    }
}