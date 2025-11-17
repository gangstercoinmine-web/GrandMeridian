using UnityEngine;

/// <summary>
/// Simple top-down player movement (example). Attach to a GameObject.
/// Uses default Input axes ("Horizontal" and "Vertical").
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveY) * moveSpeed * Time.deltaTime;
        transform.position += move;
    }
}
