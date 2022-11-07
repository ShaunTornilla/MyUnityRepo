using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Targets
{ 
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 50f;
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log( amount + " points of damage dealt!");

        health -= amount;

        if (health <= 0)
        {
            Die();     
        }


    }

    public override void Die()
    {
        Debug.Log("Enemy is Dead!");
        Destroy(gameObject);
    }

    /*
    public override void checks()
    {
        // CHECKS FOR NEW RECORD
        if (PlayerPrefs.GetFloat("BestTime") == 0)
        {
            PlayerPrefs.SetFloat("BestTime", finalTime);
        }
        // Checks if it's a new best time
        if (finalTime < PlayerPrefs.GetFloat("BestTime"))
        {
            // Stores the best time away from scene reload
            PlayerPrefs.SetFloat("BestTime", finalTime);
            newRecordText.text = "NEW RECORD!\nTime: " + finalTime.ToString("F3") + " seconds";

        }
        // Treat it like any other time
        else
        {
            statsText.text = "Time: " + finalTime.ToString("F3") + " seconds";
        }

        // Updates target count when a target is hit
        if (shootWithRaycastsScript.GetComponent<Targets>() != null)
        {
            targetCount++;

        }

        targetText.text = "Targets: " + targetCount + "/45";
    }
    */
}
