using UnityEngine;

public class AdaptiveLightController : MonoBehaviour
{
    public Light targetLight;

    public Color normalColor = Color.white;
    public Color studyColor = Color.cyan;

    public float normalIntensity = 1f;
    public float studyIntensity = 3f;

    private void Start()
    {
        if (targetLight != null)
        {
            targetLight.color = normalColor;
            targetLight.intensity = normalIntensity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && targetLight != null)
        {
            targetLight.color = studyColor;
            targetLight.intensity = studyIntensity;
            Debug.Log("Study mode activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && targetLight != null)
        {
            targetLight.color = normalColor;
            targetLight.intensity = normalIntensity;
            Debug.Log("Study mode deactivated");
        }
    }
}