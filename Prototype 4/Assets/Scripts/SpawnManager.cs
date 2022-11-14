using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public float spawnRange = 9;
    public int goal;
    public int enemyCount;
    public int waveNumber = 1;
    public bool done = false;


    // Start is called before the first frame update
    void Start()
    {
        // Where to set the wave goal
        goal = 1;

        SpawnEnemyWave(waveNumber);
        SpawnPowerUp(1);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Instantiate the enemy in the random spawn position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerUp(int powerUpsToSpawn)
    {
        for (int i = 0; i < powerUpsToSpawn; i++)
        {
            // Instantiate the powerup in the random spawn position
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        Debug.Log("Generating Spawn Position");

        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            if (waveNumber > goal)
            {
                done = true;
            }

            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp(1);

        }
    }
}
