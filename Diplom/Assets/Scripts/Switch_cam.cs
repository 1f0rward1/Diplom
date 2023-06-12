using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_cam : MonoBehaviour
{
    private Camera TheCamera;
    public Camera SecondCam;
    void Start()
    {
        TheCamera = GetComponent<Camera>();
        TheCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TheCamera.enabled = !TheCamera.enabled;
            SecondCam.enabled = !SecondCam.enabled;
        }
    }
}
