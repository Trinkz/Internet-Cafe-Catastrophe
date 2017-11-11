using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class InspectorAgentNav : MonoBehaviour
{
    public Transform[] points1;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        if (points1 != null)
        {
            points1 = new Transform[5];
            {
                for (var i = 0; i < 5; i++)
                {

                    points1[0] = GameObject.FindGameObjectWithTag("InspectionPT1").transform;
                    points1[1] = GameObject.FindGameObjectWithTag("InspectionPT2").transform;
                    points1[2] = GameObject.FindGameObjectWithTag("InspectionPT3").transform;
                    points1[3] = GameObject.FindGameObjectWithTag("InspectionPT4").transform;
                    points1[4] = GameObject.FindGameObjectWithTag("GraveYard").transform;
                }

            }
            agent = GetComponent<NavMeshAgent>();

            agent.autoBraking = false;

            GotoNextPoint();
        }
        else return;
    }


    // Update is called once per frame
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (points1 != null)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        else return;
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points1.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points1[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points1.Length;
    }
}


