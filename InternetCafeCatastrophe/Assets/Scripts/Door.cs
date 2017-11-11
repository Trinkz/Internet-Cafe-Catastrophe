/*Name:Jose Guzman
 * Date: 50/31/2017
 * Credit: Unity3D how to make a Door [C#] (https://www.youtube.com/watch?v=bb1bxPHe-J8)
 * How to make Doors in Unity (https://www.youtube.com/watch?v=nfV45mpskRI) <--Use dthis during the fixing of the doors.
 * Purpose:Make a door that slides open when an object enters its trigger volume, and have it close when an object exits the trigger volume.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Customer")
        {
            anim.SetBool("DoorOpen",true );
            anim.SetBool("DoorClosed", false);
        }

        if (other.gameObject.tag == "Hacker")
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClosed", false);
        }

        if (other.gameObject.tag == "1337Hacker")
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClosed", false);
        }

        if (other.gameObject.tag == "FBI")
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClosed", false);
        }

        if (other.gameObject.tag == "Guard")
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClosed", false);
        }

        if (other.gameObject.tag == "Inspector")
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClosed", false);
        }


    }

    void OnTriggerExit (Collider other)
    {
        anim.SetBool("DoorOpen", false);
        anim.SetBool("DoorClosed", true);

    }

}
