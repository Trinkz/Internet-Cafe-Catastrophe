using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardEscort : MonoBehaviour {

    // NavMeshAgent variable.
    NavMeshAgent Guard;

    // Hackers in area.
    GameObject hackers;

    // The Hacker target.
    public Transform hacker;

    


    // Use this for initialization
    void Start()
    {
        Guard = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToHacker();
       
    }

    public void MoveToHacker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "Hacker")
                {
                    Guard.destination = hit.point;
                   
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hacker"))
        {
          
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }

    
}
