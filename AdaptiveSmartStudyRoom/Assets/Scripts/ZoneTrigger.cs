using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public string zoneType; // study, break, completion

    private SmartStudyManager manager;

    void Start()
    {
        manager = FindObjectOfType<SmartStudyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && manager != null)
        {
            if (zoneType == "study")
            {
                manager.EnterStudy();
            }
            else if (zoneType == "break")
            {
                manager.ExitStudy();
            }
            else if (zoneType == "completion")
            {
                manager.CompleteTask();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && manager != null)
        {
            if (zoneType == "study")
            {
                manager.ExitStudy();
            }
        }
    }
}