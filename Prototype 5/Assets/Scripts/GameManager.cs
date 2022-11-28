using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            // Wait 1 Second
            yield return new WaitForSeconds(spawnRate);

            // Pick random object in list
            int index = Random.Range(0, targets.Count);

            // Spawn object at index
            Instantiate(targets[index]);
        }
    }
}
