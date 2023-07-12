using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f; // Speed of camera zooming
    public float minFOV = 10f; // Minimum field of view (zoomed out)
    public float maxFOV = 60f; // Maximum field of view (zoomed in)

    void Update()
{
    float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
    float newFOV = Camera.main.fieldOfView - (scrollWheelInput * zoomSpeed);

    // Clamp the new field of view to the specified minimum and maximum values
    newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);

    // Set the camera's field of view to the new value
    Camera.main.fieldOfView = newFOV;
}
}