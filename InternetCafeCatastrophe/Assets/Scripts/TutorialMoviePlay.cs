using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMoviePlay : MonoBehaviour {

    public MovieTexture movie;
    bool isplaying;
    int vsync;

	// Use this for initialization
	void Start ()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        isplaying = false;
        vsync = QualitySettings.vSyncCount;
        QualitySettings.vSyncCount = 0;
        movie.loop = true;

        movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void PlayMovie()
    {

        if(isplaying == false)
        {
            movie.Play();
            isplaying = true;
;
        }
        else if(isplaying == true)
        {
            movie.Pause();
            isplaying = false;

        }
        
    }
  public void MovieStop()
    {
        movie.Stop();
    }
}
