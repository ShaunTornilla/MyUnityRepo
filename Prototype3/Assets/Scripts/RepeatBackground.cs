/*
 * Shaun Tornilla
 * Assignment 3
 * Smooths the background as player moves right
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth; 

    // Start is called before the first frame update
    void Start()
    {
        // Save starting position as a Vector3
        startPosition = transform.position;

        // Set the repeatwidth to half the width of the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // If the background is farther to the left than the repeatWidth, reset to start position.

        if(transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
