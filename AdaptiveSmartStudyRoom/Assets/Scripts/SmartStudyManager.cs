using UnityEngine;
using TMPro;

public class SmartStudyManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public Light sceneLight;
    public SoundManager soundManager;

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
                statusText.text = "You have been studying for a while. Consider taking a break.";
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

        statusText.text = "Study Mode Activated";
        sceneLight.color = Color.white;

        if (soundManager != null)
            soundManager.PlayStudySound();
    }

    public void ExitStudy()
    {
        isStudying = false;

        statusText.text = "Break Mode Activated - Relax for a moment";
        sceneLight.color = Color.blue;

        if (soundManager != null)
            soundManager.PlayBreakSound();
    }

    public void CompleteTask()
    {
        isStudying = false;

        statusText.text = "Task Complete - Interactive session finished";
        sceneLight.color = Color.green;

        if (soundManager != null)
            soundManager.PlayCompleteSound();
    }
}