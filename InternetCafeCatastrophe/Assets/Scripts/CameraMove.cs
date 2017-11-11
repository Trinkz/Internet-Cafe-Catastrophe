using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 5.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the D key is pressed...
        if (Input.GetKey(KeyCode.D))
        {
            // Make camera move in the right direction.
            //Debug.Log("Move to the Right!");
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        // If the A key is pressed...
        if (Input.GetKey(KeyCode.A))
        {
            // Make camera move in the left direction.
            //Debug.Log("Move to the Left!");
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

    }
}
