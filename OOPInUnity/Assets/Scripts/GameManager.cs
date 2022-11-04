using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: Singleton<GameManager>
{
    public int score;

    public GameObject pauseMenu;

    
    // Variable to keep track of current level
    private string CurrentLevelName = string.Empty;

    public static GameManager instance;

    /*#region This code makes this class a Singleton
    private void Awake()
    {
        if (instance == null)
        {
            // This is referring to this exact script
            instance = this;

            // Make sure this game manager persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" + "instance of singleton Game Manager");
        }
    }
    #endregion*/

    // Methods to load and unload scenes
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if(ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName + ".");
            return;
        }

        CurrentLevelName = levelName;
        
    }

    // Methods to load and unload scenes
    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName + ".");
            return;
        }

    }

    public void unloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);

        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName + ".");
            return;
        }
    }

    // Methods to pause and unpause
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    // Methods to pause and unpause
    public void Unpause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
}


