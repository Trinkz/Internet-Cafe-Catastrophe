/* Name: Dilon Erlandson
 * Date: 08/04/2017
 * Credit: sound for when the flood occurs. https://freesound.org/people/felix.blume/sounds/234240/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloodScript : MonoBehaviour
{
    public Button FloodButton;

    public GameObject flood;

    float FloodTimer;

    int RangeForFlood;

    public bool floodActive = false;

    [SerializeField]
    AudioClip FO;

   
    void Update()
    {
        if (flood.activeInHierarchy == false)
        {
            FloodTimer += Time.deltaTime;
            
        }

        FloodOccur();

        if (Input.GetKeyDown(KeyCode.F) && flood.activeInHierarchy == false)
        {
            flood.SetActive(true);
            GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBlackOut();
            
            GetComponent<AudioSource>().PlayOneShot(FO);
        }
        else if (Input.GetKeyDown(KeyCode.F) && flood.activeInHierarchy == true)
        {
            flood.SetActive(false);
            GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBlackOutFix();
           
            GetComponent<AudioSource>().Stop();
        }
    }

    void FloodOccur()
    {

        if (GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == true)
        {
           
            if (flood.activeInHierarchy == false && floodActive == false)
            {
              //  Debug.Log("random range =" + RangeForFlood);
                RangeForFlood = Random.Range(50, 70);
                floodActive = true;
                GetComponent<AudioSource>().Stop();
            }
            if (FloodTimer >= RangeForFlood)
            {
                flood.SetActive(true);
                GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBlackOut();

                FloodTimer = 0f;
                floodActive = false;
                GetComponent<AudioSource>().PlayOneShot(FO);
            }
            else return;
        }
    }

    public void ButtonFloodFix()
    {
        flood.SetActive(false);
        
        GetComponent<AudioSource>().Stop();
        GameObject.Find("Blackout holder").GetComponent<Blackout>().FloodBlackOutFix();
    }

    

}
