using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text waveText;
    public Text winText;
    public Text conditionsText;

    public SpawnManager spawnManagerScript; 


    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        winText.text = "You Win!\nPress 'R' to try again.";
        winText.enabled = false;
        conditionsText.text = "Survive " + spawnManagerScript.goal + " waves.\nDon't fall off!";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            conditionsText.enabled = false;
        }

        waveText.text = "Wave: " + spawnManagerScript.waveNumber + "/" + spawnManagerScript.spawnRange;

    }
}
