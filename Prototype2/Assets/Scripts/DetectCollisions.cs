using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach Script to Food Prefab
public class DetectCollisions : MonoBehaviour
{
    public DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
