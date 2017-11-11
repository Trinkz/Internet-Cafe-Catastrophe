/* Name: Dilon Erlandson
 * Date: 08/03/2017
 * Credit: sound for inspector finding plates. https://freesound.org/people/bbrocer/sounds/389511/
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InspectorAI : MonoBehaviour
{
    [SerializeField]
    AudioClip find;

    public DeskAvailable boolChanger;

    public GameController healthAccess;

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

    public bool trashless;

    public Color lerpedColor = Color.white;
    public Light lt;

    public enum State
    {
        INVESTIGATE
    }

    // Use this for initialization
    void Start()
    {
        GameObject h = GameObject.FindGameObjectWithTag("GameController");

        healthAccess = h.GetComponent<GameController>();

        heightMultiplier = 0.1f;

        StartCoroutine("FSM");

        GameObject g = GameObject.FindGameObjectWithTag("boolChanger");

        resetIncreaseDPHTimer();

        lt = GetComponentInChildren<Light>();

        trashless = false;

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
            if (hit.collider.gameObject.tag == "Trash")
            {
                resetIncreaseDPHTimer();
                target = hit.collider.gameObject;
                lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
                gameObject.GetComponent<Renderer>().material.color = lerpedColor;
                //lt.color += Color.red / 0.5F * Time.deltaTime;
                // lt.color -= Color.yellow / 1.0F * Time.deltaTime;
                //  lt.color -= Color.blue / 1.0F * Time.deltaTime;
                lt.color = Color.red;

                //Debug.Log("I hit target");
                healthAccess.DecrementPlayerHealth(1);
                GetComponent<AudioSource>().PlayOneShot(find);
            }
            else if (hit.collider.gameObject.tag != "Trash")
            {
                lt.color = Color.white;
                //Debug.Log("i didn't see trash increase timer please");
                IncreaseDPHTimer += Time.deltaTime;
                //Debug.Log("Increase dph timer" + IncreaseDPHTimer);
                if(IncreaseDPHTimer >= 30f)
                {
                    if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3Obj2 == true)
                    {
                        trashless = true;

                    }
                    healthAccess.IncrementPlayerHealth(1);
                }
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Trash")
            {
                resetIncreaseDPHTimer();
                target = hit.collider.gameObject;
                //Debug.Log("I hit target");
                lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
                gameObject.GetComponent<Renderer>().material.color = lerpedColor;
                //lt.color += Color.red / 0.5F * Time.deltaTime;
                // lt.color -= Color.yellow / 1.0F * Time.deltaTime;
                //  lt.color -= Color.blue / 1.0F * Time.deltaTime;
                lt.color = Color.red;
                healthAccess.DecrementPlayerHealth(1);
                GetComponent<AudioSource>().PlayOneShot(find);

            }
            else if (hit.collider.gameObject.tag != "Trash")
            {
                lt.color = Color.white;
                //Debug.Log("i didn't see trash increase timer please");
                IncreaseDPHTimer += Time.deltaTime;
                //Debug.Log("Increase dph timer" + IncreaseDPHTimer);
                if (IncreaseDPHTimer >= 30f)
                {
                    if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3Obj2 == true)
                    {
                        trashless = true;

                    }
                    healthAccess.IncrementPlayerHealth(1);


                }
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Trash")
            {
                resetIncreaseDPHTimer();
                target = hit.collider.gameObject;
                //Debug.Log("I hit target");
                lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
                gameObject.GetComponent<Renderer>().material.color = lerpedColor;
                //lt.color += Color.red / 0.5F * Time.deltaTime;
                // lt.color -= Color.yellow / 1.0F * Time.deltaTime;
                //  lt.color -= Color.blue / 1.0F * Time.deltaTime;
                lt.color = Color.red;
                healthAccess.DecrementPlayerHealth(1);
                GetComponent<AudioSource>().PlayOneShot(find);
            }
            else if (hit.collider.gameObject.tag != "Trash")
            {
                lt.color = Color.white;
                // Debug.Log("i didn't see trash increase timer please");
                IncreaseDPHTimer += Time.deltaTime;
                //Debug.Log("Increase dph timer" + IncreaseDPHTimer);
                if (IncreaseDPHTimer >= 30f)
                {
                    if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3Obj2 == true)
                    {
                        trashless = true;

                    }
                    healthAccess.IncrementPlayerHealth(1);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Trash")
        {
            state = InspectorAI.State.INVESTIGATE;
            //Debug.Log("I am investigating");
        }
    }
 
}