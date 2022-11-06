/*
 * (Shaun Tornilla)
 * (Assignment5B - 3D Level)
 * (Handles text for title, controls, and objectives)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    public Text titleText;
    public Text objectiveText;
    public Text controlText;
    public Text bestTimeText;

    // Start is called before the first frame update
    void Start()
    {
        if (titleText == null)
        {
            titleText = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        }

        if (objectiveText == null)
        {
            objectiveText = GameObject.FindGameObjectWithTag("Objectives").GetComponent<Text>();
        }

        if (controlText == null)
        {
            controlText = GameObject.FindGameObjectWithTag("Controls").GetComponent<Text>();
        }

        if (bestTimeText == null)
        {
            bestTimeText = GameObject.FindGameObjectWithTag("BestTime").GetComponent<Text>();
        }

        bestTimeText.text = "Best Time: " + PlayerPrefs.GetFloat("BestTime").ToString("F3") + " seconds";
    }

    private void OnTriggerEnter(Collider other)
    {
        titleText.enabled = false ;
        objectiveText.enabled = false;
        controlText.enabled = false;
        bestTimeText.enabled = false;
    }
}
