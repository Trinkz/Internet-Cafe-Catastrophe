using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

    public Button FoodPriceButton;
    public Button FoodSelectionButton;
    public Button FoodPrepButton;
    public Button JanitorButton;

    public GameObject Soda;
    public GameObject Bagel;
    public GameObject Burger;
    public GameObject Smoothie;


    public bool upgradeDesk1 = false;
    public bool upgradeDesk2 = false;
    public bool upgradeDesk3 = false;
    public bool upgradeDesk4 = false;

    public bool upgradeCounterSpace1 = false;
    public bool upgradeCounterSpace2 = false;
    public bool upgradeCounterSpace3 = false;

    public bool upgradeHotPlate1 = false;
    public bool upgradeHotPlate2 = false;
    public bool upgradeHotPlate3 = false;
    public bool upgradeHotPlate4 = false;

    public bool upgradeFoodPrep1 = false;
    public bool upgradeFoodPrep2 = false;

    public bool upgradeFoodPrice1 = false;
    public bool upgradeFoodPrice2 = false;



    public GameController Gcontroller;

    GameObject WPM;
    WaypointManager WPManager;
// Desk Objects************************************************************************
    [SerializeField]
    GameObject Desk1;
    [SerializeField]
    GameObject Desk2;
    [SerializeField]
    GameObject Desk3;
    [SerializeField]
    GameObject Desk4;
    [SerializeField]
    GameObject Desk5;
    [SerializeField]
    GameObject Desk6;
    [SerializeField]
    GameObject Desk7;
    [SerializeField]
    GameObject Desk8;
    // ***************************************************************************************
    //Counter space***************************************************************************
    [SerializeField]
    GameObject Hotplate1;
    [SerializeField]
    GameObject Hotplate2;
    [SerializeField]
    GameObject Hotplate3;
    [SerializeField]
    GameObject Hotplate4;
    [SerializeField]
    GameObject Hotplate5;
    [SerializeField]
    GameObject Hotplate6;
    [SerializeField]
    GameObject Hotplate7;
    [SerializeField]
    GameObject Hotplate8;
    //****************************************************************************************
    // Food Selection ************************************************************************
    [SerializeField]
    GameObject Hotplate9;
    [SerializeField]
    GameObject Hotplate10;
    [SerializeField]
    GameObject Hotplate11;
    [SerializeField]
    GameObject Hotplate12;

    //****************************************************************************************
    public GameObject[] food;
    FoodGen fGen;
    GameObject foodItem;
    FoodDrinkValues fVal;

    FoodManager foodManage;

    bool upgradePriceBool = false;

   
    int UpgradeFoodPrepText;
    int FoodSelectionText;
    int UpgradeFoodPriceText;

    Tutorial tutorial;

    // Use this for initialization
    void Start ()
    {
        tutorial = GameObject.Find("Game Icon Controller").GetComponent<Tutorial>();
        WPM = GameObject.Find("WPManager");
        WPManager = GetComponent<WaypointManager>();
        ResetUpgrades();
        UpgradeFoodPrepText = 1;
        FoodSelectionText = 1;
        UpgradeFoodPriceText = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {

        
        
    }

    public void UpgradeDesk()
    {
        if (upgradeDesk1 == false)
        {
           // Debug.Log("Space key has been pressed");
            WPM.GetComponent<WaypointManager>().UpgradeDesk1();
            WPM.GetComponent<WaypointManager>().FindAvailDesks();

            Desk1.SetActive(true);
            Desk2.SetActive(true);

            // Food Selection Hot Plates


            upgradeDesk1 = true;
        }
       else if (upgradeDesk1 == true && upgradeDesk2 == false)
        {
            
            WPM.GetComponent<WaypointManager>().UpgradeDesk2();
            WPM.GetComponent<WaypointManager>().FindAvailDesks();

            Desk3.SetActive(true);
            Desk4.SetActive(true);

            upgradeDesk2 = true;
        }
        else if( (upgradeDesk2 == true) && upgradeDesk3 == false)
        {
            WPM.GetComponent<WaypointManager>().UpgradeDesk3();
            WPM.GetComponent<WaypointManager>().FindAvailDesks();
            Desk5.SetActive(true);
            Desk6.SetActive(true);

            upgradeDesk3 = true;
        }
        else if(( upgradeDesk3 == true) && upgradeDesk4 == false)
        {
            WPM.GetComponent<WaypointManager>().UpgradeDesk4();
            WPM.GetComponent<WaypointManager>().FindAvailDesks();
            Desk7.SetActive(true);
            Desk8.SetActive(true);

            upgradeDesk4 = true;
        }
    }

    public void FoodPrep()
    {
       if(upgradeFoodPrep1 == false && GameObject.Find("GameController").GetComponent<GameController>().score >= 500)
        {
         //   Debug.Log("food prep called");

            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 500;
            FoodPrepButton.GetComponentInChildren<Text>().text = "FoodPrep 2 - " + "2500";
           
            upgradeFoodPrep1 = true;

            UpgradeFoodPrepText = 2;

            foreach (GameObject gen in food)
            {
                fGen = gen.GetComponent<FoodGen>();

               // Debug.Log("food foreach called");
                if(fGen.spawnTime == 15)
                {
                //    Debug.Log("spawn time is now 10");
                    fGen.spawnTime -= 5;
                }  
                
            }

        }
        else if (upgradeFoodPrep1 == true && upgradeFoodPrep2 == false && GameObject.Find("GameController").GetComponent<GameController>().score >= 2500)
        {
            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 2500;
            FoodPrepButton.GetComponentInChildren<Text>().text ="Complete";
            upgradeFoodPrep2 = true;

            FoodPrepButton.interactable = false;
            UpgradeFoodPrepText = 3;

            foreach (GameObject gen in food)
            {
              //  Debug.Log("food foreach called");
                fGen = gen.GetComponent<FoodGen>();

                if (fGen.spawnTime == 10)
                {
                    fGen.spawnTime -= 5;
                }
            }

        }
        else
            {
                return;
            }
    }

    public void FoodSelection()
    {
        if (upgradeCounterSpace1 == false && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 650)
        {
            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 650;
            FoodSelectionButton.GetComponentInChildren<Text>().text = "FoodSelection 2 - "+"1100";
            upgradeCounterSpace1 = true;
            Hotplate5.SetActive(true);
            Hotplate7.SetActive(true);

            Soda.SetActive(true);
            Bagel.SetActive(true);

            FoodSelectionText = 2;

        }

        else if ((upgradeCounterSpace1 == true) && GameObject.Find("GameController").GetComponentInChildren<GameController>().score >= 1100)
        {
            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 1100;
            FoodSelectionButton.GetComponentInChildren<Text>().text = "Complete";

            FoodSelectionButton.interactable = false;

            upgradeCounterSpace2 = true;
            Hotplate9.SetActive(true);
            Hotplate11.SetActive(true);

            Smoothie.SetActive(true);
            Burger.SetActive(true);

            FoodSelectionText = 3;

        }

        else if (upgradeCounterSpace1 == true && upgradeCounterSpace2 == true)
        {
            return;
        }

    }

    public void FoodPrice()
    {
        if (upgradeFoodPrice1 == false && GameObject.Find("GameController").GetComponent<GameController>().score >= 1000)
        {
         //   Debug.Log("food price called");

            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 1000;
            FoodPriceButton.GetComponentInChildren<Text>().text = "FoodPrice 2 - " + "2000";
            upgradeFoodPrice1 = true;
            UpgradeFoodPriceText = 2;


            foreach (GameObject gen in food)
            {
             //   Debug.Log("food price for each called");

                fGen = gen.GetComponent<FoodGen>();
                foodItem = fGen.Food;

                fVal = foodItem.GetComponent<FoodDrinkValues>();

                fVal.scoreValue += 25;

            }

        }
        else if (upgradeFoodPrice1 == true && upgradeFoodPrice2 == false && GameObject.Find("GameController").GetComponent<GameController>().score >= 2000)
        {
          //  Debug.Log("food price called");

            GameObject.Find("GameController").GetComponentInChildren<GameController>().score -= 2000;
            FoodPriceButton.GetComponentInChildren<Text>().text ="Complete";
            upgradeFoodPrice2 = true;
            UpgradeFoodPriceText = 3;
            FoodPriceButton.interactable = false;

            foreach (GameObject gen in food)
            {
               // Debug.Log("food price for each called");

                fGen = gen.GetComponent<FoodGen>();
                foodItem = fGen.Food;

                fVal = foodItem.GetComponent<FoodDrinkValues>();

                fVal.scoreValue += 25;

            }
        }
        else
        {
            return;
        }
        

    }

    public void ResetUpgrades()
    {
        upgradeDesk1 = false;
        upgradeDesk2 = false;
        upgradeDesk3 = false;
        upgradeDesk4 = false;

        upgradeHotPlate1 = false;
        upgradeHotPlate2 = false;
        upgradeHotPlate3 = false;
        upgradeHotPlate4 = false;

        upgradeCounterSpace1 = false;
        upgradeCounterSpace2 = false;
        upgradeCounterSpace3 = false;
        
    }

    public void UpgradePrice()
    {
        if(upgradePriceBool == false)
        {
            upgradePriceBool = true;
        FoodPrepButton.GetComponentInChildren<Text>().text = "Food Prep - " + "500";
        FoodSelectionButton.GetComponentInChildren<Text>().text = "FoodSelection 1 - " + "650";
        FoodPriceButton.GetComponentInChildren<Text>().text = "Food Price - " + "1000";
        JanitorButton.GetComponentInChildren<Text>().text = "Janitor - " + "1000";

        }

    }

    public void ResetFood()
    {
        // Food Select *************************************************************************

        if (upgradeCounterSpace1 == true && upgradeCounterSpace2 == false)
        {
            Soda.SetActive(false);
            Bagel.SetActive(false);
        }
        else if (upgradeCounterSpace2 == true)
        {
            Smoothie.SetActive(false);
            Burger.SetActive(false);
        }

        // Food PREP*****************************************************************************

        if(upgradeFoodPrep1 == true && upgradeFoodPrep2 == false)
        {
            foreach (GameObject gen in food)
            {
                fGen = gen.GetComponent<FoodGen>();

                    fGen.spawnTime += 5;
               
            }
        }
        else if(upgradeFoodPrep2 == true)
        {
            foreach (GameObject gen in food)
            {
                fGen = gen.GetComponent<FoodGen>();

                fGen.spawnTime += 10;

            }
        }

        // Trash Count*****************************************************************************
        if (GameObject.Find("TrashCans").GetComponent<TrashCounter>().trashcount > 0)
        {
            GameObject.Find("TrashCans").GetComponent<TrashCounter>().trashcount = 0;
            GameObject.Find("TrashCans").GetComponent<TrashCounter>().TrashComplete = false;
            GameObject.Find("TrashCans").GetComponent<TrashCounter>().trash1.GetComponent<trash>().DishCount = false;
            GameObject.Find("TrashCans").GetComponent<TrashCounter>().trash2.GetComponent<trash>().DishCount = false;

        }
        //****************************************************************************************
        // Food Value****************************************************************************

        if (upgradeFoodPrice1 == true && upgradeFoodPrice2 == false)
        {
            foreach (GameObject gen in food)
            {


                fGen = gen.GetComponent<FoodGen>();
                foodItem = fGen.Food;

                fVal = foodItem.GetComponent<FoodDrinkValues>();

                fVal.scoreValue -= 25;

            }
        }
        else if(upgradeFoodPrice2 == true)
        {
            foreach (GameObject gen in food)
            {


                fGen = gen.GetComponent<FoodGen>();
                foodItem = fGen.Food;

                fVal = foodItem.GetComponent<FoodDrinkValues>();

                fVal.scoreValue -= 50;

            }
        }


        //******************************************************************************************
    }

    public void ReturnTextToButtonOnHover()
    {

        if (UpgradeFoodPrepText == 1)
        {
            FoodPrepButton.GetComponentInChildren<Text>().text = "Food Prep - " + "500"; 
        }

        if (UpgradeFoodPrepText == 2)
        {
            FoodPrepButton.GetComponentInChildren<Text>().text = "FoodPrep 2 - " + "2500";
        }

        if (UpgradeFoodPrepText == 3)
        {
            FoodPrepButton.GetComponentInChildren<Text>().text = "Complete";
        }

        if (FoodSelectionText == 1)
        {
            FoodSelectionButton.GetComponentInChildren<Text>().text = "Food Selection 1 - " + "650";
        }

        if (FoodSelectionText == 2)
        {
            FoodSelectionButton.GetComponentInChildren<Text>().text = "FoodSelection 2 - " + "1100";
        }

        if (FoodSelectionText == 3)
        {
            FoodSelectionButton.GetComponentInChildren<Text>().text = "Complete";
        }

        if (UpgradeFoodPriceText == 1)
        {
            FoodPriceButton.GetComponentInChildren<Text>().text = "Food Price - " + "1000";
        }

        if (UpgradeFoodPriceText == 2)
        {
            FoodPriceButton.GetComponentInChildren<Text>().text = "FoodPrice 2 - " + "2000";
        }

        if (UpgradeFoodPriceText == 3)
        {
            FoodPriceButton.GetComponentInChildren<Text>().text = "Complete";
        }

        if (GameObject.Find("GameController").GetComponent<GameController>().JanitorText == 1)
        {
            JanitorButton.GetComponentInChildren<Text>().text = "Janitor - " + "1000";
        }

        if (GameObject.Find("GameController").GetComponent<GameController>().JanitorText == 2)
        {
            JanitorButton.GetComponentInChildren<Text>().text = "Complete";
        }

    }

    public void ActiveUpgrades()
    {
        if (tutorial.P1 == false)
        {
            
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(false);
            Desk2.SetActive(false);
            Desk3.SetActive(false);
            Desk4.SetActive(false);
            Desk5.SetActive(false);
            Desk6.SetActive(false);
            Desk7.SetActive(false);
            Desk8.SetActive(false);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(false);
            tutorial.FBI.SetActive(false);
            tutorial.Guard.SetActive(false);
            tutorial.Inspector.SetActive(false);
            tutorial.Janitor.SetActive(false);
            tutorial.Powwweeeerrrr.SetActive(false);
            tutorial.Flood.SetActive(false);


        }

        if (tutorial.P1 == true && tutorial.P2 == false)
        {
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(true);
            Desk2.SetActive(true);
            Desk3.SetActive(false);
            Desk4.SetActive(false);
            Desk5.SetActive(false);
            Desk6.SetActive(false);
            Desk7.SetActive(false);
            Desk8.SetActive(false);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(true);
            tutorial.FBI.SetActive(false);
            tutorial.Guard.SetActive(true);
            tutorial.Inspector.SetActive(false);
            tutorial.Janitor.SetActive(false);
            tutorial.Powwweeeerrrr.SetActive(false);
            tutorial.Flood.SetActive(false);

        }
        if (tutorial.P2 == true && tutorial.P3 == false)
        {
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(true);
            Desk2.SetActive(true);
            Desk3.SetActive(true);
            Desk4.SetActive(true);
            Desk5.SetActive(false);
            Desk6.SetActive(false);
            Desk7.SetActive(false);
            Desk8.SetActive(false);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(true);
            tutorial.FBI.SetActive(false);
            tutorial.Guard.SetActive(true);
            tutorial.Inspector.SetActive(true);
            tutorial.Janitor.SetActive(false);
            tutorial.Powwweeeerrrr.SetActive(false);
            tutorial.Flood.SetActive(false);

        }
        if (tutorial.P3 == true && tutorial.P4 == false)
        {
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(true);
            Desk2.SetActive(true);
            Desk3.SetActive(true);
            Desk4.SetActive(true);
            Desk5.SetActive(true);
            Desk6.SetActive(true);
            Desk7.SetActive(false);
            Desk8.SetActive(false);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(true);
            tutorial.FBI.SetActive(true);
            tutorial.Guard.SetActive(true);
            tutorial.Inspector.SetActive(true);
            tutorial.Janitor.SetActive(true);
            tutorial.Powwweeeerrrr.SetActive(false);
            tutorial.Flood.SetActive(false);

        }
        if (tutorial.P4 == true && tutorial.P5 == false)
        {
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(true);
            Desk2.SetActive(true);
            Desk3.SetActive(true);
            Desk4.SetActive(true);
            Desk5.SetActive(true);
            Desk6.SetActive(true);
            Desk7.SetActive(true);
            Desk8.SetActive(true);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(true);
            tutorial.FBI.SetActive(true);
            tutorial.Guard.SetActive(true);
            tutorial.Inspector.SetActive(true);
            tutorial.Janitor.SetActive(true);
            tutorial.Powwweeeerrrr.SetActive(false);
            tutorial.Flood.SetActive(false);
            
        }
        if (tutorial.P5 == true && tutorial.P6 == false)
        {
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(true);
            Desk2.SetActive(true);
            Desk3.SetActive(true);
            Desk4.SetActive(true);
            Desk5.SetActive(true);
            Desk6.SetActive(true);
            Desk7.SetActive(true);
            Desk8.SetActive(true);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(true);
            tutorial.FBI.SetActive(true);
            tutorial.Guard.SetActive(true);
            tutorial.Inspector.SetActive(true);
            tutorial.Janitor.SetActive(true);
            tutorial.Powwweeeerrrr.SetActive(true);
            tutorial.Flood.SetActive(false);


        }
        if (tutorial.P6 == true && tutorial.P7 == false)
        {
            // Resetting Food and upgrades ****************************
            ResetFood();
            ResetUpgrades();


            // Desk Reset**********************************************************
            Desk1.SetActive(true);
            Desk2.SetActive(true);
            Desk3.SetActive(true);
            Desk4.SetActive(true);
            Desk5.SetActive(true);
            Desk6.SetActive(true);
            Desk7.SetActive(true);
            Desk8.SetActive(true);


            // Hotplates ***************************************************************
            Hotplate5.SetActive(false);
            Hotplate7.SetActive(false);
            Soda.SetActive(false);
            Bagel.SetActive(false);
            Hotplate9.SetActive(false);
            Hotplate11.SetActive(false);
            Smoothie.SetActive(false);
            Burger.SetActive(false);

            // Pricing text*************************************************************

            UpgradeFoodPrepText = 1;
            FoodSelectionText = 1;
            UpgradeFoodPriceText = 1;

            // Button resets **********************************************************

            tutorial.Upgrades.SetActive(true);
            tutorial.FBI.SetActive(true);
            tutorial.Guard.SetActive(true);
            tutorial.Inspector.SetActive(true);
            tutorial.Janitor.SetActive(true);
            tutorial.Powwweeeerrrr.SetActive(true);
            tutorial.Flood.SetActive(true);


        }

    }

    public void LevelOneDesks()
    {
        if (tutorial.L1_2 == true && tutorial.L1_3 == false)
        {
            // first Desk 3 and waypoint 4/element5
            Desk3.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }

        else if (tutorial.L1_3 == true)
        {
            // then desk 2 and waypoint 5/element 6
            Desk2.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.GetComponent<DeskAvailable>().atDesk = false;


        }
    }

    public void LevelTwoDesks()
    {
        if (tutorial.L2_3 == true && tutorial.L2_4 == false)
        {
            // first Desk 2 and waypoint element 4
            Desk2.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[4].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[4].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 4 and waypoint element 6
            Desk4.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }

        else if (tutorial.L2_5 == true)
        {
          //  Debug.Log("Desk Upgarde 2");
            // then desk 1 and waypoint element 5
            Desk1.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk3.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[7].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[7].gameObject.GetComponent<DeskAvailable>().atDesk = false;


        }
    }

    public void LevelThreeDesks()
    {
        if (tutorial.L3_3 == true && tutorial.L3_4 == false)
        {
            // first Desk 2 and waypoint element 4
            Desk1.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[7].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[7].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 4 and waypoint element 6
            Desk2.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }

        else if (tutorial.L3_5 == true && tutorial.L3_6 == false)
        {

            // then desk 1 and waypoint element 5
            Desk3.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[4].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[4].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk4.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }
// Need Desk Info ********************************************************************************************************************************


        else if (tutorial.L3_7 == true && tutorial.L3_8 == false)
        {

            // then desk 1 and waypoint element 5
            Desk5.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[9].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[9].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk6.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[8].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[8].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }


        else if (tutorial.L3_9 == true)
        {

            // then desk 1 and waypoint element 5
            Desk7.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[11].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[11].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk8.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[10].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[10].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }
    }

    public void EndlessDesks()
    {
        if (tutorial.L4_3 == true && tutorial.L4_4 == false)
        {
            // first Desk 2 and waypoint element 4
            Desk1.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[7].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[7].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 4 and waypoint element 6
            Desk2.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[6].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }

        else if (tutorial.L4_5 == true && tutorial.L4_6 == false)
        {

            // then desk 1 and waypoint element 5
            Desk3.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[4].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[4].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk4.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[5].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }
        // Need Desk Info ********************************************************************************************************************************


        else if (tutorial.L4_7 == true && tutorial.L4_8 == false)
        {

            // then desk 1 and waypoint element 5
            Desk5.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[9].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[9].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk6.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[8].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[8].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }


        else if (tutorial.L4_9 == true)
        {

            // then desk 1 and waypoint element 5
            Desk7.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[11].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[11].gameObject.GetComponent<DeskAvailable>().atDesk = false;

            // first Desk 3 and waypoint element 7
            Desk8.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[10].gameObject.SetActive(true);
            WPM.GetComponent<WaypointManager>().waypoints[10].gameObject.GetComponent<DeskAvailable>().atDesk = false;

        }
    }

}
