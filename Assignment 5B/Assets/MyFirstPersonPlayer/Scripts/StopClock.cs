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

    private void Start()
    {
        if (display == null)
        {
            display = GameObject.FindGameObjectWithTag("Clock").GetComponent<Text>();
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

        finalTime =  Time.time - startClockScript.time ;

        display.text = "Time: " + finalTime.ToString("F3") + " seconds";

        hudBehaviorScript.finalTime = finalTime;
    }
}
