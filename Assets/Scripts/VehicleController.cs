using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float acceleration = 2000f;
    public float steering = 15f;
    public float maxSpeed = 20f;
    public float brakeForce = 3000f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.centerOfMass = new Vector3(0, -0.5f, 0); // improves stability
    }

    void FixedUpdate()
    {
        float accelerateInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        // Forward & reverse movement
        if (accelerateInput != 0)
        {
            rb.AddForce(transform.forward * accelerateInput * acceleration * Time.deltaTime);
        }

        // Limit speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatVel.magnitude > maxSpeed)
        {
            rb.velocity = flatVel.normalized * maxSpeed;
        }

        // Steering
        if (steerInput != 0)
        {
            transform.Rotate(Vector3.up, steerInput * steering * Time.deltaTime);
        }

        // Brake
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(-rb.velocity * brakeForce * Time.deltaTime);
        }
    }
}
