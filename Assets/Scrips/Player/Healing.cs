using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D triggered)
	{
		if(triggered.gameObject.CompareTag("Player")){
			PlayerMoves.life +=20;
			Destroy(this.gameObject,1);
		}
	}
}
