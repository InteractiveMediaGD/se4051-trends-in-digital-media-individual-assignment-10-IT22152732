using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public string zoneType; // "study", "break", "completion"

    private SmartStudyManager manager;

    void Start()
    {
        manager = FindObjectOfType<SmartStudyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneType == "study")
            {
                manager.EnterStudy();
            }
            else if (zoneType == "break")
            {
                manager.ExitStudy();
                manager.statusText.text = "Break Mode Activated - Relax for a moment";
            }
            else if (zoneType == "completion")
            {
                manager.ExitStudy();
                manager.statusText.text = "Task Complete - Interactive session finished";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneType == "study")
            {
                manager.ExitStudy();
            }
        }
    }
}