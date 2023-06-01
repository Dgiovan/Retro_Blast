using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
	private static Rigidbody2D playerBody;
	private const int WALK = 1;
	private const int RIGHT = 1;
	private const int LEFTH = -1;
	private const int STOP = 0;
	private int front = RIGHT;
	private float horizontalHovement = 0;
	private  float jumpForce = 9.5f;
	private float movementSpeed = 7;
	public Animator anim;
	private bool fromKeyBoard = true;
	public int animSpeedOfMovement=STOP;
	// Start is called before the first frame update
    void Start()
    {
	    playerBody = GetComponent<Rigidbody2D>();
    }

	protected void FixedUpdate()
	{
		
		directionMove();
		playerBody.velocity = new Vector2(horizontalHovement,playerBody.velocity.y);


	}
	/*gets the pressed key and returns an integer value address*/
	private void directionMove(){
		if(Input.GetKeyDown(KeyCode.Space)){
			jump();			
		}

		
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			moveTo(RIGHT);
		}
		else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			moveTo(LEFTH);
		}else{
			if(fromKeyBoard){
				moveTo(STOP);	
			}
		}
	
	
	}
	/*generates the movement of the player can be used in the onclick method 
	  by entering the value of "right 1" and "left -1"*/
	public void moveTo(int direction)
	{
		horizontalHovement = direction * movementSpeed;
		
		if(direction == RIGHT || direction == LEFTH){
			front = direction;

			animSpeedOfMovement = WALK;
		}else {
			animSpeedOfMovement = STOP;
			horizontalHovement = 0 * movementSpeed;
		
		}
		
		anim.SetInteger("speedOfMovement",animSpeedOfMovement);
		bodyDirection();
	}
	//flag to be able to advance with the touch of the devices
	public void setTouch(bool touch){
		fromKeyBoard = !touch;
	}
	/**jump method can be used from the onclick method*/
	public void jump(){
		playerBody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
		anim.SetBool("isJump",true);
	}
	/*assigns the direction that our character will see*/
	private void bodyDirection(){this.transform.localScale = new Vector3(front,1,1);}
	
	// Sent each frame where a collider on another object is touching this object's collider (2D physics only).
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.CompareTag("Floor")){anim.SetBool("isJump",false);}

	}
}
