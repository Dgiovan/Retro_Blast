using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	
	private float speed = 1050;
	private Rigidbody2D  bodybullet;
	private GameObject playerObject;
	
	// is called before the first frame update
    void Start()
    {
	    playerObject = GameObject.FindGameObjectWithTag("Player");
	    bodybullet   = GetComponent<Rigidbody2D>();
	    
	    bodybullet.velocity = new Vector2(speed * Time.deltaTime * playerObject.transform.localScale.x,0);
    }

  
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D collisionInfo)
	{
		if(collisionInfo.gameObject.CompareTag("Enemy")){
			Destroy(this.gameObject);
		}
	}
   
}
