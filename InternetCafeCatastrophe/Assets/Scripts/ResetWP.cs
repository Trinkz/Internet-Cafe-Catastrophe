using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWP : MonoBehaviour
{

    GameObject WPM;
    WaypointManager WPManager;
    bool triggered = false;
    Collider other;
    [SerializeField]
    GameObject Desk;
    NavAgent nav;

    // Use this for initialization
    void Start ()
    {
        
        WPM = GameObject.Find("WPManager");
        WPManager = WPM.GetComponent<WaypointManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!other && triggered == true)
        {
        //    Debug.Log("collider missing");

            if (Desk.gameObject.name == "Desk1")
            {
           //     Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[0].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk2")
            {
           //     Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[1].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk3")
            {
              //  Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[2].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk4")
            {
              //  Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[3].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk5")
            {
             //   Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[4].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk6")
            {
            //    Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[5].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk7")
            {
              //  Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[6].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk8")
            {
            //    Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[7].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk9")
            {
            //    Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[8].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk10")
            {
            //    Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[9].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk11")
            {
           //     Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[10].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
            if (Desk.gameObject.name == "Desk12")
            {
             //   Debug.Log("Desk is being set back to empty");
                WPManager.waypoints[11].GetComponent<DeskAvailable>().atDesk = false;
                triggered = false;
            }
        }
        else
        {
            //Debug.Log("Shit still exists"); 
            return;
        }
	}


    void OnTriggerEnter(Collider other)
    {
        nav = other.GetComponent<NavAgent>();

        if (other.tag == "Customer")
        {
            nav.reset = true;
            triggered = true;
            this.other = other;
        }
        else if (other.tag == "Hacker")
        {
            nav.reset = true;
            triggered = true;
            this.other = other;
        }
        else if (other.tag == "1337Hacker")
        {
            nav.reset = true;
            triggered = true;
            this.other = other;
        }
        else
        {
          //  Debug.Log("other is not viable");
        }
        
    }
}
