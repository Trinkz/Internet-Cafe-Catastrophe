using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingTimer : MonoBehaviour
{

    public int scoreValue;
    public float hackTimer = 30.0f;
    public float LeetTimer = 60.0f;
    public float custTimer = 30.0f;
    public float custLerp = 30.0f;
    float t = 0.0f;
    public bool triggered = false;
    bool money = false;
    public bool hacking = false;
    public HackingSlider hackSlide;

    public Renderer rend;
    public Material norm;
    Color angry = Color.red;

    private float imageTimer;

    int pTime;

    public float timer;

    foodRequests foodReq;

    NavAgent nav;

    private GameController gameController;

    public bool HackerSucceeded;

    [SerializeField]
    AudioClip HackerSuccess;

    NavAgent nAgent;

    // Use this for initialization
    void Start()
    {
        nAgent = GetComponent<NavAgent>();

        HackerSucceeded = false;
        rend = GetComponent<Renderer>();
        rend.material = norm;
         
        nav = GetComponent<NavAgent>();

        foodReq = GetComponent<foodRequests>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            //Debug.Log("Cannot find 'Game Controller' script! ");
            return;
        }

        pTime = Random.Range(0, 31);
        custLerp += pTime;
        custTimer += pTime;
    }

    // Update is called once per frame
    void Update()
    {
        MoneyTrigger();

        if (hacking == true)
        {
            HackerTime();
        }
      
    }

    void HackerTime()
    {
        if(nav.customer.tag == "Hacker")
        {
            if (triggered == true && nAgent.isSelected == false)
            {

                hackTimer -= Time.deltaTime;
                //Debug.Log("Hack in progress");
                //Start the slider
                hackSlide.SendMessage("BeginSlider");

                if (hackTimer < 0 && money == false)
                {
                    //Debug.Log("You lost some currency");
                    gameController.AddScore(scoreValue);
                    //Destroy(gameObject);
                    money = true;
                    nav.ReturnWP();
                    foodReq.messageCanvas.enabled = false;
                    HackerSucceeded = true;
                    GetComponent<AudioSource>().PlayOneShot(HackerSuccess);

                }
            }
        }
       else if (nav.customer.tag == "Customer")
        {


            if (triggered == true)
            {
                timer += Time.deltaTime;

                //custTimer += Time.deltaTime;

                GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(GetComponentInChildren<SpriteRenderer>().color, angry, Time.deltaTime / custTimer);


                if (timer > custTimer)
                {
                    //rend.material.color = Color.red;
                    nav.ReturnWP();
                    money = true;
                    gameController.AddScore(scoreValue - 50);
                    HackerSucceeded = true;
                    GetComponent<AudioSource>().PlayOneShot(HackerSuccess);
                    foodReq.messageCanvas.enabled = false;
                    triggered = false;
                }
            }
        }
        else if (nav.customer.tag == "1337Hacker")
        {
            if (triggered == true && nAgent.isSelected == false)
            {

                LeetTimer -= Time.deltaTime;
                //Debug.Log("Hack in progress");
                //Start the slider
                hackSlide.SendMessage("BeginSlider");

                if (LeetTimer < 0 && money == false)
                {
                    //Debug.Log("You Lost all your Currency");
                    gameController.AddScore(scoreValue);
                    //Destroy(gameObject);
                    money = true;
                    nav.ReturnWP();
                    foodReq.messageCanvas.enabled = false;

                }
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ResetWP")
        {
            triggered = true;
            hacking = true;

        }
    }

    void MoneyTrigger()
    {
        if (HackerSucceeded == true)
        {

            GameObject.Find("MoneyObjectBad").GetComponent<Renderer>().enabled = true;
            GameObject.Find("MoneyObjectBad").GetComponent<Behaviour>().enabled = true;
            imageTimer += Time.deltaTime;
            

        }

        if (imageTimer >= .5f)
        {
            
            GameObject.Find("MoneyObjectBad").GetComponent<Renderer>().enabled = false;
            GameObject.Find("MoneyObjectBad").GetComponent<Behaviour>().enabled = false;

            //print("turned off");

        }

        else
            return;

    }



}