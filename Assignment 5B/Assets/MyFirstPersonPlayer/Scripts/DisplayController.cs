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
    }

    private void OnTriggerEnter(Collider other)
    {
        titleText.text = "";
        objectiveText.text = "";
        controlText.text = "";
    }
}
