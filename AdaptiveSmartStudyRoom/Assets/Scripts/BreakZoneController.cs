using UnityEngine;
using TMPro;

public class BreakZoneController : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && statusText != null)
        {
            statusText.text = "Break Mode Activated - Relax for a moment";
            Debug.Log("Break mode activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && statusText != null)
        {
            statusText.text = "Exited Break Mode";
            Debug.Log("Break mode deactivated");
        }
    }
}