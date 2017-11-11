using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackout : MonoBehaviour
{

    public bool BlackOutWithTime;

    public int pTime;
    public float Timer;
    public GameObject Lights;

    public bool bOut;

    float soup;
    float burger;
    float coffee;
    float juice;
    float salad;
    float smoothie;
    float soda;
    float bagel;
    float blackout = 300000000;

    public bool StopCustomersFromComingIn;
    public bool FloodBoTrue;
    // Use this for initialization
    void Start()
    {
        BlackOutWithTime = false;
        bOut = false;

        StopCustomersFromComingIn = false;

     
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
        Lights.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        RollingBlackout();

        if (BlackOutWithTime == false)
        {
            Timer += Time.deltaTime;
        }
    }

    void RollingBlackout()
    {
        if (BlackOutWithTime == true)
        {
            pTime = Random.Range(30, 70);
        }

        if ((Input.GetKeyDown(KeyCode.B)) || Timer >= pTime && GameObject.Find("Generator").GetComponent<GeneratorFire>().GenWorking == false && BlackOutWithTime == false)
        {
            StopCustomersFromComingIn = true;
            BlackOutWithTime = true;

            /*
            //********************************************************************************************************************************
            GameObject.Find("Soup Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Burger Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Coffee Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Juice Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Salad Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Smoothie Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Soda Gen").GetComponent<FoodGen>().spawnTime = blackout;
            GameObject.Find("Bagel Gen").GetComponent<FoodGen>().spawnTime = blackout;
            //print("blackout");
            */

            bOut = true;
            GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0.5f;
            Timer = 0;

            Lights.SetActive(false);
        }

        if ((Input.GetKeyDown(KeyCode.N)) || GameObject.Find("Generator").GetComponent<GeneratorFire>().GenWorking == true && BlackOutWithTime == true)
        {
            BlackOutWithTime = false;

            StopCustomersFromComingIn = false;


            /*
            GameObject.Find("Soup Gen").GetComponent<FoodGen>().spawnTime = soup;
            GameObject.Find("Burger Gen").GetComponent<FoodGen>().spawnTime = burger;
            GameObject.Find("Coffee Gen").GetComponent<FoodGen>().spawnTime = coffee;
            GameObject.Find("Juice Gen").GetComponent<FoodGen>().spawnTime = juice;
            GameObject.Find("Salad Gen").GetComponent<FoodGen>().spawnTime = salad;
            GameObject.Find("Smoothie Gen").GetComponent<FoodGen>().spawnTime = smoothie;
            GameObject.Find("Soda Gen").GetComponent<FoodGen>().spawnTime = soda;
            GameObject.Find("Bagel Gen").GetComponent<FoodGen>().spawnTime = bagel;
            //print("power restored");
            */

            bOut = false;
            GameObject.Find("Directional Light").GetComponent<Light>().intensity = 1;
            Timer = 0;

            Lights.SetActive(true);
        }

    }

    public void FloodBlackOut()
    {
        GameObject.Find("Generator").GetComponent<GeneratorFire>().GenWorking = false;
        StopCustomersFromComingIn = true;
        FloodBoTrue = true;
        /*
                    //********************************************************************************************************************************
                    GameObject.Find("Soup Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Burger Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Coffee Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Juice Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Salad Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Smoothie Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Soda Gen").GetComponent<FoodGen>().spawnTime = blackout;
                    GameObject.Find("Bagel Gen").GetComponent<FoodGen>().spawnTime = blackout;
                   
                    */

        bOut = true;
        GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0.5f;
        Timer = 0;

        Lights.SetActive(false);



    }

    public void FloodBlackOutFix()
    {

        FloodBoTrue = false;

        StopCustomersFromComingIn = false;

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

        bOut = false;

        Timer = 0;

        Lights.SetActive(true);

    }
}
