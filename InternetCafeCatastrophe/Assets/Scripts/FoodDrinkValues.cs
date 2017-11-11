using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FoodDrinkValues : MonoBehaviour
{


    public string dt;
    public string rt;
    public foodRequests requestTag;
    public Drag dragTag;
    public int scoreValue;
    public int spoilValue = 0;

    private GameController gameController;
    public SpoilTimer foodSpoil;

    GameObject customer;

    [SerializeField]
    AudioClip monies;

    [SerializeField]
    AudioClip noMonies;

    [SerializeField]
    AudioClip yuck;

    public NavAgent nav;
    public int spoilHPCost;

    public bool MoneyTriggered = false;

    private float ImageTimer;

    public GameObject iccSprite;

    

    // Use this for initialization
    void Start()
    {
        GameObject.Find("MoneyObject").GetComponent<Renderer>().enabled = false;
        GameObject.Find("MoneyObject").GetComponent<Behaviour>().enabled = false;
        GameObject.Find("MoneyObjectBad").GetComponent<Renderer>().enabled = false;
        GameObject.Find("MoneyObjectBad").GetComponent<Behaviour>().enabled = false;

        foodSpoil = GetComponent<SpoilTimer>();

        requestTag = GetComponent<foodRequests>();

        dragTag = GetComponent<Drag>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
           // Debug.Log("Cannot find 'Game Controller' script! ");
        }
    }

    // A customized version of the destroy function. --------- Got this from  Space Shooter Project
    void StartDestroy(float timeDelay)
    {
        // Turn off drawing and colliding.
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Start the destroy countdown.
        Destroy(gameObject, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        MoneySymbolTrigger();
    }

    void OnTriggerEnter(Collider other)
    {
        nav = other.GetComponent<NavAgent>();


        dt = dragTag.foodTag;

        //rt = requestTag.foodRequest;

        if (other.tag == "TrashBin")
        {
            //Debug.Log("This is not Trash");
            Destroy(gameObject);
            Destroy(iccSprite);
        }
        if(other.name == "FoodDeath")
        {
           // Debug.Log("Food Gone");
            Destroy(gameObject);
            gameController.AddScore(-20);
            Destroy(iccSprite);
        }
        else if (other.GetComponent<foodRequests>().foodRequest == dt && nav.avail == true)
        {
            if (other.CompareTag("Customer") && foodSpoil.spoiled == false)
            {
                //customer = other.gameObject;
                //ustomer.GetComponent<AudioSource>().Play();
                GetComponent<AudioSource>().PlayOneShot(monies);

                gameController.AddScore(scoreValue);

                //Debug.Log("YA GOT MONEY");
                StartDestroy(monies.length);
                Destroy(iccSprite);
                MoneyTriggered = true;
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve++;
            }
            
            else
            {
                GetComponent<AudioSource>().PlayOneShot(noMonies);
                StartDestroy(noMonies.length);
                Destroy(iccSprite);

                //Destroy(gameObject);
            }
        }

        else if (other.CompareTag("Customer") && foodSpoil.spoiled == true)
        {
            gameController.AddScore(spoilValue);
            //  Debug.Log("Should be zero" + spoilValue);
            GetComponent<AudioSource>().PlayOneShot(yuck);
            gameController.DecrementPlayerHealth(spoilHPCost);
            StartDestroy(yuck.length);
            Destroy(iccSprite);

        }

        else if(other.GetComponent<foodRequests>().foodRequest != dt && nav.avail == true)
        {
            Destroy(gameObject);
            other.GetComponent<HackingTimer>().custTimer -= 5;
            Destroy(iccSprite);
        }
      
        else if (other.CompareTag("Hacker"))
        {
            //Debug.Log("Hacker money");
             GetComponent<AudioSource>().PlayOneShot(noMonies);

           // Destroy(gameObject);
             StartDestroy(noMonies.length);
            Destroy(iccSprite);
        }
        else if (other.CompareTag("1337Hacker"))
        {
            //Debug.Log("1337 money");
            GetComponent<AudioSource>().PlayOneShot(noMonies);
            StartDestroy(noMonies.length);
            //Destroy(gameObject);
            Destroy(iccSprite);
        }
        else
        {
            return;
        }
    }

    void MoneySymbolTrigger()
    {
        if (MoneyTriggered == true)
        {
           
            GameObject.Find("MoneyObject").GetComponent<Renderer>().enabled = true;
            GameObject.Find("MoneyObject").GetComponent<Behaviour>().enabled = true;
            ImageTimer += Time.deltaTime;
        }

        
        if (ImageTimer >= .5f)
        {
           
            GameObject.Find("MoneyObject").GetComponent<Renderer>().enabled = false;
            GameObject.Find("MoneyObject").GetComponent<Behaviour>().enabled = false;
           

           // print("turned off");

        }

        else
            return;

    }


}
