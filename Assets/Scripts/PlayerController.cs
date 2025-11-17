using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 3.5f;
    public float runSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    [HideInInspector] public bool isInVehicle = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isInVehicle) return; // disable player movement when in vehicle

        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0f) velocity.y = -2f;

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
