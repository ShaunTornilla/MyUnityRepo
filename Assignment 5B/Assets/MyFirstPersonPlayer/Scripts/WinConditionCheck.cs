/*
 * (Shaun Tornilla)
 * (Assignment5B - 3D Level)
 * (Code that handles what happens when you win)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinConditionCheck : MonoBehaviour
{
    public HUDBehavior checks;
    public Text winText;
    public Text statsText;
    public Text newRecordText;

    private float accuracy;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        checks = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDBehavior>();

        
        if(winText == null)
        {
            winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>();
        }

        if (statsText == null)
        {
            statsText = GameObject.FindGameObjectWithTag("Stats").GetComponent<Text>();
        }

        if (newRecordText == null)
        {
            newRecordText = GameObject.FindGameObjectWithTag("NewRecord").GetComponent<Text>();
        }

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        accuracy = checks.shotsHit / checks.totalShots;

        if (other.CompareTag("Player") && checks.targetCount == 45)
        {
            won = true;

            // CHECKS FOR NEW RECORD
            if (PlayerPrefs.GetFloat("BestTime") == 0)
            {
                PlayerPrefs.SetFloat("BestTime", checks.finalTime);
            }
            // Checks if it's a new best time
            if (checks.finalTime < PlayerPrefs.GetFloat("BestTime"))
            {
                // Stores the best time away from scene reload
                PlayerPrefs.SetFloat("BestTime", checks.finalTime);
                newRecordText.text = "NEW RECORD!\nTime: " + checks.finalTime.ToString("F3") + " seconds";

            }
            // Treat it like any other time
            else
            {
                statsText.text = "Time: " + checks.finalTime.ToString("F3") + " seconds";
            }


            // Displays win message
            winText.text = "You won!\nWould you like to play again? (Y/N)";

            // Displays Stats
            statsText.text = "=== STATS ===\nTargets Hit: " + checks.targetCount +
                "\nTotal Shots: " + checks.totalShots +
                "\nAccuracy: " + accuracy + "%";
        }
        else
        {
            // Displays lose message
            winText.text = "You lost!\nTry again? (Y/N)";

            // Displays Stats
            statsText.text = "=== STATS ===" + 
                "\nTargets Hit: " + checks.targetCount +
                "\nTotal Shots: " + checks.totalShots +
                "\nAccuracy: " + accuracy + "%";
        }

    }

    private void Update()
    {
        // WIN
        if (won == true && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won == true && Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
            PlayerPrefs.DeleteKey("BestTime");
        }

        // LOST
        if (won == false && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won == false && Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
            PlayerPrefs.DeleteKey("BestTime");
        }

        // How to end the game at any time
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            PlayerPrefs.DeleteKey("BestTime");
        }

        // How to reset the game at any time
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}