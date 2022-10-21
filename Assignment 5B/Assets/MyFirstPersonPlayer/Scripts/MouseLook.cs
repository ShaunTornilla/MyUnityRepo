using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRotation = 0f;

    void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Mouse Input and assign floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate Player GameObject with horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);


        // Rotate camera around the x-axis with vertical mouse input
        verticalLookRotation -= mouseY;

        // Limit the vertical rotation with clamp
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        // Apply rotation to camera based on clamp output
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }
}
