using UnityEngine;
using TMPro;

public class BreakZoneController : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Break mode activated");

            if (statusText != null)
            {
                statusText.text = "Break Mode Activated - Relax for a moment";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Break mode deactivated");

            if (statusText != null)
            {
                statusText.text = "Exited Break Mode";
            }
        }
    }
}