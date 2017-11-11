using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFireFix : MonoBehaviour {

    public FireScript fire;
	// Use this for initialization
	void Start () {
        fire = GameObject.Find("FireHolder").GetComponent<FireScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        fire.FireFix();
    }
}
