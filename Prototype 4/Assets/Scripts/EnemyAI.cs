using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRB;
    public GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Add force toward the direction from the player to the enemy

        // Get vector for the direction from enemy to player (normalized so we're just getting the direction, not distance)
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Add force toward player
        enemyRB.AddForce(lookDirection * speed);

        // Destroys enemy when fall off platform
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
