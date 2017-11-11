using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class IconController : MonoBehaviour
{

    

    public Upgrades UpgradesScript;

    public float GuardRefreshTimer = 3;
    public float FoodRefreshTimer = 3;
    float GuardTimer;
    float FbiTimer;
    float FoodTimer;

    public Button guardButton;
    public Button FoodButton;
    public Button fbiButton;

    public GameObject Guard;
    public GameObject FBI;
    public GameObject Food;
    

    public Transform[] FoodSpawnLocations;
    public Transform[] GuardSpawnLocations;
    public Transform[] FbiSpawnLocations;

    public bool guard1 = false;
    public bool guard2 = false;
    public bool guard3 = false;
    public bool fbi = false;

    public int IGuard = 0;
    public int IFBI = 0;

    void Start()
    {

        GuardTimer = GuardRefreshTimer;
        FoodTimer = FoodRefreshTimer;

        guardButton.GetComponentInChildren<Text>().text = "Guard " + IGuard + "/3 - " + "250";
        fbiButton.GetComponentInChildren<Text>().text = "FBI " + IFBI + "/1 - " + "1000";


    }

    // Update is called once per frame
    void Update()
    {
        // SpawnFreeFBI();
        //SpawnFreeGuards();

        if (GameController.guardS1 == "empty" && GameController.guardS2 == "empty" && GameController.guardS3 == "empty")
        {
            guardButton.interactable = true;
        }
        else
        {
            return;
        }

        if (IFBI == 0 )
        {
            fbiButton.interactable = true;
        }
        else
        {
            return;
        }
    }


    public void SpawnGuard()
    {
        if (GameController.guardS3 == "full")
        {
            guardButton.interactable = false;
        }

        else if (GameController.guardS3 == "empty")
        {
            guardButton.interactable = true;

            if ((GameController.guardS1 == "empty") && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 250)

            {
                IGuard++;
                guardButton.GetComponentInChildren<Text>().text = "Guard " + IGuard + "/3 - " + "250";

                guard1 = true;
                guardButton.interactable = false;
                Instantiate(Guard, GuardSpawnLocations[0].position, Quaternion.identity);
                InvokeRepeating("GuardRefreshRate", 0.1f, .01f);
                GameController.guardS1 = "full";
                GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 250;
            }
            else if ((GameController.guardS2 == "empty") && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 250)

            {
                IGuard++;
                guardButton.GetComponentInChildren<Text>().text = "Guard " + IGuard + "/3 - " + "250";

                guard2 = true;
                guardButton.interactable = false;
                Instantiate(Guard, GuardSpawnLocations[1].position, Quaternion.identity);
                InvokeRepeating("GuardRefreshRate", 0.1f, .01f);
                GameController.guardS2 = "full";
                GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 250;
            }
            else if ((GameController.guardS3 == "empty") && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 250)

            {
                IGuard++;
                guardButton.GetComponentInChildren<Text>().text = "Guard " + IGuard + "/3 - " + "250";

                guard3 = true;
                guardButton.interactable = false;
                Instantiate(Guard, GuardSpawnLocations[2].position, Quaternion.identity);
                //InvokeRepeating("GuardRefreshRate", 0.1f, .01f);
                GameController.guardS3 = "full";
                GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 250;
            }
            else
            {
                return;
                //Debug.Log("Spot Not Available!!!!");
            }
        }
    }

   public void SpawnFBI()
    {
        if ((GameController.fbi == "empty") && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 1000)
        {
            IFBI++;
            fbiButton.GetComponentInChildren<Text>().text = "FBI " + IFBI + "/1 - " + "1000";

            fbi = true;
            fbiButton.interactable = false;
            Instantiate(FBI, FbiSpawnLocations[0].position, Quaternion.identity);
            InvokeRepeating("FBIRefreshRate", 0.1f, .01f);
            GameController.fbi = "full";
            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 1000;
        }
        else
        {
            return;
            //Debug.Log("Spot Not Available!!!!");
        }
    }

    // void SpawnFreeFBI()
    //{
    //  if ((GameController.fbi == "empty") && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 1000)
    //{
    //  SpawnFBI();
    //}

    //}

   // void SpawnFreeGuards()
    //{
     //if (GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 250)
       // {
         //   SpawnGuard();
        //}

    //}

    void GuardRefreshRate()
    {

        GuardTimer -= Time.deltaTime;

        if (GuardTimer <= 0)
        {

            CancelInvoke("GuardRefreshRate");

            guardButton.interactable = true;
            GuardTimer = GuardRefreshTimer;
        }
    }

    void FBIRefreshRate()
    {

        GuardTimer -= Time.deltaTime;

        if (GuardTimer <= 0)
        {

            CancelInvoke("FBIRefreshRate");

            fbiButton.interactable = true;
            GuardTimer = GuardRefreshTimer;
        }
    }

    public void SpawnFood()
    {


        Instantiate(Food, FoodSpawnLocations[0].position, Quaternion.identity);
        Instantiate(Food, FoodSpawnLocations[1].position, Quaternion.identity);
        Instantiate(Food, FoodSpawnLocations[2].position, Quaternion.identity);
        Instantiate(Food, FoodSpawnLocations[3].position, Quaternion.identity);
        InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
        FoodButton.interactable = false;

        if (GameObject.Find("Desks").GetComponentInChildren<Upgrades>().upgradeHotPlate1 == true)
        {
            Instantiate(Food, FoodSpawnLocations[4].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[5].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[6].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[7].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[12].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[13].position, Quaternion.identity);
        }

        if (GameObject.Find("Desks").GetComponentInChildren<Upgrades>().upgradeHotPlate2 == true)
        {
            Instantiate(Food, FoodSpawnLocations[8].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[9].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[14].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[15].position, Quaternion.identity);
        }

        if (GameObject.Find("Desks").GetComponentInChildren<Upgrades>().upgradeHotPlate3 == true)
        {
            Instantiate(Food, FoodSpawnLocations[10].position, Quaternion.identity);
            Instantiate(Food, FoodSpawnLocations[11].position, Quaternion.identity);

        }


    }

    void FoodRefreshRate()
    {

        FoodTimer -= Time.deltaTime;

        if (FoodTimer <= 0)
        {
            FoodButton.interactable = true;
            CancelInvoke("FoodRefreshRate");
            FoodTimer = FoodRefreshTimer;


        }
    }




}
