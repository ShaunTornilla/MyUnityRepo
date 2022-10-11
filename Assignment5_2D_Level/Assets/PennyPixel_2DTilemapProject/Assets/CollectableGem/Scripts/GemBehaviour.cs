using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;

    ///////////////////// CHANGE /////////////////////
    private UIManager uIManager;
    ///////////////////// CHANGE /////////////////////

    void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;

        ///////////////////// CHANGE /////////////////////
        uIManager = GameObject.FindObjectOfType<UIManager>();
        ///////////////////// CHANGE /////////////////////

    }


    void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player"))
        {
			GemCollected ();
            
		}
	}

	void GemCollected()
	{
        ///////////////////// CHANGE /////////////////////
        uIManager.score++;
        ///////////////////// CHANGE /////////////////////

        gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
