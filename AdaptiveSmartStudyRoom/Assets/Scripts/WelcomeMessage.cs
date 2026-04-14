using UnityEngine;
using TMPro;
using System.Collections;

public class WelcomeMessage : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    void Start()
    {
        StartCoroutine(ShowWelcome());
    }

    IEnumerator ShowWelcome()
    {
        if (statusText != null)
        {
            statusText.text = "Use W A S D to move. Enter zones to interact.";
        }

        yield return new WaitForSeconds(3f);

        if (statusText != null)
        {
            statusText.text = "Move into the zone to activate study mode";
        }
    }
}