using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFrontDoors : MonoBehaviour {

    // Use this for initialization

    public Vector3 Rpos;
    public Vector3 Lpos;

    bool doorTriggered;
    void Start () {
        Rpos = GameObject.Find("Right door").GetComponent<Transform>().position;
        Lpos = GameObject.Find("Left door").GetComponent<Transform>().position;
        doorTriggered = false;
    }
	
	// Update is called once per frame
	void Update () {
        TriggerDoor();
	}


    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.tag == "Customer" || gameObject.tag == "Hacker" || gameObject.tag == "1337Hacker" || gameObject.tag == "Janitor" || gameObject.tag == "Inspector")
        {
            
            GameObject.Find("Left door").GetComponent<Transform>().position += Vector3.forward * Time.deltaTime * 45;
            GameObject.Find("Right door").GetComponent<Transform>().position += Vector3.back * Time.deltaTime * 45;
            doorTriggered = true;
        }
    }

    void OnTriggerStay(Collider gameObject)
    {
        if (gameObject.tag == "Customer" || gameObject.tag == "Hacker" || gameObject.tag == "1337Hacker" || gameObject.tag == "Janitor" || gameObject.tag == "Inspector")
        {

            
            doorTriggered = true;
        }
    }

    void OnTriggerExit(Collider gameObject)
    {
        if (gameObject.tag == "Customer"  || gameObject.tag == "Hacker" || gameObject.tag == "1337Hacker" || gameObject.tag == "Janitor" || gameObject.tag == "Inspector")
        {
            
            doorTriggered = false;
        }

        if (gameObject.tag == "Customer" && doorTriggered == false || gameObject.tag == "Hacker" && doorTriggered == false || gameObject.tag == "1337Hacker" && doorTriggered == false || gameObject.tag == "Janitor" && doorTriggered == false || gameObject.tag == "Inspector" && doorTriggered == false)
        {
            
            doorTriggered = false;
        }

    }

    void TriggerDoor()
    {
        if (doorTriggered != true)
        {

            doorTriggered = false;
        }

        if (doorTriggered == true)
        {

            GameObject.Find("Left door").GetComponent<Transform>().position += Vector3.forward * Time.deltaTime * 3;
            GameObject.Find("Right door").GetComponent<Transform>().position += Vector3.back * Time.deltaTime * 3;
        }

        if (doorTriggered == false)
        {

            GameObject.Find("Right door").GetComponent<Transform>().position = Rpos;
            GameObject.Find("Left door").GetComponent<Transform>().position = Lpos;
        }


    }

}
