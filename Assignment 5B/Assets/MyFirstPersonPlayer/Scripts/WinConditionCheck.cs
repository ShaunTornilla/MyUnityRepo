using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinConditionCheck : MonoBehaviour
{
    public HUDBehavior checks;
    public Text winText;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        checks = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDBehavior>();

        
        if(winText == null)
        {
            winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>();
        }

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && checks.targetCount == 45)
        {
            won = true;
            winText.text = "You won!\nWould you like to play again? (Y/N)";
        }

    }

    private void Update()
    {

        if (won == true && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won == true && Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}