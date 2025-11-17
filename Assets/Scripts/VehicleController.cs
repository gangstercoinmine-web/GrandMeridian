using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    public float motorForce = 1500f;
    public float steeringAngle = 40f;
    public float maxSpeed = 25f;
    public float brakeForce = 3000f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.centerOfMass = new Vector3(0f, -0.5f, 0f);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");   // forward/back
        float h = Input.GetAxis("Horizontal"); // steer

        // forward force
        rb.AddForce(transform.forward * v * motorForce * Time.fixedDeltaTime);

        // steering: rotate the vehicle transform (simple approach)
        if (Mathf.Abs(rb.velocity.magnitude) > 0.1f)
        {
            float steer = h * steeringAngle * Time.fixedDeltaTime * Mathf.Sign(Vector3.Dot(transform.forward, rb.velocity));
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, steer, 0f));
        }

        // clamp speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limited = flatVel.normalized * maxSpeed;
            rb.velocity = new Vector3(limited.x, rb.velocity.y, limited.z);
        }

        // brake by space
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(-rb.velocity * brakeForce * Time.fixedDeltaTime);
        }
    }
}
