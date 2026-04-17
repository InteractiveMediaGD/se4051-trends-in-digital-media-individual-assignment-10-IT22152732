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

    private int focusScore = 100;
    private int breakCount = 0;

    void Start()
    {
        if (statusText != null)
            statusText.text = "Move to the desk to begin your study session.";
    }

    void Update()
    {
        if (isStudying)
        {
            studyTimer += Time.deltaTime;

            focusScore = Mathf.Min(100, focusScore + 1);

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

        if (focusScore <= 60)
        {
            if (statusText != null)
                statusText.text = "Context Alert: Focus score is low. Please return to the study area.";

            if (sceneLight != null)
                sceneLight.color = new Color(1f, 0.82f, 0.82f);

            if (lampLight != null)
            {
                lampLight.enabled = true;
                lampLight.color = new Color(1f, 0.88f, 0.88f);
                lampLight.intensity = 1.0f;
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
            statusText.text = "Study Mode Activated - Focus Score: " + focusScore;

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

        if (focusScore > 60)
        {
            if (statusText != null)
                statusText.text = "Study Mode Activated - Focus Score: " + focusScore + " (Good focus)";

            if (sceneLight != null)
                sceneLight.color = new Color(0.95f, 0.95f, 1f);

            if (lampLight != null)
            {
                lampLight.enabled = true;
                lampLight.color = new Color(1f, 1f, 0.95f);
                lampLight.intensity = 1.8f;
            }
        }
    }

    public void ExitStudy()
    {
        isStudying = false;
        isInStudyZone = false;
        awayTimer = 0f;
        distractionWarningShown = false;
        breakCount++;
        focusScore -= 10;

        if (statusText != null)
            statusText.text = "Break Mode Activated - Focus Score: " + focusScore;

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
            statusText.text = "Session Complete - Final Focus Score: " + focusScore;

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