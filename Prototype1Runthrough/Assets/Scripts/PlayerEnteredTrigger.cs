/*
 * Shaun Tornilla
 * Prototype1Runthrough
 * Unused Script when player enters a trigger. TriggerZoneAddScoreOnce overwrote this.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to the player

public class PlayerEnteredTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }
}

