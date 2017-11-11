/*Credit: vvvvv Sounds used in game vvvvv
 *  
 * User: j1987, Link:  https://freesound.org/people/j1987/sounds/106127/ 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    AudioSource audioSource;

    bool doOnce;
    public bool spoilobj;

    public bool DishCount;

    public SpoilTimer playT;

    public int playSound = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        doOnce = false;
        spoilobj = false;
        DishCount = false;
    }

    void Update()
    {
        PlayFliesSound();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
            audioSource.Play();
            //Debug.Log("you through away Trash");
            //GameObject.Find("Burger Gen").GetComponent<AudioSource>().Stop();

            if (doOnce==false && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P1Obj3 == true)
            {
                spoilobj = true;
                doOnce = true;
            }

            if (GameObject.Find ("Game Icon Controller").GetComponent<Tutorial>().P3 == true && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P4 == false)
            {
                DishCount = true;

            }
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_1 == true && doOnce == false)
            {
                    spoilobj = true;
                    doOnce = true;
            }
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_3 == true)
            {
                DishCount = true;
             
            }
            if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_1 == true)
            {
                DishCount = true;
            }



        }
        else
        {
           // Debug.Log("Not a trash item");
            audioSource.Play();
        }
    }


    void PlayFliesSound()
    {
        if (GameObject.FindGameObjectsWithTag("Trash").Length >= 1)
        {
            playSound++;
            if (playSound == 1)
            {
                GameObject.Find("Burger Gen").GetComponent<AudioSource>().Play();

            }

        }

        if (GameObject.FindGameObjectsWithTag("Trash").Length <= 0)
        {
            playSound = 0;
            GameObject.Find("Burger Gen").GetComponent<AudioSource>().Stop();
        }
    

    }
}
