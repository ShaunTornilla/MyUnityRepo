/*
 * (Shaun Tornilla)
 * (Assignment3 Challenge 2)
 * (Score Display Code.)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach this script to a Text UI Object
public class DisplayScore : MonoBehaviour
{
    public Text textbox;
    public int score = 0;
    private void Start()
    {
        // Set up the reference to the Text Component on this GameObject
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;
    }
}