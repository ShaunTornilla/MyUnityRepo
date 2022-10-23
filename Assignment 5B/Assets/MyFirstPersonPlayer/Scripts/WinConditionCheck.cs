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

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        accuracy = checks.shotsHit / checks.totalShots;

        if (other.CompareTag("Player") && checks.targetCount == 45)
        {
            won = true;

            // Displays lose message
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
        }

        // LOST
        if (won == false && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won == false && Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
        }

        // How to end the game at any time
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}