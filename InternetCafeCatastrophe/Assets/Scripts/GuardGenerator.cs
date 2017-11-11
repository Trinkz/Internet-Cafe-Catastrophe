using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGenerator : MonoBehaviour {
    public GameObject Guard;
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
        SpawnGuard();
        InvokeRepeating("GuardRefreshRate", 0.1f, .01f);
    }

    public void SpawnGuard()
    {
        Instantiate(Guard, transform.position + (transform.forward), transform.rotation);



        InvokeRepeating("GuardRefreshRate", 0.1f, .01f);
    }

    void GuardRefreshRate()
    {

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            CancelInvoke("GuardRefreshRate");
            Timer = RefreshTimer;
        }
    }

}
