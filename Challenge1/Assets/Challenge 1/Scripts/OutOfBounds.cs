/*
 * Shaun Tornilla
 * Prototype1Runthrough
 * Script for what happens when you hit out of bounds
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attach Script to Player

public class OutOfBounds : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 80 || transform.position.y <= -51)
        {
            ScoreManager.gameOver = true;
        }
    }
}
