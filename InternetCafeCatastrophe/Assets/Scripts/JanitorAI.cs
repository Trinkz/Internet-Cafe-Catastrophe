/* Name: Dilon Erlandson
 * Date: 08/03/2017
 * Credit: sound for janitor cleaning plates. https://freesound.org/people/Glitchedtones/sounds/322404/
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JanitorAI : MonoBehaviour
{
    [SerializeField]
    AudioClip trash;

    public DeskAvailable boolChanger;

    public GameController healthAccess;

    Drag drag;

    //variable for sight
    public float heightMultiplier;
    public float sightDist = 10;

    //variable for Investigating
    private Vector3 investigateSpot;
    private float timer = 0;
    public float investigateWait = 10;
    public float IncreaseDPHTimer = 0;

    private bool alive = true;
    public State state;

    public GameObject target;

     GameObject Bagel;
     GameObject Burger;
     GameObject Smoothie;
     GameObject Soda;
     GameObject Salad;
     GameObject Juice;
     GameObject Coffee;
     GameObject Soup;

    FoodGen bagel;
    FoodGen burger;
    FoodGen smoothie;
    FoodGen soda;
    FoodGen salad;
    FoodGen juice;
    FoodGen coffee;
    FoodGen soup;

    string foodTag;
    string foodType;


    public enum State
    {
        INVESTIGATE
    }

    // Use this for initialization
    void Start()
    {

        Bagel = GameObject.Find("Bagel Gen");
        Burger = GameObject.Find("Burger Gen");
        Smoothie = GameObject.Find("Smoothie Gen");
        Soda = GameObject.Find("Soda Gen");
        Salad = GameObject.Find("Salad Gen");
        Juice = GameObject.Find("Juice Gen");
        Coffee = GameObject.Find("Coffee Gen");
        Soup = GameObject.Find("Soup Gen");


        bagel = Bagel.GetComponent<FoodGen>();
        burger = Burger.GetComponent<FoodGen>();
        smoothie = Smoothie.GetComponent<FoodGen>();
        soda = Soda.GetComponent<FoodGen>();
        salad = Salad.GetComponent<FoodGen>();
        juice = Juice.GetComponent<FoodGen>();
        coffee = Coffee.GetComponent<FoodGen>();
        soup = Soup.GetComponent<FoodGen>();

        


        GameObject h = GameObject.FindGameObjectWithTag("GameController");

        

        healthAccess = h.GetComponent<GameController>();

        heightMultiplier = 0.1f;

        StartCoroutine("FSM");

        GameObject g = GameObject.FindGameObjectWithTag("boolChanger");

        resetIncreaseDPHTimer();

    }

    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.INVESTIGATE:
                    Investigate();
                    break;
            }
            yield return null;
        }

    }

    void resetIncreaseDPHTimer()
    {
        IncreaseDPHTimer = 0;
    }


    void Investigate()
    {
        timer += Time.deltaTime;
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);


        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
        {
            foodType = hit.transform.name;
            foodTag = hit.transform.tag;

            if (hit.collider.gameObject.tag == "Trash")
            {
                //resetIncreaseDPHTimer();
                target = hit.collider.gameObject;
                //Debug.Log("I hit target");
                FoodGener();
                GetComponent<AudioSource>().PlayOneShot(trash);
                Destroy(hit.transform.gameObject);

            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            foodType = hit.transform.name;
            foodTag = hit.transform.tag;

            if (hit.collider.gameObject.tag == "Trash")
            {
               // resetIncreaseDPHTimer();
                target = hit.collider.gameObject;
                //Debug.Log("I hit target"); 
                FoodGener();
                GetComponent<AudioSource>().PlayOneShot(trash);
                Destroy(hit.transform.gameObject);
               
            }

        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            foodType = hit.transform.name;
            foodTag = hit.transform.tag;

            if (hit.collider.gameObject.tag == "Trash")
            {
                //resetIncreaseDPHTimer();
                target = hit.collider.gameObject;
                //Debug.Log("I hit target");
                FoodGener();
                GetComponent<AudioSource>().PlayOneShot(trash);
                Destroy(hit.transform.gameObject);
                
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Trash")
        {
            state = JanitorAI.State.INVESTIGATE;
            //Debug.Log("I am investigating");
        }
    }

    void FoodGener()
    {
        if (foodTag == "Trash" && foodType == "bagel(Clone)")
        {
            bagel.Bagel = false;
        }
        else if (foodTag == "Trash" && foodType == "burger(Clone)")
        {
            burger.Burger = false;
        }
        else if (foodTag == "Trash" && foodType == "coffee(Clone)")
        {
            coffee.Coffee = false;
        }
        else if (foodTag == "Trash" && foodType == "juice(Clone)")
        {
            juice.Juice = false;
        }
        else if (foodTag == "Trash" && foodType == "smoothie(Clone)")
        {
            smoothie.Smoothie = false;
        }
        else if (foodTag == "Trash" && foodType == "soda(Clone)")
        {
            soda.Soda = false;
        }
        else if (foodTag == "Trash" && foodType == "salad(Clone)")
        {
            salad.Salad = false;
        }
        else if (foodTag == "Trash" && foodType == "soup(Clone)")
        {
            soup.Soup = false;
        }
        else
        {
            return;
        }
    }

}