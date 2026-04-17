using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private float moveX;
    private float moveZ;

    private Vector3 lastPosition;
    private float idleTimer = 0f;

    public SmartStudyManager studyManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        float movedDistance = Vector3.Distance(transform.position, lastPosition);

        if (movedDistance < 0.01f)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= 5f && studyManager != null && studyManager.statusText != null)
            {
                studyManager.statusText.text = "You seem idle. Move to continue the study session.";
            }
        }
        else
        {
            idleTimer = 0f;
            lastPosition = transform.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}