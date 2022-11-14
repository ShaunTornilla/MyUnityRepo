using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SpawnManagerX spawnManagerScript;
    public UIManager UIManagerScript;
    public EnemyX enemyPrefabScript;

    public GameObject enemyPrefab;

    public bool touched = false;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        UIManagerScript = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        //enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyX>();
        enemyPrefabScript = enemyPrefab.GetComponent<EnemyX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManagerScript.done)
        {
            gameOver = true;
            UIManagerScript.winTextGameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (touched)
        {
            gameOver = true;

            enemyPrefabScript.speed = 10;

            UIManagerScript.winText.text = "You Lost! Press 'R' to Try Again";
            UIManagerScript.winTextGameObject .SetActive(true);
            

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
