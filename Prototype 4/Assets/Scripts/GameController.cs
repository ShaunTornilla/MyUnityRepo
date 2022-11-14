using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SpawnManager spawnManagerScript;
    public UIManager UIManagerScript;
    public PlayerController playerControllerScript;

    public bool gameOver = false; 

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        UIManagerScript = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnManagerScript.waveNumber > 1)
        {
            gameOver = true;
            UIManagerScript.winText.enabled = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if(playerControllerScript.playerFell)
        {
            gameOver = true;
            UIManagerScript.winText.enabled = true;
            UIManagerScript.winText.text = "You Lost! Press 'R' to Try Again";

            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
