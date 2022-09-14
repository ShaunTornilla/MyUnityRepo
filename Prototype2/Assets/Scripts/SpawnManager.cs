using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Drag the Prefabs to Spawn onto this array in the inspector
    public GameObject[] prefabsToSpawn;

    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;
    private float spawnIntervals;

    public HealthSystem healthSystem;

    public bool gameOver = false;

    private void Start()
    {

        // get a reference to HealthSystem script
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();


        // Calls the method repeatedly("method", startDelay, spawnInterval)
        // InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);

        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    // A method with the return type IEnumerator and yield return new WaitForSeconds(); to create a coroutine
    IEnumerator SpawnRandomPrefabWithCoroutine()
    {

        // Adds a 3 second delay before the first prefab spawns
        yield return new WaitForSeconds(3f);

        // Continue to spawn while the game is not over. Make conditions true to continue to spawn forever.
        while(!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            yield return new WaitForSeconds(1.5f);
        }


    }


    void SpawnRandomPrefab()
    {
        // Spawn 0th prefab at top of screen
        Instantiate(prefabsToSpawn[0], new Vector3(0, 0, 20), prefabsToSpawn[0].transform.rotation);

        // Pick a Random Index between 0 and the legnth of the array
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        // Randomly generate index and spawn position

        // Generate Spawn Position
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        // Spawn
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
