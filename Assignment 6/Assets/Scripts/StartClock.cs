/*
 * (Shaun Tornilla)
 * (Assignment5B - 3D Level)
 * (Code that keeps track of time)
 * also if there was a better way to do this part please lmk lol
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartClock : MonoBehaviour
{
    public float time;

    public Text display;

    public DisplayManager displayManagerScript;

    private void Start()
    {
        time = 0;

        if(display == null)
        {
            display = GameObject.FindGameObjectWithTag("Clock").GetComponent<Text>();
        }

        if (displayManagerScript == null)
        {
            displayManagerScript = GameObject.FindGameObjectWithTag("DisplayManager").GetComponent<DisplayManager>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        time = Time.time;
        displayManagerScript.startTime = Time.time;
        displayManagerScript.startClock = true;
    }

    private void Update()
    {
        displayManagerScript.startTime = Time.time - time;

        if (displayManagerScript.startClock)
        {
            display.text = "Time: " + displayManagerScript.startTime.ToString("F3") + " second(s)";
        }
   

    }



}
