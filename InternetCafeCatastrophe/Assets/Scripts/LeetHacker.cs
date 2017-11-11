using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetHacker : MonoBehaviour {

    int MaxHits = 6;
    int CurHits = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && CurHits <= MaxHits)
        {

            CurHits += 1;
            Destroy(other.gameObject);
          //  Debug.Log("you fed the 1337 hacker");

            if (other.tag == "food" && CurHits >= MaxHits)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}
