using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDrinkGen : MonoBehaviour {

    
    private float TimeLimit = 120f;
    private float Timer = 0f;
    public GameObject bagel;
    public GameObject burger;
    public GameObject coffee;
    public GameObject juice;
    public GameObject salad;
    public GameObject smoothie;
    public GameObject soda;
    public GameObject soup;

    // Use this for initialization
    void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateTimer();
        spawnItems();
    }

    public void updateTimer()
    {
        Timer += Time.deltaTime;
        if (Timer >= TimeLimit)
        {
            TimeLimit = 0;
            Timer = 0;
            
        }
    }


    void spawnItems()
    {
        if (Timer >= 2f)
        {
            Instantiate(bagel, transform.position, transform.rotation);
            
        }
           if (Timer >= 4f)
        {
            Instantiate(burger,new Vector3(1,0.4f),transform.rotation);
        }
        if (Timer >= 6f)
        {
            Instantiate(coffee, new Vector3(2, 0.4f), transform.rotation);
        }
        if (Timer >= 8f)
        {
            Instantiate(juice, new Vector2(3, 0.4f), transform.rotation);
        }
        if (Timer >= 10f)
        {
            Instantiate(salad, new Vector2(4, 0.4f), transform.rotation);
        }
        if (Timer >= 12f)
        {
            Instantiate(smoothie, new Vector2(5, 0.4f), transform.rotation);
        }
        if (Timer >= 14f)
        {
            Instantiate(soda, new Vector2(6, 0.4f), transform.rotation);
        }
        if (Timer >= 16f)
        {
            Instantiate(soup, new Vector2(7, 0.4f), transform.rotation);
        }
    }
}

