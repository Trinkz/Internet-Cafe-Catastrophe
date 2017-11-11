/*Credit: vvvvv Sounds used in game vvvvv
 *  
 * User: creek23, Link:  https://freesound.org/people/creek23/sounds/75235/, 
 * User: dorr1 Link: https://freesound.org/people/dorr1/sounds/338960/
 * User: Mattix145 Link: https://freesound.org/people/Mattix145/sounds/348112/
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodRequests : MonoBehaviour {

    public string foodRequest;
    int foodRange;
    int foodValue;

    [SerializeField]
    public GameObject[] food = new GameObject[7];

    public Text foodText;

    public Canvas messageCanvas;

    NavAgent nav;

    Upgrades upgrades;
    GameObject desks;
/*
    public AudioSource sound;
    public AudioClip monies;
    public AudioClip noMonies;
    public AudioClip yuck;
    */
    void Start()
    {
        foodText.text = "";


        messageCanvas.enabled = false;

        nav = GetComponent<NavAgent>();

        desks = GameObject.Find("Desks");
        upgrades = desks.GetComponent<Upgrades>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ResetWP")
        {
            TurnOnMessage();
            nav.avail = true;
        }

        /* if(other.GetComponent<FoodDrinkValues>().dt == foodRequest)
         {
             sound = monies.
         } 
         */
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
        FoodRange();
    }

    public void FoodRange()
    {
        if (upgrades.upgradeCounterSpace2 == true)
        {
            foodRange = Random.Range(1, 9);

            if (foodRange != foodValue)
            {
                if (foodRange == 1)
                {
                    foodValue = 1;
                    foodText.text = food[0].tag.ToString();
                    foodRequest = food[0].tag.ToString();
                    //  Debug.Log(foodRequest);
                }
                if (foodRange == 2)
                {
                    foodValue = 2;

                    foodText.text = food[1].tag.ToString();
                    foodRequest = food[1].tag.ToString();
                }
                if (foodRange == 3)
                {
                    foodValue = 3;

                    foodText.text = food[2].tag.ToString();
                    foodRequest = food[2].tag.ToString();
                }
                if (foodRange == 4)
                {
                    foodValue = 4;

                    foodText.text = food[3].tag.ToString();
                    foodRequest = food[3].tag.ToString();
                }
                if (foodRange == 5)
                {
                    foodValue = 5;

                    foodText.text = food[4].tag.ToString();
                    foodRequest = food[4].tag.ToString();
                }
                if (foodRange == 6)
                {
                    foodValue = 6;

                    foodText.text = food[5].tag.ToString();
                    foodRequest = food[5].tag.ToString();
                }
                if (foodRange == 7)
                {
                    foodValue = 7;

                    foodText.text = food[6].tag.ToString();
                    foodRequest = food[6].tag.ToString();
                }
                if (foodRange == 8)
                {
                    foodValue = 8;

                    foodText.text = food[7].tag.ToString();
                    foodRequest = food[7].tag.ToString();
                }
            }
            else
            {
                FoodRange();


            }
            // Debug.Log(foodRange);

           
        }
        else if (upgrades.upgradeCounterSpace1 == true)
        {
            foodRange = Random.Range(1, 7);

            if (foodValue == 0)
            {
                if (foodRange == 1)
                {
                    foodValue = 1;

                    foodText.text = food[0].tag.ToString();
                    foodRequest = food[0].tag.ToString();
                    //  Debug.Log(foodRequest);
                }
                if (foodRange == 2)
                {
                    foodValue = 2;

                    foodText.text = food[1].tag.ToString();
                    foodRequest = food[1].tag.ToString();
                }
                if (foodRange == 3)
                {
                    foodValue = 3;

                    foodText.text = food[2].tag.ToString();
                    foodRequest = food[2].tag.ToString();
                }
                if (foodRange == 4)
                {
                    foodValue = 4;

                    foodText.text = food[3].tag.ToString();
                    foodRequest = food[3].tag.ToString();
                }
                if (foodRange == 5)
                {
                    foodValue = 5;

                    foodText.text = food[4].tag.ToString();
                    foodRequest = food[4].tag.ToString();
                }
                if (foodRange == 6)
                {
                    foodValue = 6;

                    foodText.text = food[5].tag.ToString();
                    foodRequest = food[5].tag.ToString();
                }
            }
            else
            {
                FoodRange();

            }

            
        }
        else
        {
            foodRange=Random.Range(1,5);

            if (foodRange != foodValue)
            {
                if (foodRange == 1)
                {
                    foodValue = 1;

                    foodText.text = food[0].tag.ToString();
                    foodRequest = food[0].tag.ToString();
                    //Debug.Log(foodRequest);
                }
                if (foodRange == 2)
                {
                    foodValue = 2;

                    foodText.text = food[1].tag.ToString();
                    foodRequest = food[1].tag.ToString();
                }
                if (foodRange == 3)
                {
                    foodValue = 3;

                    foodText.text = food[2].tag.ToString();
                    foodRequest = food[2].tag.ToString();
                }
                if (foodRange == 4)
                {
                    foodValue = 4;

                    foodText.text = food[3].tag.ToString();
                    foodRequest = food[3].tag.ToString();
                }
            }
            else
            {
                FoodRange();                
            }

           
        }
    }
}
