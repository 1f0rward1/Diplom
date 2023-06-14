using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape6_control : MonoBehaviour
{
    [SerializeField] private Outline outline;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minAngle; 
    [SerializeField] private float maxAngle; 

    private float currentAngle = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            RotateObject(-1);
        }

        else if (Input.GetKey(KeyCode.V))
        {
            RotateObject(1); 
        }
        else
        {
            if (outline.enabled)
                outline.enabled = false;
        }
    }

    private void RotateObject(int direction)
    {
        outline.enabled = true;
        float newAngle = currentAngle + direction * rotationSpeed * Time.deltaTime;
        newAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);
        float angleDifference = newAngle - currentAngle;
        transform.Rotate(Vector3.forward, angleDifference);
        currentAngle = newAngle;
    }
}
