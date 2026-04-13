using UnityEngine;
using TMPro;

public class UIStatusController : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    private void Start()
    {
        if (statusText != null)
        {
            statusText.text = "Move into the zone to activate study mode";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && statusText != null)
        {
            statusText.text = "Study Mode Activated";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && statusText != null)
        {
            statusText.text = "Study Mode Deactivated";
        }
    }
}