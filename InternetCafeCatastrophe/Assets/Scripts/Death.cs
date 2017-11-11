using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    [SerializeField]
    AudioClip jail;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.tag == "Guard")
        {
            GetComponent<AudioSource>().PlayOneShot(jail);
        }
        if(other.tag == "FBI")
        {
            GetComponent<AudioSource>().PlayOneShot(jail);
        }
    }
}
