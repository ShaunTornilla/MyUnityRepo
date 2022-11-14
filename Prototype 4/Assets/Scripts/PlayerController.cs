using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;

    private float forwardInput;
    private GameObject focalPoint;
    public bool hasPowerUp;
    public bool playerFell = false;
    private float powerUpStrength = 15.0f;


    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        // Move powerup indicator to the ground below the feet of our player
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Lose if player falls
        if (transform.position.y < -10)
        {
            playerFell = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);

            StartCoroutine(PowerUpCountdownRoutine());
            powerUpIndicator.gameObject.SetActive(true);

        }
    }

    // Return types for coroutines are IEnumerator
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            // Get a local reference to the enemy rigidbody
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            // Set a Vector3 with a direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            // Add force away from the player
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
