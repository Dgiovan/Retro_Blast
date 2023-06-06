using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	public BasicEnemy enemy;

	
    void Update()
    {
        
    }
	
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter2D(Collider2D collision)
	{

		if(collision.gameObject.CompareTag("bullet")){
			//enemy.life -= 1;
			enemy.life -=1;
			Debug.Log("Damage "+ collision.GetInstanceID());
		}
		
	}
	
}
