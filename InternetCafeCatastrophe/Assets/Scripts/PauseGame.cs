using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{
    public DeskAvailable boolChanger;

    public bool isPaused = false;

    public Transform canvas;

    public Upgrades upgradeScript;
    public GameObject upgradeCanvas;

    public GameObject upgradesButtonPanel;
    public GameObject pauseCanvas;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            if (GameObject.Find("Game Icon Controller").GetComponentInChildren<Tutorial>().Paused == true && canvas.gameObject.activeInHierarchy == false && isPaused == false)
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 0;
                isPaused = false;
                
            }
        }
        if (upgradesButtonPanel.activeInHierarchy == true)
        {

            //Debug.Log("timescale was 0 =" + Time.timeScale);
            Time.timeScale = 0;
        }
        if (upgradesButtonPanel.activeInHierarchy == false && pauseCanvas.activeInHierarchy == false && isPaused == false && GameObject.Find("Game Icon Controller").GetComponentInChildren<Tutorial>().Paused == false)
        {
            //Debug.Log("timescale was 1 =" + Time.timeScale);
            Time.timeScale = 1;

        }
    }


    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false && isPaused == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            GameObject.Find("GameController").GetComponent<AudioSource>().Pause();
           
            upgradeCanvas.SetActive(false);
        }
        
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            GameObject.Find("GameController").GetComponent<AudioSource>().UnPause();
           
            upgradeCanvas.SetActive(true);
        }
    }

    public void ClickTest()
    {
        if (canvas.gameObject.activeInHierarchy == false && isPaused == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            GameObject.Find("GameController").GetComponent<AudioSource>().Pause();
           
            upgradeCanvas.SetActive(false);
        }

        if (GameObject.Find("Game Icon Controller").GetComponentInChildren<Tutorial>().Paused == true )
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 0;
            isPaused = false;
            GameObject.Find("GameController").GetComponent<AudioSource>().UnPause();
           
            upgradeCanvas.SetActive(false);
        }

        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            GameObject.Find("GameController").GetComponent<AudioSource>().UnPause();
          
            upgradeCanvas.SetActive(true);
        }
      //  Debug.Log("clicked");
    }

    public void ExitClick()
    {
        Application.Quit();
        
    }

    public void ExitToMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        isPaused = false;
        
    }

}


