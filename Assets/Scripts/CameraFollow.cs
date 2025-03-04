using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // The offset distance between the player and the camera
    public float smoothSpeed = 0.125f; // Speed at which the camera moves to catch up

    void LateUpdate()
    {
        // Check if player is assigned to prevent errors
        if (player != null)
        {
            // Get the desired position (keep the z position constant if it's a 2D game)
            Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, transform.position.z) + offset;

            // Smoothly interpolate between the current camera position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
