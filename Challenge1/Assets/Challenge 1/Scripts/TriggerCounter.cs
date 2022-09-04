/*
 * Shaun Tornilla
 * Prototype1Runthrough
 * Script for incrementing the score counter when you hit a trigger zone
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to a Trigger Zone

public class TriggerCounter : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}