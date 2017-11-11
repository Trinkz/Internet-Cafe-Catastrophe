using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Customer")) 
		{
			Destroy (gameObject);
			//Debug.Log ("Gain 65 currency");
		}

	}
		
}
