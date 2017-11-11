using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGenerator : MonoBehaviour {
    public float RefreshTimer = 6;
    float Timer;

    public GameObject Guard;
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
        SpawnGuard();
        InvokeRepeating("GuardRefreshRate",0.1f,.01f);
    }

    public void SpawnGuard()
    {
        Instantiate(Guard);
    }

    void GuardRefreshRate()
    {
       
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            CancelInvoke("GuardRefreshRate");
            Timer = RefreshTimer;
        }
    }

}
