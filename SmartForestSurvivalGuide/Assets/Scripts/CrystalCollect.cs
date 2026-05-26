using UnityEngine;

public class CrystalCollect : MonoBehaviour
{
    public GameObject effect;
    public AudioClip collectSound;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (collected)
            return;

        collected = true;

        // Add score
        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore();
        }

        // Play collect sound separately so it will not stop when crystal hides
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
        }

        // Spawn collect effect
        if (effect != null)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        // Disable all colliders in parent and children
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }

        // Hide all visible crystal parts
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        // Turn off crystal glow lights
        Light[] lights = GetComponentsInChildren<Light>();
        foreach (Light l in lights)
        {
            l.enabled = false;
        }

        Debug.Log(gameObject.name + " collected and hidden");
    }
}