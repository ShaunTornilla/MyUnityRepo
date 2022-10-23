﻿/*
 * (Shaun Tornilla)
 * (Assignment5B - 3D Level)
 * (Code that keeps track of time)
 * also if there was a better way to do this part please lmk lol
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopClock : MonoBehaviour
{
    public float finalTime;

    public StartClock startClockScript;
    public HUDBehavior hudBehaviorScript;
    public Text display;
    public Text newRecordText;
    public Text bestTimeText;

    public bool newBestTime;


    private void Start()
    {
        newBestTime = false;

        if (display == null)
        {
            display = GameObject.FindGameObjectWithTag("Clock").GetComponent<Text>();
        }

        if (newRecordText == null)
        {
            newRecordText = GameObject.FindGameObjectWithTag("NewRecord").GetComponent<Text>();
        }

        if (bestTimeText == null)
        {
            bestTimeText = GameObject.FindGameObjectWithTag("BestTime").GetComponent<Text>();
        }

        if (hudBehaviorScript == null)
        {
            hudBehaviorScript = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDBehavior>();
        }

        if (startClockScript == null)
        {
            startClockScript = GameObject.FindGameObjectWithTag("Start").GetComponent<StartClock>();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        startClockScript.startClock = false;

        finalTime =  Time.time - startClockScript.time;
        hudBehaviorScript.finalTime = finalTime;

    }
}
