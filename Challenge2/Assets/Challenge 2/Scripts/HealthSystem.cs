/*
 * (Shaun Tornilla)
 * (Assignment3 Challenge 2)
 * (Code to Manage Health System.)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool gameOver = false;
    public GameObject gameOverText;
    public GameObject winText;

    public DisplayScore displayScore;

    private void Start()
    {
        displayScore = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    void Update()
    {
        //If health is somehow more than max health, set health to max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < hearts.Count; i++)
        {
            //Display full or empty heart sprite based on current health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            //Show the number of hearts equal to current max health
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);
            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if(displayScore.score == 5)
        {
            gameOver = true;
            winText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public void TakeDamage()
    {
        health--;
    }
    public void AddMaxHealth()
    {
        maxHealth++;
    }
}
