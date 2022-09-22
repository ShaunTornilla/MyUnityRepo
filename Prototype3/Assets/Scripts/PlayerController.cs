using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;
    
    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {

        // Set reference variables to components.
        rb = GetComponent<Rigidbody>();

        // Set Reference Variables to Components
        playerAnimator = GetComponent<Animator>();

        // Start Running
        playerAnimator.SetFloat("Speed_f", 1.0f);

        jumpForceMode = ForceMode.Impulse;

        // Modify gravity to what we want it to be
        // Physics.gravity *= gravityModifier;

        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Press Spacebar to Jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            // Set the trigger to play the jump animation
            playerAnimator.SetTrigger("Jump_trig");

        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;

            // Play Death Animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
