using UnityEngine;

public class CrystalRotate : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float floatSpeed = 1.5f;
    public float floatHeight = 0.2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate crystal
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Small floating movement
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}