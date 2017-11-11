using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    int MaxHits = 3;
    int CurHits = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && CurHits <= MaxHits)
        {

            CurHits+=1;
           
        //    Debug.Log("you fed the hacker");

            if (other.tag == "food" && CurHits >= MaxHits)
            {
               
            }
        }
    }
}
    
