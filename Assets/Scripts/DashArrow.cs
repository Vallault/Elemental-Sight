using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashArrow : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RotateSpriteTowardsMouse();
    }

    void RotateSpriteTowardsMouse()
    {
        // Get the mouse position in screen space
        Vector3 mousePositionScreen = Input.mousePosition;

        // Set a constant distance from the camera to the object in world space
        mousePositionScreen.z = 10f;

        // Convert the mouse position to world space
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        // Calculate the direction from the sprite to the mouse
        Vector3 direction = mousePositionWorld - transform.position;

        // Calculate the angle from the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Adjust the angle by adding or subtracting 90 degrees
        angle -= 90f;

        // Rotate the sprite to face the mouse
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

