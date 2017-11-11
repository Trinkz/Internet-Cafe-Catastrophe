using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject Fire;

    public GameObject flood;

    public bool fireOut;

    public float FireTimer;

    public bool FireActive = false;

    float blackout = 300000000;

    int RangeForFire;

    float soup;
    float burger;
    float coffee;
    float juice;
    float salad;
    float smoothie;
    float soda;
    float bagel;

    float TimerFireActive;

    // Use this for initialization
    void Start()
    {
        /*
        soup = GameObject.Find("Soup Gen").GetComponent<FoodGen>().spawnTime;
        burger = GameObject.Find("Burger Gen").GetComponent<FoodGen>().spawnTime;
        coffee = GameObject.Find("Coffee Gen").GetComponent<FoodGen>().spawnTime;
        juice = GameObject.Find("Juice Gen").GetComponent<FoodGen>().spawnTime;
        salad = GameObject.Find("Salad Gen").GetComponent<FoodGen>().spawnTime;
        smoothie = GameObject.Find("Smoothie Gen").GetComponent<FoodGen>().spawnTime;
        soda = GameObject.Find("Soda Gen").GetComponent<FoodGen>().spawnTime;
        bagel = GameObject.Find("Bagel Gen").GetComponent<FoodGen>().spawnTime;
        */
        FireActive = false;

        fireOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fire.activeInHierarchy == false)
        {
            FireTimer += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            FireTimer = 100;
        }

        else if (Fire.activeInHierarchy == true)
        {
            TimerFireActive += Time.deltaTime;
            if(TimerFireActive >= 5)
            {
                GameObject.Find("GameController").GetComponent<GameController>().score -= 500;
                TimerFireActive = 0;

            }

        }
        

        FireOccur();
    }


   public void FireOccur()
    {
        if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == true || GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_9 == true || GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_9 == true)
        {

            if (Fire.activeInHierarchy == false && FireActive == false)
            {
               // Debug.Log("random range =" + RangeForFire);
                RangeForFire = Random.Range(50, 70);
                FireActive = true;
                
            }
            if (FireTimer >= RangeForFire)
            {
                Fire.SetActive(true);
                //GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBlackOut();

                FireTimer = 0f;
                FireActive = false;
                /*
                GameObject.Find("Soup Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Burger Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Coffee Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Juice Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Salad Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Smoothie Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Soda Gen").GetComponent<FoodGen>().spawnTime = blackout;
                GameObject.Find("Bagel Gen").GetComponent<FoodGen>().spawnTime = blackout;
                */
                fireOut = true;
                
            }

            else return;
        }
    }

    public void FireFix()
    {
        Fire.SetActive(false);
        /*
        GameObject.Find("Soup Gen").GetComponent<FoodGen>().spawnTime = soup;
        GameObject.Find("Burger Gen").GetComponent<FoodGen>().spawnTime = burger;
        GameObject.Find("Coffee Gen").GetComponent<FoodGen>().spawnTime = coffee;
        GameObject.Find("Juice Gen").GetComponent<FoodGen>().spawnTime = juice;
        GameObject.Find("Salad Gen").GetComponent<FoodGen>().spawnTime = salad;
        GameObject.Find("Smoothie Gen").GetComponent<FoodGen>().spawnTime = smoothie;
        GameObject.Find("Soda Gen").GetComponent<FoodGen>().spawnTime = soda;
        GameObject.Find("Bagel Gen").GetComponent<FoodGen>().spawnTime = bagel;
        */
        FireTimer = 0;
        fireOut = false;
    }
   
}

