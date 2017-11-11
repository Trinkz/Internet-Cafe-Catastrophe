using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    AsyncOperation aOp;
    public Slider loadingBar;
    public Text loadingText;
    public GameObject MainMenuFirst;
    public GameObject loadingBG1;
    public GameObject loadingBG2;



    public bool isFakeLoadingBar = false;
    public float fakeTimerIncrement = 0.0f;
    public float fakeTimer = 0.0f;

    public bool onTrigger = false;

    public string credits;
    public string exit;

    

    private void Start()
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
    }


    void Update()
    {
        if (onTrigger == true)
        {
            LoadLevel();
        }
    }


    public void LoadLevel()
    {
        loadingBar.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        loadingBG1.SetActive(true);
        loadingBG2.SetActive(true);
        MainMenuFirst.SetActive(false);

        loadingText.text = "Loading. . .";

        if (!isFakeLoadingBar)
        {
            StartCoroutine(LoadWithRealLoadTime());
        }
        else
        {
            StartCoroutine(LoadWithFakeTimer());
        }

    }

    public void ClickToCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void ClickToExit()
    {
        Application.Quit();
    }

    IEnumerator LoadWithFakeTimer()
    {
        yield return new WaitForSeconds(1);

        while (loadingBar.value != 1.0f)
        {
            loadingBar.value += fakeTimerIncrement;
            yield return new WaitForSeconds(fakeTimer);
        }

        while (loadingBar.value == 1f)
        {
            loadingText.text = "Press 'F' To Continue";
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("ICC_Stage1");
            }
            yield return null;
        }

    }

    IEnumerator LoadWithRealLoadTime()
    {
        yield return new WaitForSeconds(1);

        aOp = SceneManager.LoadSceneAsync(2);
        aOp.allowSceneActivation = false;

        while (!aOp.isDone)
        {
            loadingBar.value = aOp.progress;

            if (aOp.progress == 0.9f)
            {
                loadingBar.value = 1f;
                loadingText.text = "Press Space To Continue";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    aOp.allowSceneActivation = true;
                }
            }
          //  Debug.Log(aOp.progress);
            yield return null;
        }
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

   public void LoadLevelSelectScreen()
    {
        SceneManager.LoadScene("LevelSelectScreen");
    }

   public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1Cutscene()
    {
        SceneManager.LoadScene("Level1CutScene");
    }

    public void LoadLevel2Cutscene()
    {
        SceneManager.LoadScene("Level2CutScene");
    }

    public void LoadLevel3Cutscene()
    {
        SceneManager.LoadScene("Level3CutScene");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void LoadLevelEndless()
    {
        SceneManager.LoadScene("Endless");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("ICC_Stage1");
    }

}
