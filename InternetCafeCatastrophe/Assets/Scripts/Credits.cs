using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
   

    public GameObject scrollText;

    public int speed = 2;

    public string levelToLoad;

    public float creditsTimer;

    private void Start()
    {
        Time.timeScale = 1;
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(creditsTimer);
        SceneManager.LoadScene(levelToLoad);
    }

    // Update is called once per frame
    void Update()
    { 
        if (scrollText != null)
        {
            scrollText.transform.Translate(Vector2.up * Time.deltaTime * speed);

            StartCoroutine(WaitTimer());

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
