using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlight : MonoBehaviour
{

    private Color startcolor;

    bool selected = false;

    void OnMouseOver()
    {
        if (selected == false)
        { 
         //   Debug.Log("I have been selected");
        
            startcolor = GetComponent<Renderer>().material.color;

         //   Debug.Log("start color" + startcolor);

            gameObject.GetComponent<Renderer>().material.color = Color.yellow;

         //   Debug.Log("Material color " + GetComponent<Renderer>().material.color);

            selected = true;
        }
        else if (selected == true)
        {
            gameObject.GetComponent<Renderer>().material.color = startcolor;
            selected = false;
        }
    }
}
