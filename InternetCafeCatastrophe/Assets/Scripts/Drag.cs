/*Name: Jose Guzman
 * Date: 05/29/2017
 * Credit: Unity tutorial: Smooth Drag and drop in unity (https://www.youtube.com/watch?v=NMt6Ibxa_XQ&list=PLVjg58TCNpZbcybvEi134H0oCsBe_Zo9d&index=1)
 * Unity Scripting API - MonoBehaviour.OnMouseDown (https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseDown.html)
 * 
 * Purpose: Be able to click on objects and drag them around.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour 
{
   public string foodTag;
    Vector3 dist;
	float posX;
	float posY;
	Collider coll;
    public string foodType;
    
    
    //Food Gens;
        public GameObject Bagel;
        public GameObject Burger;
        public GameObject Smoothie;
        public GameObject Soda;
        public GameObject Salad;
        public GameObject Juice;
        public GameObject Coffee;
        public GameObject Soup;

    
 

    // Food Gen SCript
    FoodGen bagel;
    FoodGen burger;
    FoodGen smoothie;
    FoodGen soda;
    FoodGen salad;
    FoodGen juice;
    FoodGen coffee;
    FoodGen soup;
    public Renderer rend;
    private Color startcolor;

    void Start()
	{
        Bagel = GameObject.Find("Bagel Gen");
        Burger = GameObject.Find("Burger Gen");
        Smoothie = GameObject.Find("Smoothie Gen");
        Soda = GameObject.Find("Soda Gen");
        Salad = GameObject.Find("Salad Gen");
        Juice = GameObject.Find("Juice Gen");
        Coffee = GameObject.Find("Coffee Gen");
        Soup = GameObject.Find("Soup Gen");


        coll = GetComponent<Collider> ();

		coll.isTrigger = false;

        bagel = Bagel.GetComponent<FoodGen>();
        burger = Burger.GetComponent<FoodGen>();
        smoothie = Smoothie.GetComponent<FoodGen>();
        soda = Soda.GetComponent<FoodGen>();
        salad = Salad.GetComponent<FoodGen>();
        juice = Juice.GetComponent<FoodGen>();
        coffee = Coffee.GetComponent<FoodGen>();
        soup = Soup.GetComponent<FoodGen>();
        rend = GetComponent<Renderer>();
        
    }

	void OnMouseDown()
	{
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);
       // Debug.Log("This hit at " + hit.transform.tag + "is being dragged");
        dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
        foodTag = hit.transform.tag;
        foodType = hit.transform.name;
        coll.isTrigger = true;

        FoodCheck();
	}

	void OnMouseDrag()
	{
        
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY,dist.z );

		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);

		transform.position = worldPos;
	}

    public void FoodCheck()
    {
        if(foodTag == "Bagel" || foodType == "bagel(Clone)")
        {
            bagel.Bagel = false;
        }
        else if(foodTag == "Burger" || foodType == "burger(Clone)")
        {
            burger.Burger = false;
        }
        else if(foodTag == "Coffee" || foodType == "coffee(Clone)")
        {
            coffee.Coffee = false;
        }
        else if (foodTag == "Juice" || foodType == "juice(Clone)")
        {
            juice.Juice = false;
        }
        else if (foodTag == "Smoothie" || foodType == "smoothie(Clone)")
        {
            smoothie.Smoothie = false;
        }
        else if (foodTag == "Soda" || foodType == "soda(Clone)")
        {
            soda.Soda = false;
        }
        else if (foodTag == "Salad" || foodType == "salad(Clone)")
        {
            salad.Salad = false;
        }
        else if (foodTag == "Soup" || foodType == "soup(Clone)")
        {
            soup.Soup = false;
        }
        else
        {
            return;
        }
    }

   

    void OnMouseEnter()

    {
        startcolor = GetComponent<Renderer>().material.color;
        //startcolor = rend.material.color;
        rend.material.color = Color.cyan;
        
    }

    void OnMouseExit()
    {

        //rend.material.color = startcolor;
         GetComponent<Renderer>().material.color = startcolor;

    }
}
