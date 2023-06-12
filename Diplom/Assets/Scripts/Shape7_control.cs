using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape7_control : MonoBehaviour
{
    [SerializeField] private Outline outline;
    [SerializeField] private float rotationSpeed;
    private float currentAngle = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RotateObject(-1);
        }

        else if (Input.GetKey(KeyCode.Mouse1))
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
        float angleDifference = newAngle - currentAngle;
        transform.Rotate(Vector3.right, angleDifference);
        currentAngle = newAngle;
    }
}
