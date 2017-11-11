using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPatienceTimer : MonoBehaviour {

    public float patienceTimer = 30.0f;

	
	
	// Update is called once per frame
	void Update ()
    {
        patienceTimer -= Time.deltaTime;
        //Debug.Log("customer getting inpatiant");

        if (patienceTimer < 0)
        {
            Destroy(gameObject);
           // Debug.Log("customer has left");
        }
    }
}
