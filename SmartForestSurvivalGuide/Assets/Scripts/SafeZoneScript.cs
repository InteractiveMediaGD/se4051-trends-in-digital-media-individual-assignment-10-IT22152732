using UnityEngine;
using System.Collections;

public class SafeZoneScript : MonoBehaviour
{
    public GameObject safeText;
    public Light directionalLight;
    public AudioSource safeAudio;
    public AudioClip safeClip;
    public AudioSource backgroundMusic;

    private Coroutine hideRoutine;
    private bool playedOnce = false;

    void Start()
    {
        if (safeText != null)
        {
            safeText.SetActive(false);
        }

        if (safeAudio == null)
        {
            safeAudio = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (safeText != null)
        {
            safeText.SetActive(true);

            if (hideRoutine != null)
            {
                StopCoroutine(hideRoutine);
            }

            hideRoutine = StartCoroutine(HideSafeText());
        }

        if (backgroundMusic != null)
        {
            backgroundMusic.volume = 0.08f;
        }

        if (safeAudio != null)
        {
            if (safeClip != null)
            {
                safeAudio.PlayOneShot(safeClip, 1f);
            }
            else if (safeAudio.clip != null)
            {
                safeAudio.PlayOneShot(safeAudio.clip, 1f);
            }
            else
            {
                UnityEngine.Debug.LogWarning("Safe sound missing: assign Audio Clip or Safe Clip.");
            }
        }
        else
        {
            UnityEngine.Debug.LogWarning("Safe AudioSource missing on SafeZone.");
        }

        if (directionalLight != null)
        {
            directionalLight.color = Color.white;
            directionalLight.intensity = 1.2f;
        }

        RenderSettings.fog = false;

        UnityEngine.Debug.Log("SAFE ZONE ENTERED: Environment restored");
    }

    IEnumerator HideSafeText()
    {
        yield return new WaitForSeconds(2f);

        if (safeText != null)
        {
            safeText.SetActive(false);
        }
    }
    IEnumerator RestoreBackgroundMusic()
    {
        yield return new WaitForSeconds(2.5f);

        if (backgroundMusic != null)
        {
            backgroundMusic.volume = 0.25f;
        }
    }
}