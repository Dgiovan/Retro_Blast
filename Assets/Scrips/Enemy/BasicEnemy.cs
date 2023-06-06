using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
  
	public float speed =1;
	public Transform[] pointsDestiny;
	private int index ;
	private bool followPlayer = false;
	public  int life = 3;
	private float previus_postion =0;
	public Animator anim;
	private float	   totlaTime	 = 0;
    // Update is called once per frame
    void Update()
	{
		totlaTime += Time.deltaTime;
	    if(!followPlayer){
		    this.transform.position = Vector2.MoveTowards(this.transform.position,pointsDestiny[index].position,speed * Time.deltaTime); 
		    bodyDirection();
	    }
	   
		if(Vector2.Distance(this.transform.position,pointsDestiny[index].position) <=1)
	    {
		    index++;
		    if(index>= pointsDestiny.Length){
			    index=0;
		    }
	    }
	    previus_postion = this.transform.position.x;
	    lifeEnemy();
    }
    
	private void lifeEnemy() {
		if (life <= 0) {
			anim.SetBool("isDead",true);
			Destroy(this.gameObject,.5f);
		}
	}
	
	public void setDamage(){
		life--;
	}
	
	// Sent each frame where another object is within a trigger collider attached to this object (2D physics only).
	protected void OnTriggerStay2D(Collider2D collision)
	{

		if(collision.gameObject.CompareTag("Player")){
			speed =3f;
			this.transform.position = Vector2.MoveTowards(this.transform.position,collision.transform.position,speed * Time.deltaTime); 
			followPlayer = true;
			bodyDirection();
			anim.SetBool("isAtack",true);
		}
	}
	protected void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player")){
			followPlayer = false;			
			anim.SetBool("isAtack",false);
			speed =1;

		}
	}
	
	// Sent each frame where a collider on another object is touching this object's collider (2D physics only).
	protected void OnCollisionStay2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.CompareTag("Player")){
			if(totlaTime >1){
				PlayerMoves.life -= 20 ;
				totlaTime =0;
			}
		}
	}

	private void bodyDirection(){
		int direction = 0;
		decimal value = System.Convert.ToDecimal(this.transform.position.x -previus_postion);
		if(value > 0){
			direction = 1;
		}
		if(value<0){
			direction = -1;			
		}
			this.transform.localScale = new Vector3(direction,1,1);
	}
}
