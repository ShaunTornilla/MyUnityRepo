using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text waveText;
    public Text winText;
    public Text conditionsText;

    public GameObject winTextGameObject;

    public int waveCount;
    public int goal;

    public SpawnManagerX spawnManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        waveCount = 1;
        goal = 10;

        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        winText.text = "You Win!\nPress 'R' to try again.";
        conditionsText.text = "Survive " + goal + " waves.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            conditionsText.enabled = false;
        }

        waveText.text = "Wave: " + waveCount + "/" + goal;

    }
}