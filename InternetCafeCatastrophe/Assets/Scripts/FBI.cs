/*Name: Jose Guzman
Date: 5/30/2017
Credit: Game Development - Experiment 4.1 - Unity's Navigation System word document
        The NavMesh Agent - Unity Official Tutorials (https://www.youtube.com/watch?v=mP7ulMu5UkU)
        How do you detect a mouse button click on a Game Object? C# (http://answers.unity3d.com/questions/1065971/how-do-you-detect-a-mouse-button-click-on-a-game-o.html)
        Scripting API - NavMeshAgent (https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html)
        Destroy all object with tag "enemy"? (http://answers.unity3d.com/questions/314503/destroy-all-objects-with-tag-enemy.html)
        sound for handcuffing hackers and 1337 hackers. https://freesound.org/people/Nomadyag/sounds/193058/

Purpose: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FBI : MonoBehaviour
{
    private bool selected = false;
    private bool Move = false;
    public bool FbiOnHacker = false;
    public bool FbiOn1337Hacker = false;

    private Vector3 MoveTo;

    public Renderer rend;

    public SpriteRenderer fbiSprite;


    public GameObject elitehacker;
    
    [SerializeField]
    AudioClip cuffs;
    // NavMeshAgent variable.
    NavMeshAgent fbi;

    // Hackers in area.
    GameObject[] hackers;
    // The Hacker target.
   // public Transform hacker;

    // The 1337 Hacker target.
    //public Transform leetHacker;

    GameObject WPM;
    WaypointManager WPManager;
    NavAgent Hacker;
    NavAgent eliteHacker;
    public GameObject iconThatWorks;
    public IconController icon;
    bool sent;

    HackingTimer hTime;

    foodRequests food;

    // Use this for initialization
    void Start ()
    {
        
        iconThatWorks = GameObject.Find("Game Icon Controller");
        icon = iconThatWorks.GetComponent<IconController>();
        fbi = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
        fbiSprite = GetComponentInChildren<SpriteRenderer>();
        WPM = GameObject.Find("WPManager");
        WPManager = WPM.GetComponent<WaypointManager>();
        sent = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (sent == false)
        {

            MoveToHacker();
        }
	}

    public void MoveToHacker()
    {
        if(selected && Move)
        {
            //Vector3 newTravelPosition = hacker.transform.position;
            //guard.SetDestination(newTravelPosition);

            Move = false;
            sent = true;

            fbi.SetDestination(MoveTo);
        }
     }

    void OnTriggerEnter(Collider other)
    {

        food = other.GetComponent<foodRequests>();

        if (other.CompareTag("Hacker") && other.GetComponent<NavAgent>().isSelected == true)
        {
            hackers = GameObject.FindGameObjectsWithTag("Hacker");
            Move = false;
            FbiOnHacker = true;


            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().fbiOnHacker = true;

            for (int i = 0; i < hackers.Length; i++)
            {
                hTime = hackers[i].GetComponent<HackingTimer>();

                Hacker = hackers[i].GetComponent<NavAgent>();
                if(Hacker.order == true)
                {
                    food.messageCanvas.enabled = false;
                    hTime.hacking = false;
                    Hacker.JailWP();
                }
                
            }
            
            Vector3 newTravelPosition = WPManager.Jail.transform.position;
            fbi.SetDestination(newTravelPosition);

            if (icon.fbi == true)
            {
                icon.IFBI--;
                icon.fbi = false;
                GameController.fbi = "empty";
                icon.fbiButton.GetComponentInChildren<Text>().text = "FBI " + icon.IFBI + "/1 - " + "1000";

            }

        }

        else if (other.CompareTag("1337Hacker") && other.GetComponent<NavAgent>().isSelected == true)
        {
            food.messageCanvas.enabled = false;
            FbiOn1337Hacker = true;
            hTime = other.GetComponent<HackingTimer>();
            hTime.hacking = false;
            eliteHacker = other.GetComponent<NavAgent>();
            eliteHacker.JailWP();
            GetComponent<AudioSource>().PlayOneShot(cuffs);
            Vector3 newTravelPosition = WPManager.Jail.transform.position;
            fbi.SetDestination(newTravelPosition);
            Move = false;

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().fbiOnElite = true;

            if (icon.fbi == true)
            {
                icon.IFBI--;
                icon.fbi = false;
                GameController.fbi = "empty";
                icon.fbiButton.GetComponentInChildren<Text>().text = "FBI " + icon.IFBI + "/1 - " + "1000";

            }
        }

    }
    void Select(int x)
    {
        selected = true;
        //rend.material.color = Color.green;
        fbiSprite.color = Color.green;

    }

    void Deselect(int x)
    {
        selected = false;
        //rend.material.color = Color.white;
        fbiSprite.color = Color.white;

    }

    void Destination(Vector3 d)
    {
        MoveTo = d;
        Move = true;
    }
}
