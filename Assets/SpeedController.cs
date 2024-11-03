using UnityEngine;
using TMPro;

public class SpeedController : MonoBehaviour
{
    public VR_Car_Controller_1 carController; // Reference to the car controller
    public TextMeshPro speedTextMesh; // Reference to the TextMeshPro component attached to the car

    private Rigidbody carRigidbody;
    private const float maxSpeedKmph = 120f; // Max speed in km/h
    private const float maxSpeedMps = maxSpeedKmph / 3.6f; // Convert km/h to m/s

    private void Start()
    {
        // Get the Rigidbody from the car to measure speed
        carRigidbody = carController.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calculate the car's current speed in km/h
        float speedKmph = carRigidbody.velocity.magnitude * 3.6f;

        // Display the speed in km/h on the TextMeshPro
        speedTextMesh.text = "Speed: " + Mathf.RoundToInt(speedKmph) + " km/h";

        // Cap the speed at maxSpeedMps (m/s)
        if (carRigidbody.velocity.magnitude > maxSpeedMps)
        {
            carRigidbody.velocity = carRigidbody.velocity.normalized * maxSpeedMps;
        }
    }
}
