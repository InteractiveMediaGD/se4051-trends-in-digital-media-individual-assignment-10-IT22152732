using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 120f;

    public float playerHeightOffset = 1.1f;

    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private float verticalVelocity = 0f;
    private bool isJumping = false;

    void Update()
    {
        float moveInput = 0f;
        float turnInput = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            moveInput = 1f;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            moveInput = -1f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            turnInput = -1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            turnInput = 1f;

        transform.Rotate(0f, turnInput * turnSpeed * Time.deltaTime, 0f);

        Vector3 newPosition = transform.position + transform.forward * moveInput * speed * Time.deltaTime;

        float terrainY = GetTerrainHeight(newPosition);

        if (!isJumping)
        {
            newPosition.y = terrainY + playerHeightOffset;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
            newPosition.y += verticalVelocity * Time.deltaTime;

            if (newPosition.y <= terrainY + playerHeightOffset)
            {
                newPosition.y = terrainY + playerHeightOffset;
                isJumping = false;
                verticalVelocity = 0f;
            }
        }

        transform.position = newPosition;
    }

    float GetTerrainHeight(Vector3 position)
    {
        Terrain terrain = Terrain.activeTerrain;

        if (terrain == null)
        {
            return position.y - playerHeightOffset;
        }

        return terrain.SampleHeight(position) + terrain.transform.position.y;
    }
}