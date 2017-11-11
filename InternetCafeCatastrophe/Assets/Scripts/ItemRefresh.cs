using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRefresh : MonoBehaviour {

    public GameObject FoodItem;
    float Timer = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RefreshRate();
	}

    private void OnMouseDown()
    {
        SpawnItem();
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        RefreshRate();

        
    }

    void RefreshRate()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            Timer = 3;
        }
    }

    void SpawnItem()
    {
        Instantiate(FoodItem, transform.position + (transform.forward), transform.rotation);
    }

}
