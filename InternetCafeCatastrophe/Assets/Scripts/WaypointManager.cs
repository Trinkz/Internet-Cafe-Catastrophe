using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    // Array of all of the tables

    [SerializeField]
    public DeskAvailable[] waypoints;

    [SerializeField]
    public List <DeskAvailable> available = new List<DeskAvailable>();

    [SerializeField]
    public GameObject Death;
    [SerializeField]
    public GameObject Jail;

    public bool DeskOff = true;

    Tutorial tutorial;

    GameObject[] Customers;
    GameObject[] Hackers;
    GameObject[] LeetHackers;

    // array of all the available tables


    // Use this for initialization
    void Start ()
    {
        DeskOff = true;
        tutorial = GameObject.Find("Game Icon Controller").GetComponent<Tutorial>();
        //waypoints = FindObjectsOfType<DeskAvailable>();
        //Death = GameObject.FindGameObjectWithTag("GraveYard");
        FindAvailDesks();

	}
	
	// Update is called once per frame
	void Update ()
    {
       if(tutorial.P5 == true)
        {
            if (DeskOff == false)
            {
                PatronSearch();

                waypoints[0].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[1].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[2].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[3].GetComponent<DeskAvailable>().atDesk = false;

                waypoints[6].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[7].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[4].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[5].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[8].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[9].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[10].GetComponent<DeskAvailable>().atDesk = false;
                waypoints[11].GetComponent<DeskAvailable>().atDesk = false;

                waypoints[6].gameObject.SetActive(true);
                waypoints[7].gameObject.SetActive(true);
                waypoints[4].gameObject.SetActive(true);
                waypoints[5].gameObject.SetActive(true);
                waypoints[8].gameObject.SetActive(true);
                waypoints[9].gameObject.SetActive(true);
                waypoints[10].gameObject.SetActive(true);
                waypoints[11].gameObject.SetActive(true);
                DeskOff = true;
            }
            
        }
        else
        {
            return;
        }
	}

    //Call at customer start and on upgrade purchase********
   public void FindAvailDesks()
    {
        available.Clear();

        foreach (DeskAvailable desk in waypoints)
        {
            if (desk.atDesk == false)
            {
                available.Add(desk);
            }
        }
    }

    //Call when setting Destination on Customer *************
    public DeskAvailable GetDesk()
    {
        foreach(DeskAvailable desk in available)
        {
            if (desk.atDesk == false)
            {
                available.Remove(desk);
                desk.atDesk = true;
                return desk;
            }
            else
            {
                return null;
            }
        }
            return null;        
    }

    public void UpgradeDesk1()
    {
        waypoints[6].gameObject.SetActive(true);
        waypoints[7].gameObject.SetActive(true);

        waypoints[6].GetComponent<DeskAvailable>().atDesk = false;
        waypoints[7].GetComponent<DeskAvailable>().atDesk = false;


    }
    public void UpgradeDesk2()
    {
        waypoints[4].gameObject.SetActive(true);
        waypoints[5].gameObject.SetActive(true);

        waypoints[4].GetComponent<DeskAvailable>().atDesk = false;
        waypoints[5].GetComponent<DeskAvailable>().atDesk = false;

    }

    public void UpgradeDesk3()
    {
        waypoints[8].gameObject.SetActive(true);
        waypoints[9].gameObject.SetActive(true);

        waypoints[8].GetComponent<DeskAvailable>().atDesk = false;
        waypoints[9].GetComponent<DeskAvailable>().atDesk = false;
        
    }

    public void UpgradeDesk4()
    {
        waypoints[10].gameObject.SetActive(true);
        waypoints[11].gameObject.SetActive(true);

        waypoints[10].GetComponent<DeskAvailable>().atDesk = false;
        waypoints[11].GetComponent<DeskAvailable>().atDesk = false;
       
    }

   public void phaseDesks()
    {
       

        if(tutorial.P1 == false)
        {
            PatronSearch();

            waypoints[0].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[1].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[2].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[3].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[6].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[7].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[4].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[5].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[8].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[9].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[10].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[11].GetComponent<DeskAvailable>().atDesk = true;

            waypoints[6].gameObject.SetActive(false);
            waypoints[7].gameObject.SetActive(false);
            waypoints[4].gameObject.SetActive(false);
            waypoints[5].gameObject.SetActive(false);
            waypoints[8].gameObject.SetActive(false);
            waypoints[9].gameObject.SetActive(false);
            waypoints[10].gameObject.SetActive(false);
            waypoints[11].gameObject.SetActive(false);
        }
        if (tutorial.P1 == true && tutorial.P2 == false)
        {
            PatronSearch();

            waypoints[0].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[1].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[2].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[3].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[6].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[7].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[4].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[5].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[8].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[9].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[10].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[11].GetComponent<DeskAvailable>().atDesk = true;


            waypoints[6].gameObject.SetActive(true);
            waypoints[7].gameObject.SetActive(true);
            waypoints[4].gameObject.SetActive(false);
            waypoints[5].gameObject.SetActive(false);
            waypoints[8].gameObject.SetActive(false);
            waypoints[9].gameObject.SetActive(false);
            waypoints[10].gameObject.SetActive(false);
            waypoints[11].gameObject.SetActive(false);
        }
        if (tutorial.P2 == true && tutorial.P3 == false)
        {
            PatronSearch();

            waypoints[0].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[1].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[2].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[3].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[6].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[7].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[4].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[5].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[8].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[9].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[10].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[11].GetComponent<DeskAvailable>().atDesk = true;


            waypoints[6].gameObject.SetActive(true);
            waypoints[7].gameObject.SetActive(true);
            waypoints[4].gameObject.SetActive(true);
            waypoints[5].gameObject.SetActive(true);
            waypoints[8].gameObject.SetActive(false);
            waypoints[9].gameObject.SetActive(false);
            waypoints[10].gameObject.SetActive(false);
            waypoints[11].gameObject.SetActive(false);
        }
        if (tutorial.P3 == true && tutorial.P4 == false)
        {
            PatronSearch();

            waypoints[0].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[1].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[2].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[3].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[6].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[7].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[4].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[5].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[8].GetComponent<DeskAvailable>().atDesk = false;
            waypoints[9].GetComponent<DeskAvailable>().atDesk = false;

            waypoints[10].GetComponent<DeskAvailable>().atDesk = true;
            waypoints[11].GetComponent<DeskAvailable>().atDesk = true;

            waypoints[6].gameObject.SetActive(true);
            waypoints[7].gameObject.SetActive(true);
            waypoints[4].gameObject.SetActive(true);
            waypoints[5].gameObject.SetActive(true);
            waypoints[8].gameObject.SetActive(true);
            waypoints[9].gameObject.SetActive(true);
            waypoints[10].gameObject.SetActive(false);
            waypoints[11].gameObject.SetActive(false); 
        }
    }

   public void PatronSearch()
    {
        Customers = GameObject.FindGameObjectsWithTag("Customer");
        Hackers = GameObject.FindGameObjectsWithTag("Hacker");
        LeetHackers = GameObject.FindGameObjectsWithTag("1337Hacker");

        for (int i = 0; i <Customers.Length; i++)
        {
            Destroy(Customers[i]);
        }
        for (int i = 0; i < Hackers.Length; i++)
        {
            Destroy(Hackers[i]);
        }
        for (int i = 0; i < LeetHackers.Length; i++)
        {
            Destroy(LeetHackers[i]);
        }

    }

}


// Change bool on upgrade purchase to false
//Reference WaypointManager with NavAgent script for available waypoints
