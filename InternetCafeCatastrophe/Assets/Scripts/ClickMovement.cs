/* Name: Jose Guzman
 * Date: 06/08/2017
 * Credit: Select and move 1 object, problem = moving multiple. http://answers.unity3d.com/questions/826501/select-and-move-1-object-problem-moving-multiple.html 
 * Purpose: Be able to select an Guard and move it to a selected Hacker. ONLY the selected Guard should move to the Hacker selected.
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{
    public int Guiding = 0;
    private GameObject selectedUnit;


    // Use this for initialization
    void Start()
    {
        Guiding = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.tag == "Guard" && Input.GetMouseButtonDown(0))
            {
                if (selectedUnit != null)
                {
                    selectedUnit.SendMessage("Deselect", 1);
                }

                selectedUnit = hit.transform.gameObject;
                selectedUnit.SendMessage("Select", 1);

                //Debug.Log("Guard is selected");
            }

            if (hit.transform.tag == "Hacker" && Input.GetMouseButtonDown(1) && hit.transform.GetComponent<NavAgent>().reset == true && hit.transform.GetComponent<HackingTimer>().HackerSucceeded == false)
            {
                Guiding = 1;
                selectedUnit.SendMessage("Destination", hit.point);
                hit.transform.GetComponent<NavAgent>().isSelected = true;

               // Debug.Log("Hacker is selected");
            }

            if (hit.transform.tag == "Hacker" && Input.GetMouseButtonDown(0))
            {
                selectedUnit.SendMessage("Deselect", 1);
                hit.transform.GetComponent<NavAgent>().isSelected = false;

            }


            if (hit.transform.tag == "FBI" && Input.GetMouseButtonDown(0))
            {
                if (selectedUnit != null)
                {
                    selectedUnit.SendMessage("Deselect", 1);
                }

                selectedUnit = hit.transform.gameObject;
                selectedUnit.SendMessage("Select", 1);

                //Debug.Log("FBI is selected");
            }

                if (hit.transform.tag == "1337Hacker" && Input.GetMouseButtonDown(1) && hit.transform.GetComponent<NavAgent>().reset == true && selectedUnit.tag == "FBI")
                {
                    selectedUnit.SendMessage("Destination", hit.point);
                hit.transform.GetComponent<NavAgent>().isSelected = true;

                // Debug.Log("1337Hacker is selected");
            }

            if (hit.transform.tag == "1337Hacker" && Input.GetMouseButtonDown(0))
                {
                    selectedUnit.SendMessage("Deselect", 1);
                hit.transform.GetComponent<NavAgent>().isSelected = false;

            }

            if (hit.transform.tag == "Hacker" && Input.GetMouseButtonDown(1) && hit.transform.GetComponent<NavAgent>().reset == true && hit.transform.GetComponent<HackingTimer>().HackerSucceeded == false)
                {
                    selectedUnit.SendMessage("Destination", hit.point);
                hit.transform.GetComponent<NavAgent>().isSelected = true;

                //Debug.Log("Hacker is selected");
            }

            if (hit.transform.tag == "Hacker" && Input.GetMouseButtonDown(0))
                {
                    selectedUnit.SendMessage("Deselect", 1);
                hit.transform.GetComponent<NavAgent>().isSelected = false;

            }
        }
    }
}

