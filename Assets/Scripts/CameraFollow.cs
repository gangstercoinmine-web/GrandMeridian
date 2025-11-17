using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // Player
    public Vector3 offset = new Vector3(0, 3, -6);
    public float smoothSpeed = 10f;
    public float lookSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Smooth follow position
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Smooth rotate to face target
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lookSpeed * Time.deltaTime);
    }
}
