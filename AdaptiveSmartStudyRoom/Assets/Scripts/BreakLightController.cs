using UnityEngine;

public class BreakLightController : MonoBehaviour
{
    public Light targetLight;

    public Color normalColor = Color.white;
    public Color breakColor = Color.green;

    public float normalIntensity = 1f;
    public float breakIntensity = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && targetLight != null)
        {
            targetLight.color = breakColor;
            targetLight.intensity = breakIntensity;
            Debug.Log("Break light activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && targetLight != null)
        {
            targetLight.color = normalColor;
            targetLight.intensity = normalIntensity;
            Debug.Log("Break light deactivated");
        }
    }
}