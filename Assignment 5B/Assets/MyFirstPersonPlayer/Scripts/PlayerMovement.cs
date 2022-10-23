using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8.5f;

    // Variables for gravity
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    // Jump Variable
    public float jumpHeight = 3f;

    // GroundCheck variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public void Awake()
    {
        gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            // Resets velocity back to zero to simulate gravity
            velocity.y = -2; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Add Code to slow down to help with aim
        if (Input.GetButtonDown("Walk"))
        {
            speed = 4f;
        }

        // Add Code to slow down to help with aim
        if (Input.GetButtonUp("Walk"))
        {
            speed = 9f;
        }

        // Add Jump Code before gravity velocity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
