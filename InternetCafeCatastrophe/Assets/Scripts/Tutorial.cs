using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Tutorial : MonoBehaviour
{
    public Transform Phase1;
    public Transform Phase2;
    public Transform Phase3;
    public Transform Phase4;
    public Transform Phase5;
    public Transform Phase6;
    public Transform Phase7;

    public Transform PhaseSelect;
    public Transform NormalMenu;

    public GameObject FBI;
    public GameObject Guard;
    public GameObject Upgrades;
    public GameObject Inspector;
    public GameObject Janitor; 
    public GameObject Powwweeeerrrr;
    public GameObject Flood;
    public GameObject Waiter;

    public GameObject FireForLevel3;

    public bool P1;
    public bool P2;
    public bool P3;
    public bool P4;
    public bool P5;
    public bool P6;
    public bool P7;

    bool P1Obj1 = false;
    bool P1Obj2 = false;
   public  bool P1Obj3 = false;

    bool P2Obj1 = false;
    bool P2Obj2 = false;
    bool P2Obj3 = false;

    bool P3Obj1 = false;
    public bool P3Obj2 = false;
    bool P3Obj3 = false;

    bool P4Obj1 = false;
    bool P4Obj2 = false;
    bool P4Obj3 = false;

    bool P5Obj1 = false;
    bool P5Obj2 = false;
    bool P5Obj3 = false;




    ObjectiveList ObjList;

    public GameObject PumpButton;
    public GameObject feedCustomers;
    public GameObject feed1337;
    public GameObject feedHacker;
    public GameObject upgrades;

    public bool Paused;

    string SceneName;
    Scene currentScene;
    GameController gameController;

    Upgrades deskupgrade;

    // Use this for initialization
    void Start()
    {
        // Scene references
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
        ObjList = GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        deskupgrade = GameObject.Find("Desks").GetComponent<Upgrades>();
        


        // ************** Tutorial Stuff ************************
        if (SceneName == "ICC_Stage1")
        {
            P1 = false;
            P2 = false;
            P3 = false;
            P4 = false;
            P5 = false;
            P6 = false;
            P7 = false;

            Time.timeScale = 0;
            PhaseOne();

            Paused = true;

        }
        // **************** Level One Stuff ******************
        else if (SceneName == "LevelOne")
        {
            L1_1 = false;
            L1_2 = false;
            L1_3 = false;

            Time.timeScale = 1;
            LevelOnePhases();

            Paused = false;


        }

        // **************** Level Two Stuff ******************
        else if (SceneName == "LevelTwo")
        {
            L2_1 = false;
            L2_2 = false;
            L2_3 = false;
            L2_4 = false;
            L2_5 = false;

            Time.timeScale = 1;
            LevelTwoPhases();

            Paused = false;

        }
        // **************** Level Three Stuff ******************
        else if (SceneName == "LevelThree")
        {
            L3_1 = false;
            L3_2 = false;
            L3_3 = false;
            L3_4 = false;
            L3_5 = false;
            L3_6 = false;
            L3_7 = false;
            L3_8 = false;
            L3_9 = false;

            Time.timeScale = 1;
            LevelThreePhases();

            Paused = false;

        }

        // **************** Endless level Stuff ******************
        else if (SceneName == "Endless")
        {
            L4_1 = false;
            L4_2 = false;
            L4_3 = false;
            L4_4 = false;
            L4_5 = false;
            L4_6 = false;
            L4_7 = false;
            L4_8 = false;
            L4_9 = false;

            Time.timeScale = 1;
            Endless();

            Paused = false;

        }
    }

        // Update is called once per frame
        void Update ()
    {
        if (Phase2.Find("Panel_09").gameObject.activeInHierarchy == true || Phase4.Find("Panel_P4End").gameObject.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }
        


        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S) && SceneName == "ICC_Stage1")
        {
            Time.timeScale = 0;
            Paused = true;
            NormalMenu.gameObject.SetActive(false);
            PhaseSelect.gameObject.SetActive(true);
        }

        //Debug.Log("TimeScale is set to " + Time.timeScale);
	}

    void PhaseOne()
    {
        if (GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText.Length > 0)
        {
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
        }


        P1 = true;



        Phase1.gameObject.SetActive(true);
        Paused = true;

        GameObject.Find("GameController").GetComponent<GameController>().Score1(2000);
        GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
        GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

        NormalMenu.gameObject.SetActive(true);


    }

    public void PhaseTwo()
    {
        if (P2 == false)
        {
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);



            P2 = true;



            Time.timeScale = 0;
        Phase2.gameObject.SetActive(true);
        Paused = true;

        GameObject.Find("GameController").GetComponent<GameController>().Score1(4000);
        GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
        Guard.SetActive(true);
        Upgrades.SetActive(true);
        GameObject.Find("Desks").GetComponent<Upgrades>().UpgradeDesk();

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            NormalMenu.gameObject.SetActive(true);

        }
        else
        {
            return;
        }


    }

    public void PhaseThree()
    {
        if( P3 == false)
        {
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);

            P3 = true;


            Time.timeScale = 0;
            Phase3.gameObject.SetActive(true);
            Paused = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(6000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();

            Inspector.SetActive(true);
            GameObject.Find("Desks").GetComponent<Upgrades>().UpgradeDesk();

            //***********************************************

        //*****************************************************
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            NormalMenu.gameObject.SetActive(true);


        }
        else
        {
            return;
        }

    }

    public void PhaseFour()
    {
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);

        P4 = true;


        Time.timeScale = 0;
        Phase4.gameObject.SetActive(true);
        Paused = true;

        GameObject.Find("GameController").GetComponent<GameController>().Score1(8000);
        GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();

        FBI.SetActive(true);
        Janitor.SetActive(true);
        GameObject.Find("Desks").GetComponent<Upgrades>().UpgradeDesk();
     //   Debug.Log("Phase 4 Desks Upgrade");

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

        NormalMenu.gameObject.SetActive(true);

    }

    public void PhaseFive()
    {
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);



        P5 = true;
        Time.timeScale = 0;
        Phase5.gameObject.SetActive(true);
        Paused = true;

        GameObject.Find("Desks").GetComponent<Upgrades>().UpgradeDesk();
      //  Debug.Log("Phase 5 Desks Upgrade");

        GameObject.Find("GameController").GetComponent<GameController>().Score1(10000);
        GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

        NormalMenu.gameObject.SetActive(true);

    }

    public void PhaseSix()
    {
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);

        P6 = true;
        Time.timeScale = 0;
        Phase6.gameObject.SetActive(true);
        Paused = true;


        Powwweeeerrrr.SetActive(true);


        GameObject.Find("GameController").GetComponent<GameController>().Score1(12000);
        GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

        NormalMenu.gameObject.SetActive(true);

    }

    public void PhaseSeven()
    {
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);

        P7 = true;
        Time.timeScale = 0;
        Phase7.gameObject.SetActive(true);
        Paused = true;
        PumpButton.SetActive(true);
        Flood.SetActive(true);

      
        GameObject.Find("GameController").GetComponent<GameController>().Score1(14000);
        GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();

        GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

        NormalMenu.gameObject.SetActive(true);


    }

    public void PlayAgain()
    {
        if (P1 == true)
        {
            //Debug.Log("Phase 1");

            Phase1.Find("Panel_01").gameObject.SetActive(true);

        Phase1.gameObject.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
            if(P1Obj1 == false)
            {
                P1Obj1 = true;
                ObjList.CreateObjective(1, "Spawn Food");
            }

            else if (P1Obj1 == true && P1Obj2 == false)
            {
                P1Obj2 = true;
                ObjList.CreateObjective(2, "Serve 4 Customers");
            }
            else if (P1Obj2 == true && P1Obj3 == false)
            {
                P1Obj3 = true;
                ObjList.CreateObjective(3, "Throw Away Spoiled Food");
            }

        }
        if (P1 == true && P2 == true)
        {
            //Starts at 2000
            //Debug.Log("Phase 2");

            Phase2.Find("Panel_01").gameObject.SetActive(true);

            Phase2.gameObject.SetActive(false);
            Time.timeScale = 1;
            Paused = false;

            if (P2Obj1 == false)
            {
                P2Obj1 = true;
                ObjList.CreateObjective(1, "Purchase An Upgrade");
            }

            else if (P2Obj1 == true && P2Obj2 == false)
            {
                P2Obj2 = true;
                ObjList.CreateObjective(2, "Purchase and Use Guard on Hacker");
            }
            else if (P2Obj2 == true && P2Obj3 == false)
            {
                P2Obj3 = true;
                ObjList.CreateObjective(3, "Make Hacker Leave By Feeding");
            }

            
            
            
        }
        if (P1 == true && P2 == true && P3 == true)
        {
            //starts at 4000
            //Debug.Log("Phase 3");

            Phase3.Find("Panel_01").gameObject.SetActive(true);

            Phase3.gameObject.SetActive(false);
            Time.timeScale = 1;
            Paused = false;

            if (P3Obj1 == false)
            {
                P3Obj1 = true;
                ObjList.CreateObjective(1, "Throw Away 5 trash items (dishes/spoiled food)");
            }

            else if (P3Obj1 == true && P3Obj2 == false)
            {
                P3Obj2 = true;
                ObjList.CreateObjective(2, "Inspector finds a clean shop");
            }

        }
        if (P1 == true && P2 == true && P3 == true && P4 == true)
        {
            //starts at 6000
            //Debug.Log("Phase 4");

            Phase4.Find("Panel_01").gameObject.SetActive(true);

            Phase4.gameObject.SetActive(false);
            Time.timeScale = 1;
            Paused = false;

            if (P4Obj1 == false)
            {
                P4Obj1 = true;
                ObjList.CreateObjective(1, "Purchase an FBI");
            }

            else if (P4Obj1 == true && P4Obj2 == false)
            {
                P4Obj2 = true;
                ObjList.CreateObjective(2, "Purchase the Janitor Upgrade");
            }
            else if (P4Obj2 == true && P4Obj3 == false)
            {
                P4Obj3 = true;
                ObjList.CreateObjective(3, "Use FBI on Hacker");
            }  

        }
        if (P1 == true && P2 == true && P3 == true && P4 == true && P5 == true)
        {
            //starts at 8000
            //Debug.Log("Phase 5");

            Phase5.Find("Panel_01").gameObject.SetActive(true);

            Phase5.gameObject.SetActive(false);
            Time.timeScale = 1;
            Paused = false;

            if (P5Obj1 == false)
            {
                P5Obj1 = true;
                ObjList.CreateObjective(1, "Use FBI on 1337 Hacker");
            }

            else if (P5Obj1 == true && P5Obj2 == false)
            {
                P5Obj2 = true;
                ObjList.CreateObjective(2, "Make 1337 Hacker Leave by Feeding");

            }

        }
        if (P1 == true && P2 == true && P3 == true && P4 == true && P5 == true && P6 == true)
        {
            //starts at 10000

            //Debug.Log("Phase 6");

            Phase6.Find("Panel_01").gameObject.SetActive(true);

            Phase6.gameObject.SetActive(false);
            Time.timeScale = 1;
            Paused = false;

            ObjList.CreateObjective(1, "Repair Power Generator");

        }
        if (P1 == true && P2 == true && P3 == true && P4 == true && P5 == true && P6 == true && P7 == true)
        {
            //starts at 12000

            //Debug.Log("Phase 7");

            Phase7.Find("Panel_01").gameObject.SetActive(true);

            Phase7.gameObject.SetActive(false);
            Time.timeScale = 1;
            Paused = false;

            ObjList.CreateObjective(1, "Use Pump during flood");

        }




    }

    public void SelectOne()
    {
        P1 = false;
        P2 = false;
        P3 = false;
        P4 = false;
        P5 = false;
        P6 = false;
        P7 = false;

         P1Obj1 = false;
         P1Obj2 = false;
         P1Obj3 = false;

         P2Obj1 = false;
         P2Obj2 = false;
         P2Obj3 = false;

         P3Obj1 = false;
         P3Obj2 = false;
         P3Obj3 = false;

         P4Obj1 = false;
         P4Obj2 = false;
         P4Obj3 = false;

         P5Obj1 = false;
         P5Obj2 = false;
         P5Obj3 = false;

        PhaseSelect.gameObject.SetActive(false);

        GameObject.Find("WPManager").GetComponent<WaypointManager>().phaseDesks();
        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();
        PumpButton.SetActive(false);
        Flood.SetActive(false);


        PhaseOne();
        GameObject.Find("GameController").GetComponent<GameController>().score = 0;

    }
    public void SelectTwo()
    {
        P1 = true;
        P2 = false;
        P3 = false;
        P4 = false;
        P5 = false;
        P6 = false;
        P7 = false;

        P1Obj1 = true;
        P1Obj2 = true;
        P1Obj3 = true;

        P2Obj1 = false;
        P2Obj2 = false;
        P2Obj3 = false;

        P3Obj1 = false;
        P3Obj2 = false;
        P3Obj3 = false;

        P4Obj1 = false;
        P4Obj2 = false;
        P4Obj3 = false;

        P5Obj1 = false;
        P5Obj2 = false;
        P5Obj3 = false;

        GameObject.Find("WPManager").GetComponent<WaypointManager>().phaseDesks();
        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();

        PhaseSelect.gameObject.SetActive(false);
        PumpButton.SetActive(false);
        Flood.SetActive(false);


        PhaseTwo();
        GameObject.Find("GameController").GetComponent<GameController>().score = 2000;
    }
    public void SelectThree()
    {
        P1 = true;
        P2 = true;
        P3 = false;
        P4 = false;
        P5 = false;
        P6 = false;
        P7 = false;

        P1Obj1 = true;
        P1Obj2 = true;
        P1Obj3 = true;

        P2Obj1 = true;
        P2Obj2 = true;
        P2Obj3 = true;

        P3Obj1 = false;
        P3Obj2 = false;
        P3Obj3 = false;

        P4Obj1 = false;
        P4Obj2 = false;
        P4Obj3 = false;

        P5Obj1 = false;
        P5Obj2 = false;
        P5Obj3 = false;

        GameObject.Find("WPManager").GetComponent<WaypointManager>().phaseDesks();
        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();

        PhaseSelect.gameObject.SetActive(false);
        PumpButton.SetActive(false);
        Flood.SetActive(false);


        PhaseThree();
        GameObject.Find("GameController").GetComponent<GameController>().score = 4000;
    }
    public void SelectFour()
    {
        P1 = true;
        P2 = true;
        P3 = true;
        P4 = false;
        P5 = false;
        P6 = false;
        P7 = false;

        P1Obj1 = true;
        P1Obj2 = true;
        P1Obj3 = true;

        P2Obj1 = true;
        P2Obj2 = true;
        P2Obj3 = true;

        P3Obj1 = true;
        P3Obj2 = true;
        P3Obj3 = true;

        P4Obj1 = false;
        P4Obj2 = false;
        P4Obj3 = false;

        P5Obj1 = false;
        P5Obj2 = false;
        P5Obj3 = false;

        GameObject.Find("WPManager").GetComponent<WaypointManager>().phaseDesks();
        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();

        PhaseSelect.gameObject.SetActive(false);
        PumpButton.SetActive(false);
        Flood.SetActive(false);


        PhaseFour();
        GameObject.Find("GameController").GetComponent<GameController>().score = 6000;
    }
    public void SelectFive()
    {
        P1 = true;
        P2 = true;
        P3 = true;
        P4 = true;
        P5 = false;
        P6 = false;
        P7 = false;

        P1Obj1 = true;
        P1Obj2 = true;
        P1Obj3 = true;

        P2Obj1 = true;
        P2Obj2 = true;
        P2Obj3 = true;

        P3Obj1 = true;
        P3Obj2 = true;
        P3Obj3 = true;

        P4Obj1 = true;
        P4Obj2 = true;
        P4Obj3 = true;

        P5Obj1 = false;
        P5Obj2 = false;
        P5Obj3 = false;

        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();

        PhaseSelect.gameObject.SetActive(false);
        PumpButton.SetActive(false);
        Flood.SetActive(false);

        GameObject.Find("WPManager").GetComponent<WaypointManager>().DeskOff = false;

        PhaseFive();
        GameObject.Find("GameController").GetComponent<GameController>().score = 8000;
    }
    public void SelectSix()
    {
        P1 = true;
        P2 = true;
        P3 = true;
        P4 = true;
        P5 = true;
        P6 = false;
        P7 = false;

        P1Obj1 = true;
        P1Obj2 = true;
        P1Obj3 = true;

        P2Obj1 = true;
        P2Obj2 = true;
        P2Obj3 = true;

        P3Obj1 = true;
        P3Obj2 = true;
        P3Obj3 = true;

        P4Obj1 = true;
        P4Obj2 = true;
        P4Obj3 = true;

        P5Obj1 = true;
        P5Obj2 = true;
        P5Obj3 = true;

        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();

        PhaseSelect.gameObject.SetActive(false);
        PumpButton.SetActive(false);
        Flood.SetActive(false);

        GameObject.Find("WPManager").GetComponent<WaypointManager>().DeskOff = false;

        PhaseSix();
        GameObject.Find("GameController").GetComponent<GameController>().score = 10000;
    }
    public void SelectSeven()
    {
        P1 = true;
        P2 = true;
        P3 = true;
        P4 = true;
        P5 = true;
        P6 = true;
        P7 = false;

        P1Obj1 = true;
        P1Obj2 = true;
        P1Obj3 = true;

        P2Obj1 = true;
        P2Obj2 = true;
        P2Obj3 = true;

        P3Obj1 = true;
        P3Obj2 = true;
        P3Obj3 = true;

        P4Obj1 = true;
        P4Obj2 = true;
        P4Obj3 = true;

        P5Obj1 = true;
        P5Obj2 = true;
        P5Obj3 = true;

        GameObject.Find("Desks").GetComponent<Upgrades>().ActiveUpgrades();

        PhaseSelect.gameObject.SetActive(false);
        PumpButton.SetActive(true);
        Flood.SetActive(true);

        GameObject.Find("WPManager").GetComponent<WaypointManager>().DeskOff = false;

        PhaseSeven();
        GameObject.Find("GameController").GetComponent<GameController>().score = 12000;
    }
    public void SelectExit()
    {
        Time.timeScale = 1;
        Paused = false;
        PhaseSelect.gameObject.SetActive(false);
    }

    public void PanelSelect()
    {
        if (P1Obj1 == true && P1Obj2 == false)
        { 
            Time.timeScale = 0;
            Phase1.gameObject.SetActive(true);
            Phase1.Find("Panel_04").gameObject.SetActive(true);

            Phase1.Find("Panel_01").gameObject.SetActive(false);

            Paused = true;
        }
        else if (P1Obj2 == true && P1Obj3 == false)
        {
            Time.timeScale = 0;
            Phase1.gameObject.SetActive(true);
            Phase1.Find("Panel_05").gameObject.SetActive(true);
            Phase1.Find("Panel_01").gameObject.SetActive(false);
            Paused = true;
        }

//************************************************** Phase2 ***********************************************
        else if (P2Obj1 == true && P2Obj2 == false)
        {
            Time.timeScale = 0;

            Phase2.gameObject.SetActive(true);
            Phase2.Find("Panel_09").gameObject.SetActive(true);
            Phase2.Find("Panel_01").gameObject.SetActive(false);
            Phase2.Find("Panel_04").gameObject.SetActive(false);

            Paused = true;
        }
        else if (P2Obj2 == true && P2Obj3 == false)
        {
            Time.timeScale = 0;
            Phase2.gameObject.SetActive(true);
            Phase2.Find("Panel_014").gameObject.SetActive(true);
           
            Phase2.Find("Panel_01").gameObject.SetActive(false);
            Paused = true;
        }
//************************************************** Phase3 ***********************************************
        else if (P3Obj1 == true && P3Obj2 == false)
        {
            Time.timeScale = 0;
            Phase3.gameObject.SetActive(true);

            Phase3.Find("Panel_04").gameObject.SetActive(true);
            Phase3.Find("Panel_01").gameObject.SetActive(false);
            Paused = true;
        }
//************************************************** Phase4 ***********************************************
        else if (P4Obj1 == true && P4Obj2 == false)
        {
            Time.timeScale = 0;
            Phase4.gameObject.SetActive(true);
            Phase4.Find("Panel_Janitor").gameObject.SetActive(true);
            Phase4.Find("Panel_01").gameObject.SetActive(false);
            Paused = true;
        }
        else if (P4Obj2== true && P4Obj3 == false)
        {
            Time.timeScale = 0;
            Phase4.gameObject.SetActive(true);
            Phase4.Find("Panel_P4End").gameObject.SetActive(true);
            Phase4.Find("Panel_01").gameObject.SetActive(false);
            Paused = true;
        }
//************************************************** Phase3 ***********************************************
        else if (P5Obj1 == true && P5Obj2 == false)
        {
            Time.timeScale = 0;
            Phase5.gameObject.SetActive(true);
            Phase5.Find("Panel_04").gameObject.SetActive(true);
          
            Phase5.Find("Panel_01").gameObject.SetActive(false);
            Paused = true;
        }

    }

    // ****************************LEVEL ONE STUFF**************************************

    public bool L1_1;
    public bool L1_2;
    public bool L1_3;


    public void LevelOnePhases()
    {
        if (L1_1 == false && gameController.score < 1500)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L1_1 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(1500);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            ObjList.CreateObjective(1, "Feed 4 customers");
            ObjList.CreateObjective(2, "Purchase an upgrade");
            ObjList.CreateObjective(3, "Throw away spoiled food");

        }

        if (L1_1 == true && L1_2 == false && gameController.score < 3000 && gameController.score >= 1500)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L1_2 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(3000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.LevelOneDesks();

            ObjList.CreateObjective(1, "Feed a hacker");
            ObjList.CreateObjective(2, "Buy a guard");
            ObjList.CreateObjective(3, "Get 2500 Currency");
        }

        if (L1_2 == true && L1_3 == false && gameController.score < 5000 && gameController.score >= 3000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L1_3 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(5000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.LevelOneDesks();


            ObjList.CreateObjective(1, "Use a guard on hacker");
            ObjList.CreateObjective(2, "Serve 8 customers");
            ObjList.CreateObjective(3, "Throw away 4 spoiled food ");
        }
    }


    // ****************************LEVEL TWO STUFF**************************************

    public bool L2_1;
    public bool L2_2;
    public bool L2_3;
    public bool L2_4;
    public bool L2_5;

    public void LevelTwoPhases()
    {
        if (L2_1 == false && gameController.score < 2000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L2_1 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(2000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            ObjList.CreateObjective(1, "Feed 4 customers");
            ObjList.CreateObjective(2, "Purchase an upgrade");
            ObjList.CreateObjective(3, "Throw away spoiled food");

        }

        if (L2_1 == true && L2_2 == false && gameController.score < 4000 && gameController.score >= 2000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L2_2 = true;
            Guard.SetActive(true);

            GameObject.Find("GameController").GetComponent<GameController>().Score1(4000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            ObjList.CreateObjective(1, "Feed a hacker");
            ObjList.CreateObjective(2, "Buy a guard");
            ObjList.CreateObjective(3, "Get 2500 Currency");
        }

        if (L2_2 == true && L2_3 == false && gameController.score < 6000 && gameController.score >= 4000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L2_3 = true;
            FBI.SetActive(true);
            Inspector.SetActive(true);

            GameObject.Find("GameController").GetComponent<GameController>().Score1(6000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.LevelTwoDesks();


            ObjList.CreateObjective(1, "Use an FBI on hacker");
            ObjList.CreateObjective(2, "Serve 8 customers");
            ObjList.CreateObjective(3, "Purchase an FBI ");
        }
        if (L2_3 == true && L2_4 == false && gameController.score < 8000 && gameController.score >= 6000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L2_4 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(8000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];


            ObjList.CreateObjective(1, "Reach 7500 Currency");
            ObjList.CreateObjective(2, "Serve 8 customers");
            ObjList.CreateObjective(3, "Feed 1337 Hacker ");
        }
        if (L2_4 == true && L2_5 == false && gameController.score < 10000 && gameController.score >= 8000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L2_5 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(10000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.LevelTwoDesks();


            ObjList.CreateObjective(1, "Use a guard on hacker");
            ObjList.CreateObjective(2, "Serve 8 customers");
            ObjList.CreateObjective(3, "Feed 1337 Hacker ");
        }
    }


    // ****************************LEVEL THREE STUFF**************************************

    public bool L3_1;
    public bool L3_2;
    public bool L3_3;
    public bool L3_4;
    public bool L3_5;
    public bool L3_6;
    public bool L3_7;
    public bool L3_8;
    public bool L3_9;

    public void LevelThreePhases()
    {
        if (L3_1 == false && gameController.score < 2000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_1 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(2000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            ObjList.CreateObjective(1, "Serve 4 customers");
            ObjList.CreateObjective(2, "Purchase an upgrade");
            ObjList.CreateObjective(3, "");

        }

        if (L3_1 == true && L3_2 == false && gameController.score < 4000 && gameController.score >= 2000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_2 = true;
            Guard.SetActive(true);

            GameObject.Find("GameController").GetComponent<GameController>().Score1(4000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            ObjList.CreateObjective(1, "Get 3000 Currency");
            ObjList.CreateObjective(2, "Purchase a guard");
            ObjList.CreateObjective(3, "");
        }

        if (L3_2 == true && L3_3 == false && gameController.score < 6000 && gameController.score >= 4000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_3 = true;
            FBI.SetActive(true);
            Inspector.SetActive(true);

            GameObject.Find("GameController").GetComponent<GameController>().Score1(6000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.LevelThreeDesks();


            ObjList.CreateObjective(1, "Use FBI on a hacker");
            ObjList.CreateObjective(2, "Serve 8 customers");
            ObjList.CreateObjective(3, "");
        }
        if (L3_3 == true && L3_4 == false && gameController.score < 8000 && gameController.score >= 6000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_4 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(8000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];


            ObjList.CreateObjective(1, "Get 7500 Currency");
            ObjList.CreateObjective(2, "Serve 6 customers");
            ObjList.CreateObjective(3, "");
        }
        if (L3_4 == true && L3_5 == false && gameController.score < 10000 && gameController.score >= 8000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_5 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(10000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.LevelThreeDesks();


            ObjList.CreateObjective(1, "Use a guard on hacker");
            ObjList.CreateObjective(2, "Serve 7 customers");
            ObjList.CreateObjective(3, "");
        }

        if (L3_5 == true && L3_6 == false && gameController.score < 12000 && gameController.score >= 10000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_6 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(12000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            // BlackOut ********************************************** 
            Powwweeeerrrr.SetActive(true);


            ObjList.CreateObjective(1, "Fix Generator");
            ObjList.CreateObjective(2, "Purchase an FBI");
            ObjList.CreateObjective(3, "");
        }

        if (L3_6 == true && L3_7 == false && gameController.score < 14000 && gameController.score >= 12000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_7 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(14000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];


            // New desks***********************************
            deskupgrade.LevelThreeDesks();

            ObjList.CreateObjective(1, "Feed a hacker");
            ObjList.CreateObjective(2, "Feed 1337 hacker");
            ObjList.CreateObjective(3, "");
        }

        if (L3_7 == true && L3_8 == false && gameController.score < 16000 && gameController.score >= 14000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_8 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(16000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            // Flood **********************************
            Flood.SetActive(true);
            PumpButton.SetActive(true);

            ObjList.CreateObjective(1, "Serve 8 customers");
            ObjList.CreateObjective(2, "Purchase an FBI");
            ObjList.CreateObjective(3, "");
        }

        if (L3_8 == true && L3_9 == false && gameController.score < 18000 && gameController.score >= 16000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L3_9 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(18000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            // Last Desks *******************************************  
            deskupgrade.LevelThreeDesks();

            FireForLevel3.SetActive(true);

            ObjList.CreateObjective(1, "Serve 4 customers");
            ObjList.CreateObjective(2, "");
            ObjList.CreateObjective(3, "");


        }
    }

            // ****************************ENDLESS LEVEL STUFF**************************************

    public bool L4_1;
    public bool L4_2;
    public bool L4_3;
    public bool L4_4;
    public bool L4_5;
    public bool L4_6;
    public bool L4_7;
    public bool L4_8;
    public bool L4_9;

    public void Endless()
    {
        if (L4_1 == false && gameController.score < 2000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_1 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(2000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

          //  Debug.Log("Array Size " + ObjList.objectiveText.Length);
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];
         //   Debug.Log("Array Size " + ObjList.objectiveText.Length);

            ObjList.CreateObjective(1, "Serve 4 customers");
            ObjList.CreateObjective(2, "Purchase an upgrade");
            //ObjList.CreateObjective(3, "");

        }

        if (L4_1 == true && L4_2 == false && gameController.score < 4000 && gameController.score >= 2000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_2 = true;
            Guard.SetActive(true);

            GameObject.Find("GameController").GetComponent<GameController>().Score1(4000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            ObjList.CreateObjective(1, "Get 3000 Currency");
            ObjList.CreateObjective(2, "Purchase a guard");
            ObjList.CreateObjective(3, "");
        }

        if (L4_2 == true && L4_3 == false && gameController.score < 6000 && gameController.score >= 4000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_3 = true;
            FBI.SetActive(true);
            Inspector.SetActive(true);

            GameObject.Find("GameController").GetComponent<GameController>().Score1(6000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.EndlessDesks();


            ObjList.CreateObjective(1, "Use FBI on a hacker");
            ObjList.CreateObjective(2, "Serve 8 customers");
            ObjList.CreateObjective(3, "");
        }
        if (L4_3 == true && L4_4 == false && gameController.score < 8000 && gameController.score >= 6000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_4 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(8000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];


            ObjList.CreateObjective(1, "Get 7500 Currency");
            ObjList.CreateObjective(2, "Serve 6 customers");
            ObjList.CreateObjective(3, "");
        }
        if (L4_4 == true && L4_5 == false && gameController.score < 10000 && gameController.score >= 8000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_5 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(10000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            deskupgrade.EndlessDesks();


            ObjList.CreateObjective(1, "Use a guard on hacker");
            ObjList.CreateObjective(2, "Serve 7 customers");
            ObjList.CreateObjective(3, "");
        }

        if (L4_5 == true && L4_6 == false && gameController.score < 12000 && gameController.score >= 10000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_6 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(12000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            // BlackOut ********************************************** 
            Powwweeeerrrr.SetActive(true);


            ObjList.CreateObjective(1, "Fix Generator");
            ObjList.CreateObjective(2, "Purchase an FBI");
            ObjList.CreateObjective(3, "");
        }

        if (L4_6 == true && L4_7 == false && gameController.score < 14000 && gameController.score >= 12000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_7 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(14000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];


            // New desks***********************************
            deskupgrade.EndlessDesks();

            ObjList.CreateObjective(1, "Feed a hacker");
            ObjList.CreateObjective(2, "Feed 1337 hacker");
            ObjList.CreateObjective(3, "");
        }

        if (L4_7 == true && L4_8 == false && gameController.score < 16000 && gameController.score >= 14000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_8 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(16000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            // Flood **********************************
            Flood.SetActive(true);
            PumpButton.SetActive(true);

            ObjList.CreateObjective(1, "Serve 8 customers");
            ObjList.CreateObjective(2, "Purchase an FBI");
            ObjList.CreateObjective(3, "");
        }

        if (L4_8 == true && L4_9 == false && gameController.score < 18000 && gameController.score >= 16000)
        {

            if (ObjList.objectiveText.Length > 0)
            {
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(1);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(2);
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().ResetObjective(3);
            }

            L4_9 = true;

            GameObject.Find("GameController").GetComponent<GameController>().Score1(18000);
            GameObject.Find("GameController").GetComponent<GameController>().UpdateScore();
            GameObject.Find("GameController").GetComponent<GameController>().GainMoney();

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().objectiveText = new string[3];

            // Last Desks *******************************************  
            deskupgrade.EndlessDesks();

            ObjList.CreateObjective(1, "Serve 4 customers");
            ObjList.CreateObjective(2, "");
            ObjList.CreateObjective(3, "");
        }
    }


    /*/ make the debug menu sometime....../*/
    public void Timechanger()
    {
        if (Time.timeScale == 0)
        {
            //Debug.Log("timescale was 0 =" + Time.timeScale);
            if (upgrades.activeInHierarchy == true)
            {
                return;
            }
            else
                Time.timeScale = 1;
        }
        
        else if (Time.timeScale == 1)
        {
            //Debug.Log("timescale was 1 =" + Time.timeScale);
            Time.timeScale = 0;
        }
    }



}
