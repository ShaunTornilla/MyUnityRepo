/*
 * (Shaun Tornilla)
 * (Assignment3 Challenge 2)
 * (Code to Handle Entity Movements (Balls, Dog).)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
