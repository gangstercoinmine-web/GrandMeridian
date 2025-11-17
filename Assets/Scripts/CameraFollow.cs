using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2.5f, -4f);
    public float followSmooth = 10f;
    public float rotationSmooth = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desired, followSmooth * Time.deltaTime);

        Quaternion look = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, rotationSmooth * Time.deltaTime);
    }
}
