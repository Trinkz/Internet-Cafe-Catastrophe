using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixFloodObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()

    {

       // Debug.Log("Clickity Click");

       


        if (GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBoTrue == true)
        {
            GameObject.Find("FloodHolder").GetComponent<FloodScript>().ButtonFloodFix();

            GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBlackOutFix();
            GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().PurchasePump();
        }


    }

}
