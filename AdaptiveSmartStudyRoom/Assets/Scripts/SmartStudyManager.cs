using UnityEngine;
using TMPro;
using System.Collections;

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

    private string[] smartTips = {
        "Take a deep breath.",
        "Stretch your body.",
        "Drink some water.",
        "Focus on one task at a time."
    };

    private Color targetSceneLightColor;
    private Color targetLampLightColor;
    private float targetLampIntensity;

    private bool isShowingTemporaryMessage = false;

    void Start()
    {

        statusText.text = "Welcome to Smart Study Room. Move to the desk to begin.";

        if (statusText != null)
            statusText.text = "Move to the desk to begin your study session.";

        targetSceneLightColor = sceneLight.color;
        targetLampLightColor = lampLight.color;
        targetLampIntensity = lampLight.intensity;
    }

    void Update()
    {
        // Smooth lighting
        sceneLight.color = Color.Lerp(sceneLight.color, targetSceneLightColor, Time.deltaTime * 2f);
        lampLight.color = Color.Lerp(lampLight.color, targetLampLightColor, Time.deltaTime * 2f);
        lampLight.intensity = Mathf.Lerp(lampLight.intensity, targetLampIntensity, Time.deltaTime * 2f);

        // Study behavior
        if (isStudying)
        {
            studyTimer += Time.deltaTime;
            focusScore = Mathf.Min(100, focusScore + 1);

            if (studyTimer >= 10f && !warningShown)
            {
                string tip = smartTips[Random.Range(0, smartTips.Length)];
                StartCoroutine(ShowTemporaryMessage("You have been studying for a while. " + tip, 3f));

                targetSceneLightColor = Color.yellow;
                targetLampLightColor = new Color(1f, 0.95f, 0.8f);
                targetLampIntensity = 1.4f;

                warningShown = true;
            }
        }

        // Away warning
        if (!isInStudyZone && !isStudying)
        {
            awayTimer += Time.deltaTime;

            if (awayTimer >= 8f && !distractionWarningShown)
            {
                StartCoroutine(ShowTemporaryMessage(
                    "You are away from the study area. Please return.", 3f));

                targetSceneLightColor = new Color(0.95f, 0.9f, 0.75f);

                distractionWarningShown = true;
            }
        }

        // Low focus alert
        if (focusScore <= 60 && !isStudying && !isShowingTemporaryMessage)
        {
            StartCoroutine(ShowTemporaryMessage(
                "Focus is low. Return to study.", 3f));

            targetSceneLightColor = new Color(1f, 0.82f, 0.82f);
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

        // Smart feedback
        if (focusScore >= 90)
            statusText.text = "Excellent focus! Score: " + focusScore;
        else if (focusScore >= 70)
            statusText.text = "Good focus! Score: " + focusScore;
        else if (focusScore >= 50)
            statusText.text = "Focus improving. Score: " + focusScore;
        else
            statusText.text = "Low focus. Try harder. Score: " + focusScore;

        targetSceneLightColor = new Color(0.95f, 0.95f, 1f);
        targetLampLightColor = new Color(1f, 1f, 0.95f);
        targetLampIntensity = 1.8f;

        studyLight.SetActive(true);
        breakLight.SetActive(false);

        soundManager.PlayStudySound();
    }

    public void ExitStudy()
    {
        isStudying = false;
        isInStudyZone = false;

        breakCount++;
        focusScore = Mathf.Max(0, focusScore - 10);

        statusText.text = "Break Mode - Score: " + focusScore;

        targetSceneLightColor = new Color(0.75f, 0.8f, 0.95f);
        targetLampLightColor = new Color(1f, 0.92f, 0.8f);
        targetLampIntensity = 1.0f;

        studyLight.SetActive(false);
        breakLight.SetActive(true);

        soundManager.PlayBreakSound();
    }

    public void CompleteTask()
    {
        isStudying = false;
        isInStudyZone = false;

        statusText.text = "Session Complete! Final Score: " + focusScore;

        targetSceneLightColor = new Color(0.85f, 1f, 0.85f);
        targetLampLightColor = new Color(0.75f, 1f, 0.75f);
        targetLampIntensity = 1.4f;

        studyLight.SetActive(false);
        breakLight.SetActive(false);

        soundManager.PlayCompleteSound();
    }

    IEnumerator ShowTemporaryMessage(string message, float duration)
    {
        if (isShowingTemporaryMessage) yield break;

        isShowingTemporaryMessage = true;

        statusText.text = message;

        yield return new WaitForSeconds(duration);

        isShowingTemporaryMessage = false;
    }
}