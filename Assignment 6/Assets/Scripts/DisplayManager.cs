/*
 * (Shaun Tornilla)
 * (Assignment5B - 3D Level)
 * (Handles some UI elements on the HUD)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayManager : MonoBehaviour
{
    public Text targetText;
    public Text coinText;
    public Text titleText;
    public Text objectiveText;
    public Text controlText;
    public Text bestTimeText;
    public Text newRecordText;
    public Text statsText;
    public Text winText;
    public Text clockText;
    public Image reticleImage;

    // Stats Shite
    public float shotsHit = 0;
    public float totalShots = 0;
    public float startTime = 0;
    public float finalTime = 0;
    public int targetCount = 0;
    public int greenCoinCount = 0;
    public int purpleCoinCount = 0;
    public int redCoinCount = 0;
    private float accuracy;

    public bool done = false;
    public bool won = false;
    public bool paused = false;
    public bool UI = false;
    public bool start = false;
    public bool triggered = false;
    //public bool startClock = false;
    public ShootWithRaycasts shootWithRaycastsScript;

    // Start is called before the first frame update
    void Start()
    {
        /*
        
        if (coinText == null)
        {
            coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
        }
        
         */

        if (clockText == null)
        {
            clockText = GameObject.FindGameObjectWithTag("Clock").GetComponent<Text>();
        }

        if (titleText == null)
        {
            titleText = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        }
        if (objectiveText == null)
        {
            objectiveText = GameObject.FindGameObjectWithTag("Objectives").GetComponent<Text>();
        }
        if (controlText == null)
        {
            controlText = GameObject.FindGameObjectWithTag("Controls").GetComponent<Text>();
        }
        if (bestTimeText == null)
        {
            bestTimeText = GameObject.FindGameObjectWithTag("BestTime").GetComponent<Text>();
        }

        bestTimeText.text = "Best Time: " + PlayerPrefs.GetFloat("BestTime").ToString("F3") + " seconds";

        if (targetText == null)
        {
            targetText = GameObject.FindGameObjectWithTag("TargetText").GetComponent<Text>();
        }

        targetText.text = "Targets: 0/45";

        if (statsText == null)
        {
            statsText = GameObject.FindGameObjectWithTag("Stats").GetComponent<Text>();
        }

        if (newRecordText == null)
        {
            newRecordText = GameObject.FindGameObjectWithTag("NewRecord").GetComponent<Text>();
        }

        if (winText == null)
        {
            winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>();
        }

        if (reticleImage == null)
        {
            reticleImage = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Image>();
        }

        if (shootWithRaycastsScript == null)
        {
            // References to the shootWithRaycasts Script
            shootWithRaycastsScript = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<ShootWithRaycasts>();
        }

    }


    // Update is called once per frame
    void Update()
    {
         

        targetText.text = "Targets: " + targetCount + "/45";

        /*
        coinText.text = "Coins:\n==========Green: " + greenCoinCount + "/1\nPurple: " + purpleCoinCount
            + "/1\nRed: " + redCoinCount + "/1";
        */

        if (done == true)
        {
            winCheck();
            newRecordCheck();
        }

        // Pause
        /*
        if (GameManager.Instance.startClock)
        {
            disableIntroUI();
        }
        */
        if (Input.GetKeyDown(KeyCode.P))
        {
            UI = false;
            levelUI(UI, start);
        }

        // Pause; Disable all UI for both in game and out of game
        if(GameManager.Instance.pause == false && triggered == false)
        {
            UI = false;
            start = true;
            levelUI(UI, start);
            triggered = true;
        }


        // Unpause
        if (GameManager.Instance.pause == false && triggered == true)
        {
            UI = true;
            levelUI(UI, start);
            Cursor.lockState = CursorLockMode.Locked;

            triggered = true;
        }

    }

    public void winCheck()
    {
        accuracy = shotsHit / totalShots;

        if (targetCount == 45)
        {
            won = true;


            // Displays win message
            winText.text = "You won!\nWould you like to play again? (Y/N)";

            // Displays Stats
            statsText.text = "=== STATS ===\nTargets Hit: " + targetCount +
                "\nTotal Shots: " + totalShots +
                "\nAccuracy: " + accuracy + "%";
        }
        else
        {
            // Displays lose message
            winText.text = "You lost!\nTry again? (Y/N)";

            // Displays Stats
            statsText.text = "=== STATS ===" +
                "\nTargets Hit: " + targetCount +
                "\nTotal Shots: " + totalShots +
                "\nAccuracy: " + accuracy + "%";
        }

        // WIN
        if (won == true && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won == true && Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.DeleteKey("BestTime");
            GameManager.Instance.Menu();
            GameManager.Instance.unloadCurrentLevel();
            
        }

        // LOST
        if (won == false && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won == false && Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.DeleteKey("BestTime");
            GameManager.Instance.Menu();
            GameManager.Instance.unloadCurrentLevel();
        }

    }

    public void newRecordCheck()
    {
        // CHECKS FOR NEW RECORD
        if (PlayerPrefs.GetFloat("BestTime") == 0)
        {
            PlayerPrefs.SetFloat("BestTime", finalTime);

            // Checks if it's a new best time
            if (finalTime < PlayerPrefs.GetFloat("BestTime"))
            {
                // Stores the best time away from scene reload
                PlayerPrefs.SetFloat("BestTime", finalTime);
                newRecordText.text = "NEW RECORD!\nTime: " + finalTime.ToString("F3") + " seconds";

            }
        }
    }

    void levelUI(bool enabled, bool start)
    {
        /*
        // If unpaused and game started
        if (enabled == false && start == true)
        {

        }
        */
        // If Unpaused
        if (enabled == true && start == true || start == false)
        {
            targetText.enabled = true;
            titleText.enabled = true;
            objectiveText.enabled = true;
            controlText.enabled = true;
            bestTimeText.enabled = true;
            newRecordText.enabled = true;
            statsText.enabled = true;
            winText.enabled = true;
            clockText.enabled = true;
            reticleImage.enabled = true;
            //coinText.enabled = false;
        }
        // If paused
        if (enabled == false && start == true || start == false)
        {
            targetText.enabled = false;
            titleText.enabled = false;
            objectiveText.enabled = false;
            controlText.enabled = false;
            bestTimeText.enabled = false;
            newRecordText.enabled = false;
            statsText.enabled = false;
            winText.enabled = false;
            clockText.enabled = false;
            reticleImage.enabled = false;
            //coinText.enabled = false;
        }
        if(enabled == false && start == true)
        {
            titleText.enabled = false;
            controlText.enabled = false;
            objectiveText.enabled = false;
            bestTimeText.enabled = false;
        }

    }

    void disableIntroUI()
    {

    }
}

