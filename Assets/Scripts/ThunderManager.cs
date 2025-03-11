using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderManager : MonoBehaviour
{
    public CameraShake cameraShake; // Reference to the camera shake script
    public Light sceneLight; // Optional for flashing

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
            cameraShake.TriggerShake(); // Call the shake effect
            // You can also trigger a thunder sound or lightning visual effect here
        }
    }

    IEnumerator FlashScreen()
    {
        if (sceneLight != null)
        {
            sceneLight.intensity = 5; // Bright flash
            yield return new WaitForSeconds(0.1f); // Flash duration
            sceneLight.intensity = 1; // Normal lighting
        }
    }
}