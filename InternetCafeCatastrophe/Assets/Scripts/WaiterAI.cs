using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaiterAI : MonoBehaviour
{
    // Array of all of the tables

    [SerializeField]
    public NavAgent[] waypoints;

    [SerializeField]
    public List<NavAgent> available = new List<NavAgent>();



    // array of all the available tables


    // Use this for initialization
    void Start()
    {
        // FindAvailDesks();
        //available.Clear();


    }

    // Update is called once per frame
    void Update()
    {
        FindAvailDesks();


    }

    //Call at customer start and on upgrade purchase********
    public void FindAvailDesks()
    {
        available.Clear();

        //waypoints = GameObject.FindObjectsOfType<NavAgent>();

        if (waypoints.Length != 0)
        {
            
            //Debug.Log("available.count " + available.Count);

            foreach (NavAgent desk in waypoints)
            {
             //   Debug.Log("inside foreach trigger navagent in waypoint");
                if (desk.order == true || desk.order != false)
                {
                    

                 //   Debug.Log("desk.order = true" + desk.order);
                    available.Add(desk);
                }
                else
                {
                  //  Debug.Log("I am not running");
                    return;
                }
            }
        }
        else if (waypoints.Length <= 13)
        {
            FindWaypointsForever();
        }
    }

    //Call when setting Destination on Customer *************
    public NavAgent GetDesk()
    {
        foreach (NavAgent desk in available)
        {
            if (desk.order == true)
            {
                available.Remove(desk);

                return desk;
            }
            else
            {
                return null;
            }
        }
        return null;
    }

  public  void FindWaypointsForever()
    {
        waypoints = GameObject.FindObjectsOfType<NavAgent>();
    }
}

