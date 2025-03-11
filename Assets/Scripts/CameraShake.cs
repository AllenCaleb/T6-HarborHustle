using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.1f;
    private float shakeTime = 0.5f;

    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.position = originalPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalPos;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = shakeTime;
    }
}

