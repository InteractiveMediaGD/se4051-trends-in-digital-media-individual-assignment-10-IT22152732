using UnityEngine;

public class TigerPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float moveSpeed = 2f;
    public float turnSpeed = 5f;
    public float stopDistance = 0.5f;

    private Transform targetPoint;

    void Start()
    {
        targetPoint = pointB;
    }

    void Update()
    {
        if (pointA == null || pointB == null)
            return;

        MoveTiger();
    }

    void MoveTiger()
    {
        Vector3 direction = targetPoint.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude <= stopDistance)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}