using UnityEngine;

public class EnterExitVehicle : MonoBehaviour
{
    public Transform seatPoint; // where player will be positioned when inside
    public GameObject vehicleObject;
    public PlayerController player;
    public VehicleController vehicleController;

    bool inside = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inside)
            {
                TryEnter();
            }
            else
            {
                ExitVehicle();
            }
        }
    }

    void TryEnter()
    {
        if (player == null || vehicleObject == null) return;
        if (Vector3.Distance(player.transform.position, vehicleObject.transform.position) > 3f) return;

        inside = true;
        player.isInVehicle = true;
        player.gameObject.SetActive(false); // hide player mesh
        if (seatPoint != null) player.transform.position = seatPoint.position;
        if (vehicleController != null) vehicleController.enabled = true;
        // Optionally parent camera to vehicle or switch camera modes
    }

    void ExitVehicle()
    {
        inside = false;
        player.isInVehicle = false;
        player.gameObject.SetActive(true);
        // place player next to vehicle
        player.transform.position = vehicleObject.transform.position + vehicleObject.transform.right * 2f + Vector3.up * 0.5f;
        if (vehicleController != null) vehicleController.enabled = false;
    }
}
