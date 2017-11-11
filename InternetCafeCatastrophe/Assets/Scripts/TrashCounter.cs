using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashCounter : MonoBehaviour
{
    public GameObject trash1;
    public GameObject trash2;

    public int trashcount;
    public int trashMax;

    public bool TrashComplete;

    string SceneName;
    Scene currentScene;

    // Use this for initialization
    void Start ()
    {
        TrashComplete = false;
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
    }
	
	// Update is called once per frame
	void Update ()
    {
        trashCount();
    }
    void trashCount()
    {
       if(SceneName == "ICC_Stage1")
        {
            if (trash1.GetComponent<trash>().DishCount == true)
            {
                trashcount++;
                trash1.GetComponent<trash>().DishCount = false;
            }
            if (trash2.GetComponent<trash>().DishCount == true)
            {
                trashcount++;
                trash2.GetComponent<trash>().DishCount = false;
            }
            if (trashcount >= trashMax)
            {
                TrashComplete = true;
            }
        }

       else if (SceneName == "LevelOne")
        {
            if (trash1.GetComponent<trash>().DishCount == true)
            {
                trashcount++;
                trash1.GetComponent<trash>().DishCount = false;
            }
            if (trash2.GetComponent<trash>().DishCount == true)
            {
                trashcount++;
                trash2.GetComponent<trash>().DishCount = false;
            }
            if (trashcount >= trashMax)
            {
                TrashComplete = true;
            }
        }
        else if (SceneName == "LevelTwo")
        {
            if (trash1.GetComponent<trash>().DishCount == true)
            {
                trashcount++;
                trash1.GetComponent<trash>().DishCount = false;
            }
            if (trash2.GetComponent<trash>().DishCount == true)
            {
                trashcount++;
                trash2.GetComponent<trash>().DishCount = false;
            }
            if (trashcount >= trashMax)
            {
                TrashComplete = true;
            }
        }
    }


    public void ResetCounter()
    {
        trashcount = 0;
    }
}
