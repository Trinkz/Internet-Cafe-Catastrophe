using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavAgent : MonoBehaviour
{
    public bool avail = false;
    public bool reset = false;

    public foodRequests food;
    public NavMeshAgent customer;

    GameObject WPM;
    WaypointManager WPManager;

    HackingTimer hack;

    int MaxHits = 2;
    int CurHits = 0;

    public bool order;
    float timer;
    public SpoilTimer foodSpoil;

    string SceneName;
    Scene currentScene;

    GameObject[] Customers;
    GameObject[] Hackers;
    GameObject[] Elites;

   public bool DishStoppers = false;
    public bool isSelected = false;
    public bool foodDelete = false;


    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;

        order = false;
        hack = GetComponent<HackingTimer>();
        WPM = GameObject.Find("WPManager");
        WPManager = WPM.GetComponent<WaypointManager>();
        customer = GetComponent<NavMeshAgent>();

        WPManager.FindAvailDesks();
        DeskSelect();

        food = GetComponent<foodRequests>();

        DishStoppers = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (customer.tag == "Customer" || customer.tag == "Hacker" || customer.tag == "1337Hacker")
        {
            timer += Time.deltaTime;
            if (GameObject.Find("FireHolder") != null)
            {


                if (GameObject.Find("FireHolder").GetComponent<FireScript>().Fire.activeInHierarchy == true)
                {
                    Customers = GameObject.FindGameObjectsWithTag("Customer");
                    Hackers = GameObject.FindGameObjectsWithTag("Hacker");
                    Elites = GameObject.FindGameObjectsWithTag("1337Hacker");


                    foreach (GameObject Customers in Customers)
                    {
                            Customers.GetComponent<foodRequests>().messageCanvas.enabled = false;
                            ReturnWP();

                    }

                    foreach (GameObject Customers in Hackers)
                    {

                            Customers.GetComponent<HackingTimer>().hacking = false;
                            Customers.GetComponent<foodRequests>().messageCanvas.enabled = false;
                            ReturnWP();
                    }

                    foreach (GameObject Customers in Elites)
                    {

                            Customers.GetComponent<HackingTimer>().hacking = false;
                            Customers.GetComponent<foodRequests>().messageCanvas.enabled = false;
                            ReturnWP();
                    }

                }
                if (timer >= 15 && reset == false)
                {
                    ReturnWP();
                }
            }
        }

    }

    void DeskSelect()
    {
        if (WPManager.available.Count >= 1)
        {
            if (WPManager.available[0])
            {

                Vector3 newTravelPosistion = WPManager.GetDesk().transform.position;
                customer.SetDestination(newTravelPosistion);

            }
            else if (WPManager.available[1])
            {
                WPManager.GetDesk();
                Vector3 newTravelPosistion = WPManager.GetDesk().transform.position;
                customer.SetDestination(newTravelPosistion);

            }
            else if (WPManager.available[2])
            {
                WPManager.GetDesk();
                Vector3 newTravelPosistion = WPManager.GetDesk().transform.position;
                customer.SetDestination(newTravelPosistion);

            }
            else if (WPManager.available[3])
            {
                Vector3 newTravelPosistion = WPManager.GetDesk().transform.position;
                customer.SetDestination(newTravelPosistion);
            }
        }
        else
        {
            if (WPManager.Death != null)
            {
                Vector3 newTravelPosition = WPManager.Death.transform.position;
                customer.SetDestination(newTravelPosition);
            }
            else
            {
             //   Debug.Log("WPManager.Death does not exist");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foodSpoil = other.GetComponent<SpoilTimer>();

        if (other.tag == "ResetWP")
        {
            order = true;
            gameObject.transform.rotation = Quaternion.identity;
        }
        else if (customer.tag == "Customer" && other.tag == food.foodRequest)
        {
            DishStoppers = true;
        //    Debug.Log("Run Return WP");
            hack.triggered = false;
            ReturnWP();
            food.messageCanvas.enabled = false;
            foodDelete = true;
        }
        else if (other.name == "bagel(Clone)" && customer.tag == "Customer" || other.name == "burger(Clone)" && customer.tag == "Customer" || other.name == "juice(Clone)" && customer.tag == "Customer" || other.name == "coffee(Clone)" && customer.tag == "Customer" || other.name == "soda(Clone)" && customer.tag == "Customer" || other.name == "soup(Clone)" && customer.tag == "Customer" || other.name == "salad(Clone)" && customer.tag == "Customer" || other.name == "smoothie(Clone)" && customer.tag == "Customer")
        {
            if (foodSpoil.spoiled == true)
            {
//                Debug.Log("Run Return WP");
                hack.triggered = false;
                ReturnWP();
                food.messageCanvas.enabled = false;
                foodDelete = true;
            }
        }

        else if (customer.tag == "Hacker" && other.tag == food.foodRequest && CurHits <= MaxHits)
        {
            CurHits += 1;
            food.FoodRange();
            foodDelete = true;

            //  Debug.Log("you fed the hacker");

            if (CurHits >= MaxHits)
            {
              //  Debug.Log("Run Hacker WP");
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().HackerObj();
                hack.hacking = false;
                ReturnWP();
                food.messageCanvas.enabled = false;
                foodDelete = true;
            }
        }
        else if (customer.tag == "1337Hacker" && other.tag == food.foodRequest && CurHits <= 4)
        {
            CurHits += 1;
         //   Debug.Log("Fed the 1337");
            food.FoodRange();
            foodDelete = true;

            if (CurHits >= 4)
            {
             //   Debug.Log("Run Hack WP");

                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().EliteHackerObj();

                hack.hacking = false;
                ReturnWP();
                food.messageCanvas.enabled = false;
                foodDelete = true;
            }
        }
    }

    public void ReturnWP()
    {
      //  Debug.Log("calling return WP");
        Vector3 newTravelPosition = WPManager.Death.transform.position;
        customer.SetDestination(newTravelPosition);

        avail = false;

        order = false;

    }

    public void JailWP()
    {
     //   Debug.Log("calling Jail WP");
        Vector3 newTravelPosition = WPManager.Jail.transform.position;
        customer.SetDestination(newTravelPosition);
    }


    void OnTriggerStay()
    {
        gameObject.transform.rotation = Quaternion.identity;

    }
}
