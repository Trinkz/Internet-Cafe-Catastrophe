using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestList : MonoBehaviour {

    private ObjectiveList ObjList;

    public string[] List= new string[12];

    // Use this for initialization
    void Start () {
        ObjList = GameObject.FindObjectOfType<ObjectiveList>();

        ObjList.CreateObjective(1,List[0]);
        ObjList.CreateObjective(2,List[1]);
        ObjList.CreateObjective(3, List[2]);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
