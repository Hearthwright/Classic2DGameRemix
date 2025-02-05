using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Determines the move speed of the player (Default = 5f)
    public float horizontalBoundary = 8f; // Determines the maximum distance the player can move along the X axis (Defualt = 8f)
    public float verticalMax = -3f; // Determines the maximum position along the Y-Axis the player is allowed to be (Default -3f)

    private int currentRotation = 0; // Tracks the current rotation in multiples of 90 degrees (0 = Up, 1 = Right, 2 = Down, 3 = Left)

    [Header("Debug Settings")]
    public bool unclampVerticalPosition; // Allows the player to move as high up as they want. Used to make testing taking damage faster (Default = False)

    // Update is called once per frame
    void Update()
    {
        // Get input from the player (WASD or arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float verticalInput = Input.GetAxis("Vertical");   // W/S or Up/Down arrow

        // If player presses Q, Rotate left by 90 degrees (counter-clockwise)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Rotate left by 90 degrees (counterclockwise)
            if (currentRotation != 1) // Ensure that turning would not turn the ship upside down
            {
                // Update currentRotation
                currentRotation = (currentRotation + 1) % 4; // +1 ensures that it's a left turn (90 degrees counter-clockwise)
                // Apply the rotation
                ApplyRotation();
            }
        }
        // If player presses E, Rotate right by 90 degrees (clockwise)
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (currentRotation != 3) // Ensure that turning would not turn the ship upside down
            {
                // Update currentRotation
                currentRotation = (currentRotation + 3) % 4; // +3 ensures that it's a right turn (90 degrees clockwise)
                // Apply the rotation
                ApplyRotation();
            }
        }


        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Apply movement while clamping to the allowed range
        Vector3 newPosition = transform.position + movement;

        // Clamp the position to the horizontal move limits
        newPosition.x = Mathf.Clamp(newPosition.x, -horizontalBoundary, horizontalBoundary);

        // If player has not unclamped their vertical position...
        if(!unclampVerticalPosition)
        {
            // Clamp the Y position to the vertical move limits
            newPosition.y = Mathf.Clamp(newPosition.y, -5f, verticalMax);
        }

        // Update the position of the ship
        transform.position = newPosition;
    }


    // Apply the rotation based on currentRotation
    private void ApplyRotation()
    {
        // Convert currentRotation to an angle in degrees
        float zRotation = currentRotation * 90f; 
        transform.rotation = Quaternion.Euler(0, 0, zRotation); // Apply the rotation
    }
}
