using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval;

    public HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        // get a reference to HealthSystem script
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        StartCoroutine(SpawnRandomIntervals());
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    IEnumerator SpawnRandomIntervals()
    {
        yield return new WaitForSeconds(3f);
        
        while(!healthSystem.gameOver)
        {
            spawnInterval = Random.Range(3f, 5f);
            SpawnRandomBall();

            yield return new WaitForSeconds(spawnInterval);
        }
        
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    { 

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Pick a Random Index between 0 and the legnth of the array
        int prefabIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[0].transform.rotation);


    }

}
