/* Name: Dilon Erlandson
 * Date: 08/04/2017
 * Credit: sound for generator catching fire. https://freesound.org/people/Zott820/sounds/209582/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Using Starter Particle Pack/ Particle Systems by FullTiltBoogie


public class GeneratorFire : MonoBehaviour {

    private ParticleSystem PartSys;
    int FireChance;
    float Timer;
    public bool GenWorking;

    public GameObject Flood;

    bool Sparky;

    


    // Use this for initialization
    void Start() {
        PartSys = GetComponentInChildren<ParticleSystem>();
        FireChance = Random.Range(20, 41);
        GenWorking = true;
        Sparky = false;

    }

    // Update is called once per frame
    void Update() {
        CatchFire();
        Timer += Time.deltaTime;
       
        
    }

    void CatchFire()
    {
        if ((Input.GetKeyDown(KeyCode.G)) || Timer >= FireChance * 0.75f && Sparky == false || GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBoTrue == true)
        {
           // Timer >= FireChance && Sparky == false
            Sparky = true;
            Timer = 0;
            PartSys.Play();
            //print("sparks");
            GenWorking = false;
            GetComponent<AudioSource>().Play();


        }

       

        if ((Input.GetKeyDown(KeyCode.H)))
        {
            Sparky = false;
            PartSys.Stop();
            //print("sparks stop");
            GenWorking = true;
            GetComponent<AudioSource>().Stop();
        }



    }

    

    void OnMouseDown()

    {


        if (GenWorking == false )
        {
            GenWorking = true;

            PartSys.Stop();

            GameObject.Find("Blackout holder").GetComponent<Blackout>().Timer = 0;

            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().GeneratorTrigger();

          //  Debug.Log("GenWorking = " + GenWorking);

            Sparky = false;

            GetComponent<AudioSource>().Stop();

            if (Flood.activeInHierarchy == false)
            {
                GameObject.Find("Directional Light").GetComponent<Light>().intensity = 1;
            }

           else if (GameObject.Find("FloodHolder").GetComponent<FloodScript>().floodActive == false)
            {
                GenWorking = false;
            }
        }
        else
        {
          //  Debug.Log("Turn off" + GenWorking);
            return;


        }

    }
}
