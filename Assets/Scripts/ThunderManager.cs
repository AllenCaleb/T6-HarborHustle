using System.Collections;
using UnityEngine;

public class ThunderManager : MonoBehaviour
{
    public CameraShake cameraShake; // Reference to the camera shake script
    public Light sceneLight; // Reference to the Directional Light (for the lightning flash)

    void Start()
    {
        // Optionally trigger the thunder and shake at a random time interval
        StartCoroutine(ThunderEvent());
    }

    IEnumerator ThunderEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 15f)); // Thunder happens every 5-15 seconds

            // Trigger camera shake (simulating thunder shake)
            cameraShake.TriggerShake();

            // Trigger the lightning flash (simulating the lightning flash)
            StartCoroutine(FlashScreen());
        }
    }

    IEnumerator FlashScreen()
    {
        if (sceneLight != null)
        {
            // Bright flash of lightning
            sceneLight.intensity = 5f;  // You can adjust this value for a more dramatic effect
            sceneLight.color = Color.white;  // You can optionally change the color to white for a lightning effect

            // Wait for the flash to last (0.1 seconds or as desired)
            yield return new WaitForSeconds(0.1f);

            // Return to normal light intensity
            sceneLight.intensity = 1f; // Set it back to normal lighting intensity
        }
    }
}
