using UnityEngine;

public class CameraController : MonoBehaviour
{
     public float dragSpeed = 1;
    private Vector3 dragOrigin;
 
 
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(2)) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint((Input.mousePosition - dragOrigin) /10);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
 
        transform.Translate(move, Space.World);  
    }
 
}