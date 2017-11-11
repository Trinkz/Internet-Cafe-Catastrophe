using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour {
    public int scoreValue;
    public float Timer = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GainMoney();
        Timer -= Time.deltaTime;
        FinalScreen();
    }

    void GainMoney()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            scoreValue += 1;
           
        }
    }

    void FinalScreen()
    {
        if (Timer <= 0)
        {
            if (scoreValue <= 3 )
            {
                print("lose");

            }

            if (scoreValue >= 4)
            {
                print("win");

            }
            Time.timeScale = 0;
        }
    }

}
