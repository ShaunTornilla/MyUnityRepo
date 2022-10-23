using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBehavior : MonoBehaviour
{
    public Text targetText;

    public ShootWithRaycasts shootWithRaycastsScript;

    public int targetCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(targetText == null)
        {
            targetText = GameObject.FindGameObjectWithTag("TargetText").GetComponent<Text>();
        }

        
        targetText.text = "Targets: 0/45";

        if(shootWithRaycastsScript == null)
        {
            // References to the shootWithRaycasts Script
            shootWithRaycastsScript = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<ShootWithRaycasts>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Updates target count when a target is hit
        if (shootWithRaycastsScript.GetComponent<Target>() != null)
        {
            targetCount++;
            
        }

        targetText.text = "Targets: " + targetCount + "/45";
    }
}
