using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.forward; // Axis to rotate around (e.g., Vector3.up for 'spinning' on Y-axis)
    public float rotationSpeed = 45f; // Degrees per second

    private void Start()
    {
        transform.eulerAngles = new Vector3(-90f, 0f, 0f); 
    }
    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
