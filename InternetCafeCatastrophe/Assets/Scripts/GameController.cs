/* Name: Jose Guzman
 * Date: 06/1/2017
 * Credit:
 * Purpose:
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public DeskAvailable boolChanger;
    public SecurityGenerator Security;
    public GameController healthAccess;

    GameObject pauseCon;
    PauseGame pauseG;

    [SerializeField]
    private Text DPHLabel;

    private float _DPHealth;

    public float DPHealth;

    private int maxDPHealth = 100;

    private bool isInvulnerable = false;


    public Upgrades UpgradesScript;

    public Button ExitButton;
    public Button RestartButton;
    //public GUIText scoreText;
    public Text currencyText;
    public Transform canvas;
    // private int _numCoins;
    public int score;

    public int ObjectiveScore;

    // [SerializeField]
    // private Text coins;

    public static string guardS1 = "empty";
    public static string guardS2 = "empty";
    public static string guardS3 = "empty";
    public static string fbi = "empty";
    bool isPaused = false;

    bool jan;

    public int JanitorText;

    string SceneName;
    Scene currentScene;

    public GameObject LoseText;
    public GameObject WinText;
    public int TriggerContinue;

    public GameObject Warning;
   
    // Use this for initialization
    void Start()
    {
        // Scene references
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;


        jan = false;
        pauseCon = GameObject.Find("PauseController");
        pauseG = pauseCon.GetComponent<PauseGame>();

        DPHLabel = GameObject.Find("DPHtext").GetComponent<Text>();

        DPHealth = maxDPHealth;

        score = 200;
        SetCurrencyText();
        canvas.gameObject.SetActive(false);

        JanitorText = 1;

        GetComponent<AudioSource>().Play();

        LoseText.SetActive(false);
        WinText.SetActive(false);

    }

    void Update()
    {
        DPHLabel.text = FormatDPHealth(GetPlayerDPHHealthPercentage());
        UpdateScore();
        FinalScreen();
        GainMoney();
        NegMoney();
        


    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        currencyText.text = "Currency: " + score.ToString() + "/" + ObjectiveScore.ToString();

        //coins.text = Instance.NumCoins.tag.ToString();
    }

    // game over man game over.....
    void FinalScreen()
    {
        if (SceneName == "ICC_Stage1")
            {
            if (score < 0)
            {
                // currencyText.text = " You lose ";
                // canvas.gameObject.SetActive(true);
                // LoseText.SetActive(true);
                Warning.SetActive(true);
               // MakeContinueDisappear();
                Time.timeScale = 0;
                pauseG.isPaused = true;
                GetComponent<AudioSource>().Stop();
            }

            if (score >= 2000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PhaseTwo();

            }
            if (score >= 4000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P3 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PhaseThree();
            }
            if (score >= 6000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P4 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PhaseFour();
            }
            if (score >= 8000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P5 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PhaseFive();
            }
            if (score >= 10000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P6 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PhaseSix();
            }
            if (score >= 12000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P7 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().PhaseSeven();
            }
            if (score >= 14000)
            {
                canvas.gameObject.SetActive(true);
                WinText.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                //Debug.Log("YOU FUCKING SURVIVED!!! OMG HOW!!!");
            }

        }
        // *********************************************************Level One**************************************************
        else if (SceneName == "LevelOne")
        {
            if (score < 0)
            {
                currencyText.text = " You lose ";
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                GetComponent<AudioSource>().Stop();
                LoseText.SetActive(true);
                MakeContinueDisappear();
            }

            

            if (score >= 1500 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_2 == false)

            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelOnePhases();
            }
            if (score >= 3000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L1_3 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelOnePhases();

            }
            if (score >= 5000)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                WinText.SetActive(true);
            }
        }

        // *********************************************************Level Two**************************************************
        else if (SceneName == "LevelTwo")
        {
            if (score < 0)
            {
                currencyText.text = " You lose ";
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                GetComponent<AudioSource>().Stop();
                LoseText.SetActive(true);
                MakeContinueDisappear();
            }
            if (score >= 2000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_2 == false)

            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelTwoPhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 4000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_3 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelTwoPhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 6000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_4 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelTwoPhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 8000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L2_5 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelTwoPhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 10000)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                WinText.SetActive(true);
            }
        }

        // *********************************************************Level Three**************************************************
        else if (SceneName == "LevelThree")
        {
            if (score < 0)
            {
                currencyText.text = " You lose ";
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                GetComponent<AudioSource>().Stop();
                LoseText.SetActive(true);
                MakeContinueDisappear();
            }
            if (score >= 2000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_2 == false)

            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 4000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_3 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 6000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_4 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 8000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_5 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 10000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_6 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 12000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_7 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 14000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_8 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 16000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L3_9 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().LevelThreePhases();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 18000)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                WinText.SetActive(true);
            }
        }

        // *********************************************************Endless Level**************************************************
        else if (SceneName == "Endless")
        {
            if (score < 0)
            {
                currencyText.text = " You lose ";
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseG.isPaused = true;
                GetComponent<AudioSource>().Stop();
                LoseText.SetActive(true);
                MakeContinueDisappear();
            }
            if (score >= 2000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_2 == false)

            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 4000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_3 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 6000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_4 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 8000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_5 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 10000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_6 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 12000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_7 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 14000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_8 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= 16000 && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_9 == false)
            {
                GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().Endless();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
            if (score >= ObjectiveScore && GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().L4_9 == true)
            {
                ObjectiveScore += 2000;
                UpdateScore();
                GameObject.Find("ObjectiveListHolder").GetComponent<ObjectiveList>().serve = 0;
            }
        }
    }

    public void GainMoney()
    {
        if (Input.GetKeyDown(KeyCode.W) && pauseG.isPaused == false && GameObject.FindObjectOfType<Tutorial>().Paused == false)
        {
            AddScore(1000);
            
        }
        
    }

    void SetCurrencyText()
    {
        currencyText.text = "Currency: " + score.ToString() + "/" + ObjectiveScore;
    }

    public void RestartClick()
    {
        if (SceneName == "ICC_Stage1")
        {
            SceneManager.LoadScene("ICC_Stage1");

            GameObject.Find("Desks").GetComponent<Upgrades>().ResetFood();

            GFReset();
        }


         else if (SceneName == "LevelOne")
        {
            SceneManager.LoadScene("Level1CutScene");

            GameObject.Find("Desks").GetComponent<Upgrades>().ResetFood();

            GFReset();
        }
    }

    public void ExitClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        GameObject.Find("Desks").GetComponent<Upgrades>().ResetFood();
        GFReset();

    }

    public void DecrementPlayerHealth(int _value)
    {
        if (isInvulnerable)
        {
            //Debug.Log("I am now returning due to being invulnerable");
            return;
        }

        StartCoroutine(InvulnerableDelay());

        // DPHealth--;
        DPHealth -= _value;

        if (DPHealth <= 0)
        {
            Restart();
        }
        //Debug.Log("dphhealth amount is" + DPHealth);
    }

    public void IncrementPlayerHealth(int _value)
    {
        if (isInvulnerable)
        {
            //Debug.Log("I am now returning due to being invulnerable");
            return;
        }

        StartCoroutine(InvulnerableDelay());

        if (DPHealth == 100)
        {
            return;
        }

        else if (DPHealth <= 100)
        {
            // DPHealth++;
            DPHealth += _value;
        };

        if (DPHealth <= 0)
        {
            Restart();
        }
        //Debug.Log("dphhealth amount is" + DPHealth);
    }

    private void Restart()
    {
        //Debug.Log("I am going to restart due to low dph");
        //SceneManager.LoadScene("ICC_Stage1");
        DPHealth = maxDPHealth;
        FinalScreen();
        GameObject.Find("Desks").GetComponent<Upgrades>().ResetFood();
        GFReset();
    }

    private IEnumerator InvulnerableDelay()
    {
        //Debug.Log("I am invulnerable for 1 sec!");
        isInvulnerable = true;
        yield return new WaitForSeconds(1.0f);
        isInvulnerable = false;
    }

    public float GetPlayerDPHHealthPercentage()
    {
        //Debug.Log("I am getting the percent dph health to display");
        return DPHealth / (float)maxDPHealth;
    }

    private string FormatDPHealth(float healthPercentage)
    {
        //Debug.Log("I am formatting the health percent");
        return string.Format("DPH= {0}%", Mathf.RoundToInt(healthPercentage * 100));
    }

    public void Score1(int _value)
    {
        ObjectiveScore = _value;
    }

    public void Janitor()
    {
        if (jan == false && GameObject.Find("GameController").GetComponent<GameController>().score >= 1001)
        {
            AddScore(-1000);
            GameObject.Find("Desks").GetComponent<Upgrades>().JanitorButton.GetComponentInChildren<Text>().text = "Janitor - " + "Complete";
            jan = true;
            JanitorText = 2;
            GameObject.Find("Janitor Button").GetComponent<Button>().interactable = false;


        }
        else if (jan == false)
           GameObject.Find("Janitor Button").GetComponent<Button>().interactable = true;
          
        
    }

    void NegMoney()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(-1000);
        }
    }

    void GFReset()
    {
        guardS1 = "empty";
        guardS2 = "empty";
        guardS3 = "empty";
        fbi = "empty";

    }

    public void LoadLevel1Cutscene()
    {
        SceneManager.LoadScene("Level1CutScene");
    }

    public void LoadLevel2Cutscene()
    {
        SceneManager.LoadScene("Level2CutScene");
    }

    public void LoadLevelEndless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void LoadLevel3Cutscene()
    {
        SceneManager.LoadScene("Level3CutScene");
    }

    void MakeContinueDisappear()
    {
        if (LoseText.activeInHierarchy == true && canvas.gameObject.activeInHierarchy == true && SceneName != "LevelThree")
        {
            TriggerContinue++;
        }

        if (TriggerContinue == 1)
        {
            GameObject.Find("Continue Button").SetActive(false);



        }

        else

            return;
    }

   public void CancelWarning()
    {
        Time.timeScale = 1;
        pauseG.isPaused = false;
        GetComponent<AudioSource>().Play();

        if(GameObject.Find("Game Icon Controller").GetComponent<Tutorial>().P2 == true)
        {
            score = 1000;
        }
        else
        {
            score = 200;
        }
        
    }

}