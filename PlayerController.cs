// Placeholder script
using UnityEngine;

public class PlayerController : MonoBehaviour {
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}