using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerHackerGenerator : MonoBehaviour {

    [SerializeField] float TimeMin = 1;
    [SerializeField] float TimeMix = 4;
    private float TimeLimit = 2;
    private float Timer = 0;
    public GameObject customer;
    public GameObject hacker;
    public GameObject eliteHacker;
    GameObject GC;
    GameController score;
    int range;

    string SceneName;
    Scene currentScene;


    // Use this for initialization
    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
        GC = GameObject.Find("GameController");
        score = GC.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateTimer();	
	}

    void updateTimer()
    {
        Timer += Time.deltaTime;

        if (Timer >= TimeLimit)
        {
            TimeLimit = Random.Range(TimeMin, TimeMix);
            Timer = 0;
            //doSpawn();
            doSpawn1();
        }

    }

    void doSpawn()
    {
        
        range = Random.Range(1, 101);
       // Debug.Log("Random is " + range);

        if(range <= 60)
        {
           
            Instantiate(customer, transform.position, transform.rotation);
        }

        else if(range > 60 && range <= 90 && score.score >= 1000)
        {
            Instantiate(hacker, transform.position, transform.rotation);
        }

        else if(range > 90 && score.score >= 3000)
        {
            Instantiate(eliteHacker, transform.position, transform.rotation);
        }
    }

    void doSpawn1()
    {

        range = Random.Range(1, 101);

        if (SceneName == "ICC_Stage1")
        {


            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P1 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == false)
            {
                Instantiate(customer, transform.position, transform.rotation);
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == false)
            {
                if (range <= 50)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 51 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P4 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P4 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P5 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P5 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == false)
            {
                if (range <= 74)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 75 && range <= 79)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
                else if (range >= 80)
                {
                    Instantiate(eliteHacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == false && GameObject.Find("Blackout holder").GetComponent<Blackout>().StopCustomersFromComingIn == false)
            {
                if (range <= 83)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 84 && range <= 94)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
                else if (range >= 95)
                {
                    Instantiate(eliteHacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == true && GameObject.Find("Blackout holder").GetComponent<Blackout>().StopCustomersFromComingIn == false && GameObject.Find("FireHolder").GetComponent<FireScript>().Fire.activeInHierarchy == false)
            {
                if (range <= 83)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 84 && range <= 94)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
                else if (range >= 95)
                {
                    Instantiate(eliteHacker, transform.position, transform.rotation);
                }
            }

            else

                return;
        }
        //****************************** LEVEL ONE STUFF *******************************************************
        else if(SceneName == "LevelOne")
        {

            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_1 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_2 == false)
            {
                Instantiate(customer, transform.position, transform.rotation);
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_3 == false)
            {
                if (range <= 85)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 86 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_3 == true)
            {
                if (range <= 79)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 80 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
        }

        //****************************** LEVEL Two STUFF *******************************************************
        else if (SceneName == "LevelTwo")
        {

            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_1 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_2 == false)
            {
                Instantiate(customer, transform.position, transform.rotation);
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_3 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_3 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_4 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_4 == true)
            {
                if (range <= 83)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 84 && range <= 94)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
                else if (range >= 95 && range <= 100)
                {
                    Instantiate(eliteHacker, transform.position, transform.rotation);
                }
            }
        }

        //****************************** LEVEL Three STUFF *******************************************************
        else if (SceneName == "LevelThree")
        {

            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_1 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_2 == false)
            {
                Instantiate(customer, transform.position, transform.rotation);
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_3 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_3 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_4 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_4 == true)
            {
                if (range <= 83)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 84 && range <= 94)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
                else if (range >= 95 && range <= 100)
                {
                    Instantiate(eliteHacker, transform.position, transform.rotation);
                }
            }
        }

        //****************************** Endless Level Stuff *******************************************************
        else if (SceneName == "Endless")
        {

            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_1 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_2 == false)
            {
                Instantiate(customer, transform.position, transform.rotation);
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_2 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_3 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }

            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_3 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_4 == false)
            {
                if (range <= 89)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 90 && range <= 100)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
            }
            else if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_4 == true)
            {
                if (range <= 83)
                {

                    Instantiate(customer, transform.position, transform.rotation);
                }

                else if (range >= 84 && range <= 94)
                {
                    Instantiate(hacker, transform.position, transform.rotation);
                }
                else if (range >= 95 && range <= 100)
                {
                    Instantiate(eliteHacker, transform.position, transform.rotation);
                }
            }
        }
    }    

}
