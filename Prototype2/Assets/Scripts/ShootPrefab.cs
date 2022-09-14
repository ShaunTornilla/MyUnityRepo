/*
 * (Shaun Tornilla)
 * (Assignment3 Prototype 2)
 * (Code to Generate Projectile Prefab.)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to Player
public class ShootPrefab : MonoBehaviour
{
    // Set reference in the inspector
    public GameObject prefabToShoot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);
        }
        
    }
}
