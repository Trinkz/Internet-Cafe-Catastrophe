using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingSlider : MonoBehaviour
{
    public Slider slider;
    public float fillMax;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void BeginSlider()
    {
        slider.value = Mathf.MoveTowards(slider.value, fillMax, Time.deltaTime);
    }
}
