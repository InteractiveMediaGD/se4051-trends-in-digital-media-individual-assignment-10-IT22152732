using UnityEngine;
using System.Collections;

public class GemBoxWin : MonoBehaviour
{
    public GameObject completeText;
    public GameObject collectAllText;
    public GameObject winSparkleEffect;

    public AudioSource winAudio;
    public AudioClip winClip;

    private bool missionCompleted = false;
    private Coroutine warningRoutine;

    void Start()
    {
        if (completeText != null)
            completeText.SetActive(false);

        if (collectAllText != null)
            collectAllText.SetActive(false);

        if (winSparkleEffect != null)
            winSparkleEffect.SetActive(false);

        if (winAudio == null)
            winAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (missionCompleted)
            return;

        // If player has not collected all crystals, show warning on screen
        if (GameManager.instance != null && !GameManager.instance.HasCollectedAllCrystals())
        {
            ShowCollectAllWarning();
            UnityEngine.Debug.Log("Collect all crystals before opening the GemBox.");
            return;
        }

        missionCompleted = true;

        if (completeText != null)
            completeText.SetActive(true);

        if (collectAllText != null)
            collectAllText.SetActive(false);

        if (winSparkleEffect != null)
            winSparkleEffect.SetActive(true);

        if (winAudio != null)
        {
            winAudio.volume = 1f;
            winAudio.spatialBlend = 0f;

            if (winClip != null)
                winAudio.PlayOneShot(winClip, 1f);
            else if (winAudio.clip != null)
                winAudio.PlayOneShot(winAudio.clip, 1f);
        }

        UnityEngine.Debug.Log("MISSION COMPLETE: GemBox reached.");
    }

    private void ShowCollectAllWarning()
    {
        if (collectAllText == null)
            return;

        collectAllText.SetActive(true);

        if (warningRoutine != null)
            StopCoroutine(warningRoutine);

        warningRoutine = StartCoroutine(HideCollectAllWarning());
    }

    private IEnumerator HideCollectAllWarning()
    {
        yield return new WaitForSeconds(2.5f);

        if (collectAllText != null)
            collectAllText.SetActive(false);
    }
}