using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shape2_control : MonoBehaviour
{
    [SerializeField] private float speed;
    private Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            outline.enabled = true;
            //float objectY = transform.rotation.y - speed * Time.deltaTime;
            Vector3 rottarget = new Vector3(0, -speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0,objectY,0);
            transform.Rotate(rottarget);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            outline.enabled = true;
            Vector3 rottarget = new Vector3(0, speed * Time.deltaTime, 0);
            transform.Rotate(rottarget);
        }

        else
        {
            if(outline.enabled)
                outline.enabled = false;
        }
    }
}
