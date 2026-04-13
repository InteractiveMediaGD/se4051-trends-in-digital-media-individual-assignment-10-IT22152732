using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private float moveX;
    private float moveZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}