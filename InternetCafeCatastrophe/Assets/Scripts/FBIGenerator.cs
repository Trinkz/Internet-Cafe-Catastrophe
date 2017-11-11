using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FBIGenerator : MonoBehaviour {
    public GameObject FBI;
    public float RefreshTimer = 3;
    float Timer;
    
    // Use this for initialization
    void Start () {
        Timer = RefreshTimer;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        SpawnFBI();
        InvokeRepeating("FbiRefreshRate", 0.1f, .01f);
    }

    public void SpawnFBI()
    {
        Instantiate(FBI, transform.position + (transform.forward), transform.rotation);
       


        InvokeRepeating("FbiRefreshRate", 0.1f, .01f);
    }

    void FbiRefreshRate()
    {

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            CancelInvoke("FbiRefreshRate");
            Timer = RefreshTimer;
        }
    }

}
