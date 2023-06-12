using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape3_control : MonoBehaviour
{
    [SerializeField] private Outline outline;
    [SerializeField] private float rotationSpeed; 
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
   // private Outline outline;

    private float currentAngle = 0f;

    void Start()
    {
       // outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            RotateObject(-1);
        }

        else if (Input.GetKey(KeyCode.W))
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













/* [SerializeField] private float rotationSpeed;
 [SerializeField] private float minAngle;
 [SerializeField] private float maxAngle;
 private float currentRotation = 0f;
 private float originalYPosition;

 void Start()
 {
     originalYPosition = transform.position.y;
 }

 void Update()
 {
    *//* if (Input.GetKey(KeyCode.W))
     {
         currentRotation += rotationSpeed * Time.deltaTime;
         currentRotation = Mathf.Clamp(currentRotation, minAngle, maxAngle);
         Quaternion rotation = Quaternion.Euler(transform.position.x, transform.position.y, currentRotation);
          transform.rotation = rotation;


         *//*// Устанавливаем исходную позицию по оси Y
         Vector3 newPosition = transform.position;
         newPosition.y = originalYPosition;
         transform.position = newPosition;*//*
     }
     else if (Input.GetKey(KeyCode.S))
     {
         currentRotation -= rotationSpeed * Time.deltaTime;
         currentRotation = Mathf.Clamp(currentRotation, minAngle, maxAngle);
         Quaternion rotation = Quaternion.Euler(transform.position.x, transform.position.y, currentRotation);

         transform.rotation = rotation;
         Vector3 newPosition = transform.position;
         newPosition.y = originalYPosition;
         transform.position = newPosition;
     }*/



