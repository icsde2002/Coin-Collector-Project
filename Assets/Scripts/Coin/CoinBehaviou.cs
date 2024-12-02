using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavious : MonoBehaviour
{
    // Rotation speed
    public float rotationSpeed = 100f;

    // Amplitude of the up and down movement
    public float amplitude = 0.005f;

    // Frequency of the up and down movement
    public float frequency = 2f;

    void Update()
    {
        // Rotate the object
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Calculate the new vertical offset using a sine wave
        float verticalOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        // Update position relative to current world position
        Vector3 newPosition = transform.position;
        newPosition.y += verticalOffset;
        transform.position = newPosition;
    }
}