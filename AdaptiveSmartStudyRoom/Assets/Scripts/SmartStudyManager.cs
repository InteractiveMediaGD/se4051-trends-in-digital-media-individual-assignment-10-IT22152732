using UnityEngine;
using TMPro;

public class SmartStudyManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public Light sceneLight;
    public SoundManager soundManager;

    public GameObject studyLight;
    public GameObject breakLight;

    public Light lampLight;

    private float studyTimer = 0f;
    private bool isStudying = false;
    private bool warningShown = false;

    void Update()
    {
        if (isStudying)
        {
            studyTimer += Time.deltaTime;

            if (studyTimer >= 10f && !warningShown)
            {
                if (statusText != null)
                    statusText.text = "You have been studying for a while. Consider taking a break.";

                if (sceneLight != null)
                    sceneLight.color = Color.yellow;

                warningShown = true;
            }
        }
    }

    public void EnterStudy()
    {
        isStudying = true;
        studyTimer = 0f;
        warningShown = false;

        if (statusText != null)
            statusText.text = "Study Mode Activated - Focus!";

        if (sceneLight != null)
            sceneLight.color = Color.white;

        if (studyLight != null)
            studyLight.SetActive(true);

        if (breakLight != null)
            breakLight.SetActive(false);

        if (lampLight != null)
        {
            lampLight.enabled = true;
            lampLight.color = Color.white;
            lampLight.intensity = 2.0f;
        }

        if (soundManager != null)
            soundManager.PlayStudySound();
    }

    public void ExitStudy()
    {
        isStudying = false;

        if (statusText != null)
            statusText.text = "Break Mode - Relax";

        if (sceneLight != null)
            sceneLight.color = new Color(0.6f, 0.7f, 1f); // soft blue

        if (studyLight != null)
            studyLight.SetActive(false);

        if (breakLight != null)
            breakLight.SetActive(true);

        if (lampLight != null)
        {
            lampLight.enabled = true;
            lampLight.color = new Color(1f, 0.9f, 0.7f); // softer warm
            lampLight.intensity = 1.2f;

            if (soundManager != null)
            soundManager.PlayBreakSound();
    }

    public void CompleteTask()
    {
        isStudying = false;

        if (statusText != null)
            statusText.text = "Task Complete - Well done!";

        if (studyLight != null)
            studyLight.SetActive(false);

        if (breakLight != null)
            breakLight.SetActive(false);

        if (lampLight != null)
        {
            lampLight.enabled = true;
            lampLight.color = new Color(0.6f, 1f, 0.6f); // soft success green
            lampLight.intensity = 1.8f;
        }

        if (soundManager != null)
            soundManager.PlayCompleteSound();
    }
}