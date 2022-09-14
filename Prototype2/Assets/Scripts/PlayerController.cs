/*
 * (Shaun Tornilla)
 * (Assignment3 Prototype 2)
 * (Code to Handle Player Controls.)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 14;

    // Update is called once per frame
    void Update()
    {
        // Get Horizontal Input from right and left arrow keys/ A and D
        horizontalInput = Input.GetAxis("Horizontal");

        // Transform horizontally with input
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);

        // Keep player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
