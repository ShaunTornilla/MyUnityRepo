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
    public float startTime;

    public float time;
    public bool startClock;

    public Text display;

    public HUDBehavior hudBehaviorScript;

    private void Start()
    {
        time = 0;

        startClock = false;

        if(display == null)
        {
            display = GameObject.FindGameObjectWithTag("Clock").GetComponent<Text>();
        }

        if (hudBehaviorScript == null)
        {
            hudBehaviorScript = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDBehavior>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        time = Time.time;
        hudBehaviorScript.startTime = Time.time - startTime;
        startClock = true;
    }

    private void Update()
    {
        startTime = Time.time - time;

        if (startClock)
        {
            display.text = "Time: " + startTime.ToString("F3") + " second(s)";
        }
   

    }



}
