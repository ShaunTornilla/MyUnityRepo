using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to food and animal prefabs
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem healthSystemScript;

    private void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Separating the food from the animals going out of bounds
        // Food goes out of bounds
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        // Animals go out bounds
        if(transform.position.z < bottomBound)
        {
            //Debug.Log("Game Over!");

            // Grab HealthSystems script and call TakeDamage()
            healthSystemScript.TakeDamage();
            Destroy(gameObject);
        }

    }
}
