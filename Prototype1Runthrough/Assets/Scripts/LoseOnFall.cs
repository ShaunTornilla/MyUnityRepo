/*
 * Shaun Tornilla
 * Prototype1Runthrough
 * Script for what happens when you fall
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attach Script to Player

public class LoseOnFall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
