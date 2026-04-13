using UnityEngine;
using TMPro;

public class InactivityDetector : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public float inactivityTime = 5f;

    private Vector3 lastPosition;
    private float idleTimer;

    private void Start()
    {
        lastPosition = transform.position;
        idleTimer = 0f;
    }

    private void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        if (distanceMoved > 0.01f)
        {
            idleTimer = 0f;
            lastPosition = transform.position;
        }
        else
        {
            idleTimer += Time.deltaTime;
        }

        if (idleTimer >= inactivityTime)
        {
            if (statusText != null)
            {
                statusText.text = "You seem inactive. Try exploring the room.";
            }
        }
    }
}