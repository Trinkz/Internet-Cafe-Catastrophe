using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGen : MonoBehaviour {
    public GameObject Food;
    public float RefreshTimer = 3;
    public float Timer;
    float timer;
    public float spawnTime = 15;
    Vector3 Plate;
    Vector3 Plate2;
    public GameObject plate;
    public GameObject plate2;

    FoodManager foodManage;
    GameObject foodGen;

    FireScript fScript;
    Blackout blackOut;

    public ParticleSystem madeFood;

    bool doOnce;

    // Food Bools
    public bool Bagel = false;
    public bool Smoothie = false;
    public bool Soda = false;
    public bool Salad = false;
    public bool Burger = false;
    public bool Juice = false;
    public bool Coffee = false;
    public bool Soup = false;


    // Find Upgrades
    GameObject Desks;
    Upgrades upgrade;

    public bool timeStart;

    // Use this for initialization
    void Start()
    {
        fScript = GameObject.Find("FireHolder").GetComponent<FireScript>();
        if(GameObject.Find("Blackout holder") != null)
        {
            blackOut = GameObject.Find("Blackout holder").GetComponent<Blackout>();
        }

        doOnce = false;

        spawnTime = 15;
        Desks = GameObject.Find("Desks");
        upgrade = Desks.GetComponent<Upgrades>();

        foodGen = GameObject.Find("Food Gens");
        foodManage = foodGen.GetComponent<FoodManager>();

        Timer = RefreshTimer;
        Plate = plate.transform.position;
        Plate2 = plate2.transform.position;

        madeFood.Stop();
        //FoodSelect();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (timeStart == true)
        {
            timer += Time.deltaTime;
            SpawnFood();
            madeFood.Stop();
        }

        if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == true && doOnce == false)
        {
            doOnce = true;
            blackOut = GameObject.Find("Blackout holder").GetComponent<Blackout>();
        }

        //if (timer >= spawnTime)
        //{
           // FoodSelect();
         //   timer = 0;
          
       // }

        
    }

    private void OnMouseDown()
    {
       // Debug.Log(gameObject.name);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        //FoodType();
        InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
    }

    public void SpawnFood()
    {
            if (timer >= spawnTime)
            {
                Instantiate(Food, Plate, Quaternion.identity);
                madeFood.Play();
                timer = 0;
                timeStart = false;
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().spawnFood = true;
                GameObject.Find("Food Gens").GetComponent<AudioSource>().Play();
        }
    }

    public void StartTime()
    {
        timeStart = true;
    }

    public void SpawnFood2()
    {
        Instantiate(Food, Plate2, Quaternion.identity);
        InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
    }

  /*void FoodRefreshRate()
    {

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            CancelInvoke("FoodRefreshRate");
            Timer = RefreshTimer;
        }
    }*/

    void FoodType()
    {
        if (foodManage.gameObject.name == "Bagel Gen" && Bagel == false)
        {
            if (upgrade.upgradeCounterSpace1 == true)
            {
                Bagel = true;
                SpawnFood();
            }
            if (upgrade.upgradeHotPlate2 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }

        }
        else if (gameObject.name == "Burger Gen" && Burger == false)
        {
            if (upgrade.upgradeCounterSpace2 == true)
            {
                Burger = true;
                SpawnFood();
            }
            if (upgrade.upgradeHotPlate3 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }

        }
        else if (foodManage.gameObject.name == "Coffee Gen" && Coffee == false)
        {
            Coffee = true;
            SpawnFood();

            if (upgrade.upgradeHotPlate1 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }

        }
        else if (foodManage.gameObject.name == "Juice Gen" && Juice == false)
        {

            Juice = true;
            SpawnFood();

            if (upgrade.upgradeHotPlate1 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }
        }
        else if (foodManage.gameObject.name == "Salad Gen" && Salad == false)
        {
            Salad = true;
            SpawnFood();

            if (upgrade.upgradeHotPlate1 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }
        }
        else if (gameObject.name == "Smoothie Gen" && Smoothie == false)
        {
            if (upgrade.upgradeCounterSpace2 == true)
            {
                Smoothie = true;
                SpawnFood();
            }
        
            if (upgrade.upgradeHotPlate3 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }

        }
        else if (gameObject.name == "Soda Gen" && Soda == false)
        {
            if (upgrade.upgradeCounterSpace1 == true)
            {
                Soda = true;
                SpawnFood();
            }
            if (upgrade.upgradeHotPlate2 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }

        }
        else if (foodManage.gameObject.name == "Soup Gen" && Soup == false)
        {
                Soup = true;
                SpawnFood();
            
            if (upgrade.upgradeHotPlate1 == true)
            {
                SpawnFood2();
            }
            else
            {
                InvokeRepeating("FoodRefreshRate", 0.1f, .01f);
            }
        }
        else
        {
            return;
        }
    }
   public void FoodSelect()
    {
        foreach (GameObject food in foodManage.food)
        {
            if (gameObject.name == "Soup Gen" && Soup == false)
            {
                //Debug.Log(gameObject.name);
                SpawnFood();
                Soup = true;
            }
            if (gameObject.name == "Soda Gen" && Soda == false)
            {
                if (upgrade.upgradeCounterSpace1 == true)
                {
                    Soda = true;
                    SpawnFood();
                }
            }
            if (gameObject.name == "Smoothie Gen" && Smoothie == false)
            {
                if (upgrade.upgradeCounterSpace2 == true)
                {
                    Smoothie = true;
                    SpawnFood();
                }
            }
            if (gameObject.name == "Coffee Gen" && Coffee == false)
            {
                    Coffee = true;
                    SpawnFood();
            }
            if (gameObject.name == "Juice Gen" && Juice == false)
            {
                    Juice = true;
                    SpawnFood();
            }
            if (gameObject.name == "Bagel Gen" && Bagel == false)
            {
                if (upgrade.upgradeCounterSpace1 == true)
                {
                    Bagel = true;
                    SpawnFood();
                }
            }
            if (gameObject.name == "Burger Gen" && Burger == false)
            {
                if (upgrade.upgradeCounterSpace2 == true)
                {
                    Burger = true;
                    SpawnFood();
                }
            }
            if (gameObject.name == "Salad Gen" && Salad == false)
            {
                    Salad = true;
                    SpawnFood();
            }
        }
    }

    public void JuiceSpawn()
    {
        if(blackOut != null)
        {
            if (Juice == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-13);
            }
        }
        else
        {
            if (Juice == false && timeStart == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-13);
            }
        }


    }
    public void SaladSpawn()
    {
        if (blackOut != null)
        {
            if (Salad == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-16);
            }
        }
        else
        {
            if (Salad == false && timeStart == false  && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-16);
            }
        }
    }
    public void CoffeeSpawn()
    {
        if (blackOut != null)
        {
            if (Coffee == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-26);
            }
        }
        else
        {
            if (Coffee == false && timeStart == false  && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-26);
            }
        }
    }
    public void SoupSpawn()
    {
        if(blackOut != null)
        {
            if (Soup == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-23);
            }
        }
        else
        {
            if (Soup == false && timeStart == false  && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-23);
            }
        }
    }
    public void SodaSpawn()
    {
        if (blackOut != null)
        {
            if (Soda == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-29);
            }
        }
        else
        {
            if (Soda == false && timeStart == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-29);
            }
        }
    }
    public void SmoothieSpawn()
    {
        if (blackOut != null)
        {
            if (Smoothie == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-39);
            }
        }
        else
        {
            if (Smoothie == false && timeStart == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-39);
            }
        }
    }
    public void BagelSpawn()
    {
        if (blackOut != null)
        {
            if (Bagel == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-26);
            }
        }
        else
        {
            if (Bagel == false && timeStart == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-26);
            }
        }
    }
    public void BurgerSpawn()
    {
        if (blackOut != null)
        {
            if (Burger == false && timeStart == false && blackOut.bOut == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-42);
            }
        }
        else
        {
            if (Burger == false && timeStart == false && fScript.fireOut == false)
            {
                timeStart = true;
                GameObject.Find("GameController").GetComponent<GameController>().AddScore(-42);
            }
        }
    }
}
