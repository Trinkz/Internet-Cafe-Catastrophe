/* Name: Jose Guzman
 * Date: 06/08/2017
 * Credit: Select and move 1 object, problem = moving multiple. http://answers.unity3d.com/questions/826501/select-and-move-1-object-problem-moving-multiple.html 
 * Credit: handcuffing hackers and 1337 hackers. https://freesound.org/people/Nomadyag/sounds/193058/
 * Purpose: Be able to select an Guard and move it to a selected Hacker. ONLY the selected Guard should move to the Hacker selected.
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GuardMoveToHacker : MonoBehaviour
{
    [SerializeField]
    AudioClip cuffs;

    public bool selected = false;
    public bool Move = false;

    private Vector3 MoveTo;

    private NavMeshAgent guard;
    public Renderer rend;
    public SpriteRenderer selectColor;

    public GameObject hacker;

    public IconController icon;

    public GameObject iconThatWorks;

    GameObject WPM;
    WaypointManager WPManager;
    NavAgent customer;
    public bool Guiding;

    HackingTimer hack;

    foodRequests food;


    bool sent;

    // Use this for initialization
    void Start()
    {
 
        iconThatWorks = GameObject.Find("Game Icon Controller");
        guard = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
        selectColor = GetComponentInChildren<SpriteRenderer>();
        icon = iconThatWorks.GetComponent<IconController>();
        WPM = GameObject.Find("WPManager");
        WPManager = WPM.GetComponent<WaypointManager>();
        sent = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sent == false)
        {

            MoveToHacker();
        }
    }

    void MoveToHacker()
    {
        if (selected && Move)
        {
            //Vector3 newTravelPosition = hacker.transform.position;
            //guard.SetDestination(newTravelPosition);

            Move = false;
            sent = true;

            guard.SetDestination(MoveTo);
        }

        /*if (guard.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Move = false;

            if (icon.guard1 == true)
            {
                icon.guard1 = false;
                GameController.guardS1 = "empty";
            }
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        hack = other.GetComponent<HackingTimer>();
        food = other.GetComponent<foodRequests>();

        if (other.tag == "Hacker" && other.GetComponent<NavAgent>().isSelected == true)

        {
         //   Debug.Log(" On Trigger Hacker");
            food.messageCanvas.enabled = false;
            Guiding = true;

            

            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == false)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().guardOnHacker = true;
            }
            if(GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P3lv1 == false && GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P2lv1 == true)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().guardOnHacker = true;
            }
            if (GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P5lv2 == false && GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P4lv2 == true)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().guardOnHacker = true;
            }
            if (GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P5lv3 == false && GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P4lv3 == true)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().guardOnHacker = true;
            }
            if (GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P5lv4 == false && GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().P4lv4 == true)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().guardOnHacker = true;
            }

            Move = false;

            hack.hacking = false;
            customer = other.GetComponent<NavAgent>();
            customer.JailWP();
            GetComponent<AudioSource>().PlayOneShot(cuffs);

            Vector3 newTravelPosition = WPManager.Jail.transform.position;
            guard.SetDestination(newTravelPosition);

            if (icon.guard1 == true)
            {
                icon.IGuard--;
                icon.guard1 = false;
                GameController.guardS1 = "empty";
                icon.guardButton.GetComponentInChildren<Text>().text = "Guard " +  icon.IGuard + "/3 - " + "250";

            }
            else if (icon.guard2 == true)
            {
                icon.IGuard--;
                icon.guard2 = false;
                GameController.guardS2 = "empty";
                icon.guardButton.GetComponentInChildren<Text>().text = "Guard " + icon.IGuard + "/3 - " + "250";

            }
            else if (icon.guard3 == true)
            {
                icon.IGuard--;
                icon.guard3 = false;
                GameController.guardS3 = "empty";
                icon.guardButton.GetComponentInChildren<Text>().text = "Guard " + icon.IGuard + "/3 - " + "250";

            }
        }
    }

    void Select(int x)
    {
        selected = true;
       // rend.material.color = Color.green;
        selectColor.color = Color.green;

    }

    void Deselect(int x)
    {
        selected = false;
       // rend.material.color = Color.white;
        selectColor.color = Color.white;

    }

    void Destination(Vector3 d)
    {
        MoveTo = d;
        Move = true;
    }

}
