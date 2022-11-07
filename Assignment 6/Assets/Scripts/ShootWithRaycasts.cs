/*
 * (Shaun Tornilla)
 * (Assignment5B - 3D Level)
 * (Shooty Shooty Bang Bang)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycasts : MonoBehaviour
{
    // UI Shite
    private DisplayManager displayManagerScript;


    public int damage = 50;
    public float range = 100f;
    public Camera cam;

    public ParticleSystem muzzleFlash;
    public float hitForce = 10f;

    // Audio
    private AudioSource gunAudio;
    public AudioClip gunSound;

    private void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        displayManagerScript = GameObject.FindObjectOfType<DisplayManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();

            displayManagerScript.totalShots++;
        }
    }

    void Shoot()
    {
        gunAudio.PlayOneShot(gunSound, .5f);
        muzzleFlash.Play();

        RaycastHit hitInfo;

        // If our raycast (bullet) hits something
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            //Debug.Log(hitInfo.transform.gameObject.name);



            // Get the target script off hit object
            Targets target = hitInfo.transform.gameObject.GetComponent<Targets>();

            // If target script found, deal damage to target
            if(target != null)
            {

                target.TakeDamage(damage);
                displayManagerScript.shotsHit++;

                // Checks if target dies, increment counter
                if (target.health <= 0)
                {
                    displayManagerScript.targetCount++;
                }
            }

            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }



}
