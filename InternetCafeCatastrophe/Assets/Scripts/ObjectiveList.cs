using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObjectiveList : MonoBehaviour
{
    public Text objList;
    public GameObject ObjectiveListHolder;
    public string[] objectiveText = new string[12];
    private bool[] objectiveComplete;
    public GameController Gcontroller;
    private int Trigger1;
    private int Trigger2;
    private int Trigger3;

    public GameObject[] inspector;
    InspectorAI iAI;

    public GameObject trash1;
    public GameObject trash2;

    //****Phase 1 Bools*******
    public int serve;
    bool score500;
    bool doP1Obj3;
    bool doP1Obj1;
    bool doP1Obj2;

    public bool spawnFood = false;
    //****Phase 2 Bools*******
    bool doP2Obj1;
    bool doP2Obj2;
    bool doP2Obj3;
    bool guardTrigger;
  public  bool guardOnHacker;
    //****Phase 3 Bools*******
    bool doP3Obj1;
    bool doP3Obj2;
    bool doP3Obj3;
    //****Phase 4 Bools*******
    bool doP4Obj1;
    bool doP4Obj2;
    bool doP4Obj3;
    bool fbiTrigger;
    bool janTrigger;
   public bool fbiOnHacker;
    //****Phase 5 Bools*******
    bool doP5Obj1;
    bool doP5Obj2;
    bool doP5Obj3;
    bool genTrigger;
    public bool fbiOnElite;
    //****Phase 6 Bools*******
    bool doP6Obj1;
    bool doP6Obj2;
    bool doP6Obj3;
    //****Phase 7 Bools*******
    bool doP7Obj1;
    bool doP7Obj2;
    bool doP7Obj3;
    bool purchasePump;

    //****Level 1 Bools *******
    bool dolv1obj1;
    bool dolv1obj2;
    bool dolv1obj3;
    bool dolv1obj4;
    bool dolv1obj5;
    bool dolv1obj6;
    bool dolv1obj7;
    bool dolv1obj8;
    bool dolv1obj9;

    bool P1lv1;
   public bool P2lv1;
    public bool P3lv1;

    //****Level 2 Bools *******
    bool dolv2obj1;
    bool dolv2obj2;
    bool dolv2obj3;
    bool dolv2obj4;
    bool dolv2obj5;
    bool dolv2obj6;
    bool dolv2obj7;
    bool dolv2obj8;
    bool dolv2obj9;
    bool dolv2obj10;
    bool dolv2obj11;
    bool dolv2obj12;
    bool dolv2obj13;
    bool dolv2obj14;
    bool dolv2obj15;
    

    bool P1lv2;
    bool P2lv2;
    bool P3lv2;
   public bool P4lv2;
   public bool P5lv2;

    //******Level 3 Bools******
    bool dolv3obj1;
    bool dolv3obj2;
    bool dolv3obj3;
    bool dolv3obj4;
    bool dolv3obj5;
    bool dolv3obj6;
    bool dolv3obj7;
    bool dolv3obj8;
    bool dolv3obj9;
    bool dolv3obj10;
    bool dolv3obj11;
    bool dolv3obj12;
    bool dolv3obj13;
    bool dolv3obj14;
    bool dolv3obj15;
    bool dolv3obj16;
    bool dolv3obj17;

    bool P1lv3;
    bool P2lv3;
    bool P3lv3;
   public bool P4lv3;
   public bool P5lv3;
    bool P6lv3;
    bool P7lv3;
    bool P8lv3;
    bool P9lv3;

    //*******Endless bools*******

    bool dolv4obj1;
    bool dolv4obj2;
    bool dolv4obj3;
    bool dolv4obj4;
    bool dolv4obj5;
    bool dolv4obj6;
    bool dolv4obj7;
    bool dolv4obj8;
    bool dolv4obj9;
    bool dolv4obj10;
    bool dolv4obj11;
    bool dolv4obj12;
    bool dolv4obj13;
    bool dolv4obj14;
    bool dolv4obj15;
    bool dolv4obj16;
    bool dolv4obj17;

    bool P1lv4;
    bool P2lv4;
    bool P3lv4;
   public bool P4lv4;
   public bool P5lv4;
    bool P6lv4;
    bool P7lv4;
    bool P8lv4;
    bool P9lv4;

    [SerializeField]
    AudioClip ObjectiveCompleteSound;

    string SceneName;
    Scene currentScene;

    void Start()
    {
        // Scene references
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;

        objectiveComplete = new bool[objectiveText.Length];
        score500 = false;
        doP1Obj3 = false;
        doP1Obj1 = false;
        doP1Obj2 = false;

        doP2Obj1 = false;
        doP2Obj2 = false;
        doP2Obj3 = false;
        guardTrigger = false;
        guardOnHacker = false;

        doP3Obj1 = false;
        doP3Obj2 = false;
        doP3Obj3 = false;

        doP4Obj1 = false;
        doP4Obj2 = false;
        doP4Obj3 = false;
        fbiTrigger = false;
        janTrigger = false;
        fbiOnHacker = false;

        doP5Obj1 = false;
        doP5Obj2 = false;
        doP5Obj3 = false;
        genTrigger = false;
        fbiOnElite = false;

        doP6Obj1 = false;
        doP6Obj2 = false;
        doP6Obj3 = false;

        doP7Obj1 = false;
        doP7Obj2 = false;
        doP7Obj3 = false;
        purchasePump = false;

        dolv1obj1 = false;
        dolv1obj2 = false;
        dolv1obj3 = false;
        dolv1obj4 = false;
        dolv1obj5 = false;
        dolv1obj6 = false;
        dolv1obj7 = false;
        dolv1obj8 = false;
        dolv1obj9 = false;


        P1lv1 = false;
        P2lv1 = false;
        P3lv1 = false;

        dolv2obj1 = false;
        dolv2obj2 = false;
        dolv2obj3 = false;
        dolv2obj4 = false;
        dolv2obj5 = false;
        dolv2obj6 = false;
        dolv2obj7 = false;
        dolv2obj8 = false;
        dolv2obj9 = false;
        dolv2obj10 = false;
        dolv2obj11 = false;
        dolv2obj12 = false;
        dolv2obj13 = false;
        dolv2obj14 = false;
        dolv2obj15 = false;
        

        P1lv2 = false;
        P2lv2 = false;
        P3lv2 = false;
        P4lv2 = false;
        P5lv2 = false;

        dolv3obj1 = false;
        dolv3obj2 = false;
        dolv3obj3 = false;
        dolv3obj4 = false;
        dolv3obj5 = false;
        dolv3obj6 = false;
        dolv3obj7 = false;
        dolv3obj8 = false;
        dolv3obj9 = false;
        dolv3obj10 = false;
        dolv3obj11 = false;
        dolv3obj12 = false;
        dolv3obj13 = false;
        dolv3obj14 = false;
        dolv3obj15 = false;
        dolv3obj16 = false;
        dolv3obj17 = false;

        P1lv3 = false;
        P2lv3 = false;
        P3lv3 = false;
        P4lv3 = false;
        P5lv3 = false;
        P6lv3 = false;
        P7lv3 = false;
        P8lv3 = false;
        P9lv3 = false;

        dolv4obj1 = false;
        dolv4obj2 = false; 
        dolv4obj3 = false;
        dolv4obj4 = false;
        dolv4obj5 = false;
        dolv4obj6 = false;
        dolv4obj7 = false;
        dolv4obj8 = false;
        dolv4obj9 = false;
        dolv4obj10 = false;
        dolv4obj11 = false;
        dolv4obj12 = false;
        dolv4obj13 = false;
        dolv4obj14 = false;
        dolv4obj15 = false;
        dolv4obj16 = false;
        dolv4obj17 = false;

        P1lv4 = false;
        P2lv4 = false;
        P3lv4 = false;
        P4lv4 = false;
        P5lv4 = false;
        P6lv4 = false;
        P7lv4 = false;
        P8lv4 = false;
        P9lv4 = false; 

    }

    void Update()
    {

        TutorialObjs();
        objList.text = "" ;

        for (int i = 0; i < objectiveText.Length; i++)
        {
            if (objectiveComplete[i] == true)
            {
                objList.text = objList.text + "\n" + (i + 1) + ". " + "<b><color=green>" + objectiveText[i] + "</color></b>";
            }
            else
            {
                objList.text = objList.text + "\n" + (i + 1) + ". " + objectiveText[i];
            }
        }
    }

    public void CreateObjective(int num, string objective)
    {
        objectiveText[num - 1] = objective;
    }

    public void CompleteObjective(int num)
    {
        if (objectiveText[num - 1] != null || objectiveText[num - 1] != "")
        {
            objectiveComplete[num - 1] = true;
        }
    }

    public void ResetObjective(int num)
    {
        if (objectiveText[num - 1] != null || objectiveText[num - 1] != "")
        {
            objectiveComplete[num - 1] = false;
        }
    }

    void TutorialObjs()
    {
        if (SceneName == "ICC_Stage1")
        {

            //********************************************************** Phase 1 **********************************************************************
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P1 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == false)
            {

                if (serve == 4 && doP1Obj2 == false)
                {
                    doP1Obj2 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(80);

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }
                else if (doP1Obj1 == false && spawnFood == true)
                {
                    doP1Obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(80);

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }
                else if (trash1.GetComponent<trash>().spoilobj == true && doP1Obj3 == false && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P1Obj3 == true)
                {
                    CompleteObjective(3);
                    Gcontroller.AddScore(50);
                    doP1Obj3 = true;
                }
                else if (trash2.GetComponent<trash>().spoilobj == true && doP1Obj3 == false && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P1Obj3 == true)
                {
                    CompleteObjective(3);
                    Gcontroller.AddScore(50);
                    doP1Obj3 = true;
                }
                if (doP1Obj1 == true && doP1Obj2 == true && doP1Obj3 == true)
                {
                    Gcontroller.score = 2000;
                }

            }
            //********************************************************** Phase 2 **********************************************************************
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == false)
            {
                if (GameObject.Find("Desks").GetComponent<Upgrades>().FoodPrepButton.GetComponentInChildren<Text>().text == "FoodPrep 2 - " + "2500" && doP2Obj1 == false ||
                    GameObject.Find("Desks").GetComponent<Upgrades>().FoodPriceButton.GetComponentInChildren<Text>().text == "FoodPrice 2 - " + "2000" && doP2Obj1 == false ||
                    GameObject.Find("Desks").GetComponent<Upgrades>().FoodSelectionButton.GetComponentInChildren<Text>().text == "FoodSelection 2 - " + "1100" && doP2Obj1 == false)
                {
                    CompleteObjective(1);
                    Gcontroller.AddScore(50);
                    doP2Obj1 = true;

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }
                else if (guardTrigger == true && guardOnHacker == true && doP2Obj2 == false)
                {
                    doP2Obj2 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(200);
                    guardOnHacker = false;

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }
                if (doP2Obj1 == true && doP2Obj2 == true && doP2Obj3 == true)
                {
                    Gcontroller.score = 4000;
                }
            }
            //********************************************************** Phase 3 **********************************************************************
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P4 == false)
            {
                if (GameObject.Find("TrashCans").GetComponent<TrashCounter>().TrashComplete == true && doP3Obj1 == false)
                {
                    doP3Obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(200);

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }

                inspector = GameObject.FindGameObjectsWithTag("Inspector");


                //******************** Inspector complete needed
                if (inspector.Length > 0)
                {

                    foreach (GameObject Inspector in inspector)
                    {
                        iAI = Inspector.GetComponent<InspectorAI>();
                        if (iAI.trashless == true && doP3Obj2 == false)
                        {
                            doP3Obj2 = true;
                            CompleteObjective(2);
                            Gcontroller.AddScore(250);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                if (doP3Obj1 == true && doP3Obj2 == true)
                {
                    Gcontroller.score = 6000;
                }
            }
            //********************************************************** Phase 4 **********************************************************************
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P4 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P5 == false)
            {
                if (fbiTrigger == true && doP4Obj1 == false)
                {
                    doP4Obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(900);

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }
                else if (fbiOnHacker == true && doP4Obj3 == false)
                {
                    doP4Obj3 = true;
                    CompleteObjective(3);
                    Gcontroller.AddScore(80);
                }
                // Purchase Janitor upgrade

                if (janTrigger == true && doP4Obj2 == false)
                {
                    doP4Obj2 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(500);

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }
                if (doP4Obj1 == true && doP4Obj2 == true && doP4Obj3 == true)
                {
                    Gcontroller.score = 8000;
                }




            }
            //********************************************************** Phase 5 **********************************************************************
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P5 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == false)
            {

                // Feed an elite hacker****************** Found in NavAgent Script
                if (fbiOnElite == true && doP5Obj1 == false)
                {
                    doP5Obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(80);

                    GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PanelSelect();

                }


                if (doP5Obj1 == true && doP5Obj2 == true)
                {
                    Gcontroller.score = 10000;
                }

                //Feed Elite Hacker**************
            }
            //********************************************************** Phase 6 **********************************************************************
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == false)
            {
                if (genTrigger == true && doP6Obj1 == false)
                {
                    doP6Obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(100);
                }

                if (doP6Obj1 == true)
                {
                    Gcontroller.score = 12000;
                }

            }

            //********************************************************** Phase 7 **********************************************************************
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == true)
            {
                if (purchasePump == true && doP7Obj1 == false)
                {
                    doP7Obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(50);
                }

                if (doP7Obj1 == true)
                {
                    Gcontroller.score = 14000;
                }
            }
        }
        else if (SceneName == "LevelOne")
        {
            if (P1lv1 == false)
            {
                if (serve == 4 && dolv1obj1 == false)
                {
                    dolv1obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(80);
                    serve = 0;
                }
                else if (GameObject.Find("Desks").GetComponent<Upgrades>().FoodPrepButton.GetComponentInChildren<Text>().text == "FoodPrep 2 - " + "2500" && dolv1obj2 == false ||
                    GameObject.Find("Desks").GetComponent<Upgrades>().FoodPriceButton.GetComponentInChildren<Text>().text == "FoodPrice 2 - " + "2000" && dolv1obj2 == false)
                {
                    CompleteObjective(2);
                    Gcontroller.AddScore(50);
                    dolv1obj2 = true;
                }
                else if (trash1.GetComponent<trash>().spoilobj == true && dolv1obj3 == false)
                {
                    CompleteObjective(3);
                    Gcontroller.AddScore(50);
                    dolv1obj3 = true;
                }
                else if (trash2.GetComponent<trash>().spoilobj == true && dolv1obj3 == false)
                {
                    CompleteObjective(3);
                    Gcontroller.AddScore(50);
                    dolv1obj3 = true;
                }
                if (Gcontroller.score >= 1500 && Gcontroller.score < 3000)
                {
                    P1lv1 = true;
                }
            }
            if (P2lv1 == false && P1lv1 == true)
            {


                if (Gcontroller.score >= 2500 && dolv1obj6 == false)
                {
                    dolv1obj6 = true;
                    CompleteObjective(3);
                    Gcontroller.AddScore(200);
                }
                else if (guardTrigger == true && dolv1obj5 == false)
                {
                    dolv1obj5 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(200);
                }
                if (Gcontroller.score >= 3000 && Gcontroller.score <= 5000)
                {
                    P2lv1 = true;
                    serve = 0;
                }
            }
            if (P3lv1 == false && P2lv1 == true)
            {

                if (guardOnHacker == true && dolv1obj7 == false)
                {
                    dolv1obj7 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(80);
                    guardOnHacker = false;
                }
                else if (serve == 8 && dolv1obj8 == false)
                {
                    dolv1obj8 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(80);
                    serve = 0;
                }
                else if (GameObject.Find("TrashCans").GetComponent<TrashCounter>().TrashComplete == true && dolv1obj9 == false)
                {
                    dolv1obj9 = true;
                    CompleteObjective(3);
                    Gcontroller.AddScore(80);
                }
            }
        }
        else if (SceneName == "LevelTwo")
        {
            if (P1lv2 == false)
            {
                if (serve == 4 && dolv2obj1 == false)
                {
                    dolv2obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                else if (GameObject.Find("Desks").GetComponent<Upgrades>().FoodPrepButton.GetComponentInChildren<Text>().text == "FoodPrep 2 - " + "2500" && dolv2obj2 == false ||
                    GameObject.Find("Desks").GetComponent<Upgrades>().FoodPriceButton.GetComponentInChildren<Text>().text == "FoodPrice 2 - " + "2000" && dolv2obj2 == false)
                {
                    CompleteObjective(2);
                    Gcontroller.AddScore(150);
                    dolv2obj2 = true;
                }
                else if (GameObject.Find("TrashCans").GetComponent<TrashCounter>().TrashComplete == true && dolv2obj3 == false)
                {
                    CompleteObjective(3);
                    Gcontroller.AddScore(150);
                    dolv2obj3 = true;
                }
                if (Gcontroller.score >= 2000 && Gcontroller.score < 4000)
                {
                    P1lv2 = true;
                }
            }
            if (P2lv2 == false && P1lv2 == true)
            {
                if (Gcontroller.score >= 2500 && dolv2obj6 == false)
                {
                    dolv2obj6 = true;
                    CompleteObjective(3);
                    Gcontroller.AddScore(350);
                }
                else if (guardTrigger == true && dolv2obj5 == false)
                {
                    dolv2obj5 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(500);
                }
                if (Gcontroller.score >= 4000 && Gcontroller.score <= 6000)
                {
                    P2lv2 = true;
                }
            }
            if (P3lv2 == false && P2lv2 == true)
            {

                if (fbiOnHacker == true && dolv2obj7 == false)
                {
                    dolv2obj7 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);
                }
                else if (serve == 8 && dolv2obj8 == false)
                {
                    dolv2obj8 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                else if (fbiTrigger == true && dolv2obj9 == false)
                {
                    dolv2obj9 = true;
                    CompleteObjective(3);
                    Gcontroller.AddScore(240);
                }
                if (Gcontroller.score >= 6000 && Gcontroller.score <= 8000)
                {
                    P3lv2 = true;
                }
            }
            if (P4lv2 == false && P3lv2 == true)
            {

                if (Gcontroller.score >= 7500 && dolv2obj10 == false)
                {
                    dolv2obj10 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(350);
                }
                else if (serve == 8 && dolv2obj11 == false)
                {
                    dolv2obj11 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                if (Gcontroller.score >= 8000 && Gcontroller.score <= 10000)
                {
                    P4lv2 = true;
                }
            }
            if (P5lv2 == false && P4lv2 == true)
            {

                if (guardOnHacker == true && dolv2obj13 == false)
                {
                    dolv2obj13 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(250);
                    guardOnHacker = false;
                }
                else if (serve == 8 && dolv2obj14 == false)
                {
                    dolv2obj14 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                if (Gcontroller.score >= 10000 && Gcontroller.score <= 12000)
                {
                    P5lv2 = true;
                }
            }

        }

        else if (SceneName == "LevelThree")
        {
            if (P1lv3 == false)
            {
                if (serve == 4 && dolv3obj1 == false)
                {
                    dolv3obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                else if (GameObject.Find("Desks").GetComponent<Upgrades>().FoodPrepButton.GetComponentInChildren<Text>().text == "FoodPrep 2 - " + "2500" && dolv3obj2 == false ||
                    GameObject.Find("Desks").GetComponent<Upgrades>().FoodPriceButton.GetComponentInChildren<Text>().text == "FoodPrice 2 - " + "2000" && dolv3obj2 == false)
                {
                    CompleteObjective(2);
                    Gcontroller.AddScore(800);
                    dolv3obj2 = true;
                }
                if (Gcontroller.score >= 2000 && Gcontroller.score < 4000)
                {
                    P1lv3 = true;
                }
            }
            if (P2lv3 == false && P1lv3 == true)
            {
                if (Gcontroller.score >= 3000 && dolv3obj3 == false)
                {
                    dolv3obj3 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(200);
                }
                else if (guardTrigger == true && dolv3obj4 == false)
                {
                    dolv3obj4 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(500);
                }
                if (Gcontroller.score >= 4000 && Gcontroller.score < 6000)
                {
                    P2lv3 = true;
                }
            }
            if (P3lv3 == false && P2lv3 == true)
            {

                if (fbiOnHacker == true && dolv3obj5 == false)
                {
                    dolv3obj5 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(1250);
                }
                else if (serve == 8 && dolv3obj6 == false)
                {
                    dolv3obj6 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }

                if (Gcontroller.score >= 6000 && Gcontroller.score < 8000)
                {
                    P3lv3 = true;
                }
            }
            if (P4lv3 == false && P3lv3 == true)
            {

                if (Gcontroller.score >= 7500 && dolv3obj7 == false)
                {
                    dolv3obj7 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(200);
                }
                else if (serve == 6 && dolv3obj8 == false)
                {
                    dolv3obj8 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                if (Gcontroller.score >= 8000 && Gcontroller.score < 10000)
                {
                    P4lv3 = true;
                }
            }
            if (P5lv3 == false && P4lv3 == true)
            {

                if (guardOnHacker == true && dolv3obj9 == false)
                {
                    dolv3obj9 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(500);
                    guardOnHacker = false;
                }
                else if (serve == 7 && dolv3obj10 == false)
                {
                    dolv3obj10 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                if (Gcontroller.score >= 10000 && Gcontroller.score < 12000)
                {
                    P5lv3 = true;
                }
            }
            if (P6lv3 == false && P5lv3 == true)
            {

                if (genTrigger == true && dolv3obj11 == false)
                {
                    dolv3obj11 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(250);
                }
                else if (fbiTrigger == true && dolv3obj12 == false)
                {
                    fbiTrigger = false;
                    dolv3obj12 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(1250);
                  
                }
                if (Gcontroller.score >= 12000 && Gcontroller.score < 14000)
                {
                    P6lv3 = true;
                }
            }
            if (P7lv3 == false && P6lv3 == true)
            {
                if (Gcontroller.score >= 14000 && Gcontroller.score < 16000)
                {
                    P7lv3 = true;
                }
            }
            if (P8lv3 == false && P7lv3 == true)
            {

                if (serve == 8 && dolv3obj15 == false)
                {
                    dolv3obj15 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                else if (fbiTrigger == true && dolv3obj16 == false)
                {
                    fbiTrigger = false;
                    dolv3obj16 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(1250);

                }
                if (Gcontroller.score >= 16000 && Gcontroller.score < 18000)
                {
                    P8lv3 = true;
                }
            }
            if (P9lv3 == false && P8lv3 == true)
            {

                if (serve == 4 && dolv3obj17 == false)
                {
                    dolv3obj17 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);

                }
          
            }
        }
        else if (SceneName == "Endless")
        {
            if (P1lv4 == false)
            {
                if (serve == 4 && dolv4obj1 == false)
                {
                    dolv4obj1 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                else if (GameObject.Find("Desks").GetComponent<Upgrades>().FoodPrepButton.GetComponentInChildren<Text>().text == "FoodPrep 2 - " + "2500" && dolv4obj2 == false ||
                    GameObject.Find("Desks").GetComponent<Upgrades>().FoodPriceButton.GetComponentInChildren<Text>().text == "FoodPrice 2 - " + "2000" && dolv4obj2 == false)
                {
                    CompleteObjective(2);
                    Gcontroller.AddScore(800);
                    dolv4obj2 = true;
                }
                if (Gcontroller.score >= 2000 && Gcontroller.score < 4000)
                {
                    P1lv4 = true;
                }
            }
            if (P2lv4 == false && P1lv4 == true)
            {
                if (Gcontroller.score >= 3000 && dolv4obj3 == false)
                {
                    dolv4obj3 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(200);
                }
                else if (guardTrigger == true && dolv4obj4 == false)
                {
                    dolv4obj4 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(500);
                }
                if (Gcontroller.score >= 4000 && Gcontroller.score < 6000)
                {
                    P2lv4 = true;
                }
            }
            if (P3lv4 == false && P2lv4 == true)
            {

                if (fbiOnHacker == true && dolv4obj5 == false)
                {
                    dolv4obj5 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(1250);
                }
                else if (serve == 8 && dolv4obj6 == false)
                {
                    dolv4obj6 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }

                if (Gcontroller.score >= 6000 && Gcontroller.score < 8000)
                {
                    P3lv4 = true;
                }
            }
            if (P4lv4 == false && P3lv4 == true)
            {

                if (Gcontroller.score >= 7500 && dolv4obj7 == false)
                {
                    dolv4obj7 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(200);
                }
                else if (serve == 6 && dolv4obj8 == false)
                {
                    dolv4obj8 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                if (Gcontroller.score >= 8000 && Gcontroller.score < 10000)
                {
                    P4lv4 = true;
                }
            }
            if (P5lv4 == false && P4lv4 == true)
            {

                if (guardOnHacker == true && dolv4obj9 == false)
                {
                    dolv4obj9 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(500);
                    guardOnHacker = false;
                }
                else if (serve == 7 && dolv4obj10 == false)
                {
                    dolv4obj10 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                if (Gcontroller.score >= 10000 && Gcontroller.score < 12000)
                {
                    P5lv4 = true;
                }
            }
            if (P6lv4 == false && P5lv4 == true)
            {

                if (genTrigger == true && dolv4obj11 == false)
                {
                    dolv4obj11 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(250);
                }
                else if (fbiTrigger == true && dolv4obj12 == false)
                {
                    fbiTrigger = false;
                    dolv4obj12 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(1250);

                }
                if (Gcontroller.score >= 12000 && Gcontroller.score < 14000)
                {
                    P6lv4 = true;
                }
            }
            if (P7lv4 == false && P6lv4 == true)
            {
                if (Gcontroller.score >= 14000 && Gcontroller.score < 16000)
                {
                    P7lv4 = true;
                }
            }
            if (P8lv4 == false && P7lv4 == true)
            {

                if (serve == 8 && dolv4obj15 == false)
                {
                    dolv4obj15 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);
                    serve = 0;
                }
                else if (fbiTrigger == true && dolv4obj16 == false)
                {
                    fbiTrigger = false;
                    dolv4obj16 = true;
                    CompleteObjective(2);
                    Gcontroller.AddScore(1250);

                }
                if (Gcontroller.score >= 16000 && Gcontroller.score < 18000)
                {
                    P8lv4 = true;
                }
            }
            if (P9lv4 == false && P8lv4 == true)
            {

                if (serve == 4 && dolv4obj17 == false)
                {
                    dolv4obj17 = true;
                    CompleteObjective(1);
                    Gcontroller.AddScore(240);

                    objectiveText = new string[0];

                }

            }
        }

    }


    public void GuardTrigger()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (doP2Obj2 == false)
            {
                guardTrigger = true;
            }
        }
        else if(SceneName == "LevelOne")
        {
            if(dolv1obj5 == false)
            {
                guardTrigger = true;
            }
        }
        else if (SceneName == "LevelTwo")
        {
            if (dolv1obj5 == false)
            {
                guardTrigger = true;
            }
        }
        else if (SceneName == "LevelThree")
        {
            if (dolv3obj4 == false)
            {
                guardTrigger = true;
            }
        }
        else if (SceneName == "Endless")
        {
            if (dolv4obj4 == false)
            {
                guardTrigger = true;
            }
        }
        
    }

    public void HackerObj()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (doP2Obj3 == false)
            {
                doP2Obj3 = true;
                CompleteObjective(3);
                Gcontroller.AddScore(100);
            }
            else
            {
                return;
            }
        }
        else if (SceneName == "LevelOne")
        {
            if(dolv1obj4 == false)
            {
                dolv1obj4 = true;
                CompleteObjective(1);
                Gcontroller.AddScore(100);
            }
            else
            {
                return;
            }
        }
        else if (SceneName == "LevelTwo")
        {
            if (dolv2obj4 == false)
            {
                dolv2obj4 = true;
                CompleteObjective(1);
                Gcontroller.AddScore(100);
            }
            else
            {
                return;
            }
        }
        else if (SceneName == "LevelThree")
        {
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_7 == true && dolv3obj13 == false)
            {
                dolv3obj13 = true;
                CompleteObjective(1);
                Gcontroller.AddScore(100);
            }
            else
            {
                return;
            }
        }

        else if (SceneName == "Endless")
        {
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_7 == true && dolv4obj13 == false)
            {
                dolv4obj13 = true;
                CompleteObjective(1);
                Gcontroller.AddScore(100);
            }
            else
            {
                return;
            }
        }
    }

    public void FBITrigger()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (doP4Obj1 == false)
            {
                fbiTrigger = true;
            }
        }
        if (SceneName == "LevelTwo")
        {
            if (dolv2obj9 == false)
            {
                fbiTrigger = true;
            }
        }
        if (SceneName == "LevelThree")
        {
            if (dolv3obj12 == false)
            {
                fbiTrigger = true;
            }
        }
        if (SceneName == "LevelThree")
        {
            if (dolv3obj16 == false)
            {
                fbiTrigger = true;
            }
        }
        if (SceneName == "Endless")
        {
            if (dolv4obj12 == false)
            {
                fbiTrigger = true;
            }
        }
        if(SceneName == "Endless")
        {
            if(dolv4obj16 == false)
            {
                fbiTrigger = true;
            }
        }
    }

    public void EliteHackerObj()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (doP5Obj2 == false)
            {

                doP5Obj2 = true;
                CompleteObjective(2);
                Gcontroller.AddScore(200);
            }
            else
            {
                return;
            }
        }
        if (SceneName == "LevelTwo")
        {
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_4 == true && dolv2obj12 == false && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_5 == false)
            {

                dolv2obj12 = true;
                CompleteObjective(3);
                Gcontroller.AddScore(200);
            }

            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_5 == true && dolv2obj15 == false)
            {

                dolv2obj15 = true;
                CompleteObjective(3);
                Gcontroller.AddScore(200);
            }
            else
            {
                return;
            }
        }
        if (SceneName == "LevelThree")
        {
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_7 == true &&  dolv3obj14 == false)
            {

                dolv3obj14 = true;
                CompleteObjective(2);
                Gcontroller.AddScore(200);
            }
            else
            {
                return;
            }
        }
        if (SceneName == "Endless")
        {
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_7 == true && dolv4obj14 == false)
            {

                dolv4obj14 = true;
                CompleteObjective(2);
                Gcontroller.AddScore(200);
            }
            else
            {
                return;
            }
        }
    }

    public void GeneratorTrigger()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (doP6Obj1 == false)
            {
                genTrigger = true;

            }
        }
        if (SceneName == "LevelThree")
        {
        //    Debug.Log("LevelThree obj complete");
            if (dolv3obj13 == false)
            {
              //  Debug.Log("obj13 false");
                genTrigger = true;

            }
        }
        if(SceneName == "Endless")
        {
            if(dolv4obj11 == false)
            {
                genTrigger = true;
            }
        }
    }
    public void JanTrigger()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (doP4Obj2 == false)
            {
                janTrigger = true;

            }
        }
    }

    public void PurchasePump()
    {
        if (SceneName == "ICC_Stage1")
        {
            if (purchasePump == false)
            {
                purchasePump = true;

            }
        }
    }
}


