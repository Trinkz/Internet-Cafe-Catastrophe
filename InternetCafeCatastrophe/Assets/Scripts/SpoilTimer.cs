using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpoilTimer : MonoBehaviour {

   
    public float SpoilTime = 30f;
    public float TimeLimit;
    private float Timer = 0f;
    public float spoilLerp = 30.0f;
    public ParticleSystem stink;
    public FoodDrinkValues fdv;
    //Material lastMaterial;
    public bool spoiled;

    Color SS = Color.red;

    public Renderer rend;
    public Material norm;

    Color spoil = Color.green;

   

    string SceneName;
    Scene currentScene;

    // Use this for initialization
    void Start ()
    {
        // Scene references
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;


        rend = GetComponent<Renderer>();
        rend.material = norm;
        Timer = 0f;

        spoiled = false;

        //lastMaterial = GetComponent<Renderer>().material;

        TimeLimit = SpoilTime + 600f;

        fdv = GetComponent<FoodDrinkValues>();

        stink.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(spoiled);
        updateTimer();
	    if(Timer> SpoilTime || Input.GetKeyDown(KeyCode.S))
        {
            spoiled = true;
            gameObject.tag = "Trash";
            //GetComponent<Renderer>().material.color = Color.green;
            stink.Play();


            
        }

        TutorialSpoil();
	}
    public void updateTimer()
    {
        //Debug.Log(SpoilTime);

        Timer += Time.deltaTime;
        if (Timer >= TimeLimit)
        {
            Timer = 0f;
            spoiled = false;
            stink.Stop();

            //GetComponent<Renderer>().material = lastMaterial;
            //Debug.Log("I reset");

        }
       

        if(tag == "Salad")
        {
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, SS, Time.deltaTime / SpoilTime);
        }
        else if(tag != "Salad")
        {
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, spoil, Time.deltaTime / SpoilTime);
        }
    }
    

    public void TutorialSpoil()
    {
        if (SceneName == "ICC_Stage1" && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == false && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P1Obj3 == true)
        {
            SpoilTime = 3.0f;
        }
        else
            SpoilTime = 30f;
    }
}
