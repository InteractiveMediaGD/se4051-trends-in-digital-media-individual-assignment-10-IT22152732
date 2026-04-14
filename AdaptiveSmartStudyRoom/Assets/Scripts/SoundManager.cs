using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip studyClip;
    public AudioClip breakClip;
    public AudioClip completeClip;

    public void PlayStudySound()
    {
        if (audioSource != null && studyClip != null)
        {
            audioSource.clip = studyClip;
            audioSource.Play();
        }
    }

    public void PlayBreakSound()
    {
        if (audioSource != null && breakClip != null)
        {
            audioSource.clip = breakClip;
            audioSource.Play();
        }
    }

    public void PlayCompleteSound()
    {
        if (audioSource != null && completeClip != null)
        {
            audioSource.clip = completeClip;
            audioSource.Play();
        }
    }
}