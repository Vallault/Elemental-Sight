using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    void Update()
    {
        RotateTowardsMousePosition();
    }
    void RotateTowardsMousePosition()
    {
        // Get the mouse position in screen space
        Vector3 mousePositionScreen = Input.mousePosition;

        // Set a constant distance from the camera to the object in world space
        mousePositionScreen.z = 10f;

        // Convert the mouse position to world space
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        // Calculate the direction from the object to the mouse
        Vector3 direction = mousePositionWorld - transform.position;

        // Calculate the angle from the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle -= 90f;

        // Rotate the object to face the mouse
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
