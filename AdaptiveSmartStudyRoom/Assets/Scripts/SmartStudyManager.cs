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

    private float awayTimer = 0f;
    private bool isInStudyZone = false;
    private bool distractionWarningShown = false;

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

        if (!isInStudyZone)
        {
            awayTimer += Time.deltaTime;

            if (awayTimer >= 8f && !distractionWarningShown)
            {
                if (statusText != null)
                    statusText.text = "You are away from the study area. Please return to continue your session.";

                if (sceneLight != null)
                    sceneLight.color = new Color(0.95f, 0.9f, 0.75f);

                if (lampLight != null)
                {
                    lampLight.enabled = true;
                    lampLight.color = new Color(1f, 0.95f, 0.8f);
                    lampLight.intensity = 1.0f;
                }

                distractionWarningShown = true;
            }
        }
    }

    public void EnterStudy()
    {
        isStudying = true;
        isInStudyZone = true;

        studyTimer = 0f;
        awayTimer = 0f;

        warningShown = false;
        distractionWarningShown = false;

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
        isInStudyZone = false;
        awayTimer = 0f;
        distractionWarningShown = false;

        if (statusText != null)
            statusText.text = "Break Mode Activated - Take a short rest and relax.";

        if (sceneLight != null)
            sceneLight.color = new Color(0.75f, 0.8f, 0.95f);

        if (studyLight != null)
            studyLight.SetActive(false);

        if (breakLight != null)
            breakLight.SetActive(true);

        if (lampLight != null)
        {
            lampLight.enabled = true;
            lampLight.color = new Color(1f, 0.92f, 0.8f);
            lampLight.intensity = 1.0f;
        }

        if (soundManager != null)
            soundManager.PlayBreakSound();
    }

    public void CompleteTask()
    {
        isStudying = false;
        isInStudyZone = false;

        if (statusText != null)
            statusText.text = "Session Complete - Great job. Your study interaction has finished successfully.";

        if (sceneLight != null)
            sceneLight.color = new Color(0.85f, 1f, 0.85f);

        if (studyLight != null)
            studyLight.SetActive(false);

        if (breakLight != null)
            breakLight.SetActive(false);

        if (lampLight != null)
        {
            lampLight.enabled = true;
            lampLight.color = new Color(0.75f, 1f, 0.75f);
            lampLight.intensity = 1.4f;
        }

        if (soundManager != null)
            soundManager.PlayCompleteSound();
    }
}