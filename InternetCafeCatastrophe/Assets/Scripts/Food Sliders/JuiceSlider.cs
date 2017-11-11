using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuiceSlider : MonoBehaviour {

    public Slider slider;
    public GameObject generator;
    bool beginSlider;
    float timer;
    float maxValTimer;



    bool doOnce;
    Blackout bScript;
    FireScript fScript;
    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("Blackout holder") != null)
        {
            bScript = GameObject.Find("Blackout holder").GetComponent<Blackout>();
        }
        fScript = GameObject.Find("FireHolder").GetComponent<FireScript>();
        beginSlider = false;
        doOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == true && doOnce == false || GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_6 == true && doOnce == false || GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_6 == true && doOnce == false)
        {
            bScript = GameObject.Find("Blackout holder").GetComponent<Blackout>();
            doOnce = true;
        }
        if (beginSlider == true)
        {
            if (maxValTimer >= 1)
            {
                MaxValue();
                Debug.Log("MaxValue being called ");
                maxValTimer = 0;
            }

            maxValTimer += Time.deltaTime;

            timer += Time.deltaTime;
            slider.value = Mathf.MoveTowards(slider.value, slider.maxValue, Time.deltaTime);

            if (timer >= slider.maxValue)
            {
               
                timer = 0;
                slider.value = 0;
                beginSlider = false;
                GameObject.Find("Juice Gen").GetComponent<FoodGen>().Juice = true;
            }
        }
    }

    public void MaxValue()
    {
        slider.maxValue = generator.GetComponent<FoodGen>().spawnTime;

    }

    public void BeginSlider()
    {
        if(bScript != null)
        {
            if (GameObject.Find("Juice Gen").GetComponent<FoodGen>().Juice == false && bScript.bOut == false && fScript.fireOut == false)
            {
                beginSlider = true;

            }
        }
        else
        {
            if (GameObject.Find("Juice Gen").GetComponent<FoodGen>().Juice == false && fScript.fireOut == false)
            {
                beginSlider = true;

            }
        }

        
    }
}
