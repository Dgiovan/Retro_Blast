using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
	private AudioSource sound;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		sound = GetComponent<AudioSource>();
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D triggered)
	{
		if(triggered.gameObject.CompareTag("Player")){
			PlayerMoves.life +=20;
			sound.Play();
			Destroy(this.gameObject,.5f);
		}
	}
}
