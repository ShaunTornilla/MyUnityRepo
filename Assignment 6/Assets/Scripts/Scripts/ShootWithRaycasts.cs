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
    private HUDBehavior display;


    public float damage = 10f;
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
        display = GameObject.FindObjectOfType<HUDBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();

            display.totalShots++;
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
            Debug.Log(hitInfo.transform.gameObject.name);



            // Get the target script off hit object
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();

            // If target script found, deal damage to target
            if(target != null)
            {
                target.TakeDamage(damage);
                display.targetCount++;
                display.shotsHit++;
            }

            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
