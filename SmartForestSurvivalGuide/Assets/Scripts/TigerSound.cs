using UnityEngine;

public class TigerSound : MonoBehaviour
{
    public Transform player;
    public AudioSource tigerAudio;
    public AudioClip tigerRoarClip;

    public float detectionDistance = 15f;
    public float lookAngle = 45f;

    private bool hasPlayed = false;

    void Start()
    {
        if (tigerAudio == null)
        {
            tigerAudio = GetComponent<AudioSource>();
        }

        if (tigerAudio != null)
        {
            tigerAudio.playOnAwake = false;
            tigerAudio.loop = false;
            tigerAudio.spatialBlend = 0f;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        Vector3 directionToTiger = transform.position - player.position;
        directionToTiger.y = 0f;

        float distance = directionToTiger.magnitude;

        if (distance > detectionDistance)
        {
            hasPlayed = false;
            return;
        }

        float angle = Vector3.Angle(player.forward, directionToTiger.normalized);

        if (angle <= lookAngle)
        {
            if (!hasPlayed)
            {
                PlayTigerSound();
                hasPlayed = true;
            }
        }
        else
        {
            hasPlayed = false;
        }
    }

    void PlayTigerSound()
    {
        if (tigerAudio == null)
        {
            UnityEngine.Debug.LogWarning("Tiger AudioSource missing.");
            return;
        }

        if (tigerRoarClip != null)
        {
            tigerAudio.PlayOneShot(tigerRoarClip, 1f);
        }
        else if (tigerAudio.clip != null)
        {
            tigerAudio.PlayOneShot(tigerAudio.clip, 1f);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Tiger roar clip missing.");
        }

        UnityEngine.Debug.Log("Tiger roar played because player looked at tiger.");
    }
}