using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeskAvailable : MonoBehaviour
{

    public GameObject Plate;

    Vector3 PlateLocation;


    int range;

    public bool atDesk = false;

    // Use this for initialization
    void Start()
    {
        PlateLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.8f);
    }



    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("On trigger for plate collider");

        //Debug.Log(other.tag);

        if ((other.CompareTag("Customer")) && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == true && other.GetComponent<NavAgent>().DishStoppers == true)
        {
            
            range = Random.Range(1, 5);
            if (range == 1)
            {
                //Debug.Log("I have a plate here");
                Instantiate(Plate, PlateLocation, Quaternion.identity);
            }
        }
        if (other.CompareTag("Customer") && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_3 == true && other.GetComponent<NavAgent>().DishStoppers == true)
        {
            range = Random.Range(1, 5);
            if (range == 1)
            {
                
                //Debug.Log("I have a plate here");
                Instantiate(Plate, PlateLocation, Quaternion.identity);
            }
        }
        if (other.CompareTag("Customer") && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_3 == true && other.GetComponent<NavAgent>().DishStoppers == true)
        {
            range = Random.Range(1, 5);
            if (range == 1)
            {
                
                //Debug.Log("I have a plate here");
                Instantiate(Plate, PlateLocation, Quaternion.identity);
            }
        }
        if (other.CompareTag("Customer") && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_3 == true && other.GetComponent<NavAgent>().DishStoppers == true)
        {
            range = Random.Range(1, 5);
            if (range == 1)
            {
                
                //Debug.Log("I have a plate here");
                Instantiate(Plate, PlateLocation, Quaternion.identity);
            }
        }
    }


}
