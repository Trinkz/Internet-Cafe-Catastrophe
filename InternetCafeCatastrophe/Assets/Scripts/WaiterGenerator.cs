using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterGenerator : MonoBehaviour {



    UnityEngine.AI.NavMeshAgent pathfinder;
    [SerializeField]
    float TimeMin = 10;
    [SerializeField]
    float TimeMax = 20;

    private float TimeLimit = 2;
    private float Timer = 0;

    public GameObject Waiter;
    int range;
    Transform target;

    GameObject pauseCon;
    PauseGame pauseG;

    void Start()
    {
        pauseCon = GameObject.Find("PauseController");
        pauseG = pauseCon.GetComponent<PauseGame>();
    }

    void Awake()
    {
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        if (Input.GetKeyDown(KeyCode.P) && pauseG.isPaused == false)
        {
        //    Debug.Log("I pressed I where is my Waiter?");
            Instantiate(Waiter, transform.position, transform.rotation);
        }
    }

    void updateTimer()
    {
        Timer += Time.deltaTime;

        if (Timer >= TimeLimit)
        {
            TimeLimit = Random.Range(TimeMin, TimeMax);
            Timer = 0;
            doSpawn();
        }

    }

    void doSpawn()
    {
        range = Random.Range(1, 101);

        if (range <= 10)
        {
            Instantiate(Waiter, transform.position, transform.rotation);
        }
    }
}
