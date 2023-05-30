using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
	private static Rigidbody2D playerBody;
	private const int RIGHT = 1;
	private const int LEFTH = -1;
	private const int STOP = 0;
	private int front = RIGHT;
	private float horizontalHovement = 0;
	private  float jumpForce = 9;
	private float movementSpeed = 7;
    // Start is called before the first frame update
    void Start()
    {
	    playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    moveTo(directionMove());
	    playerBody.velocity = new Vector2(horizontalHovement,playerBody.velocity.y);
    }
    
	/*gets the pressed key and returns an integer value address*/
	private int directionMove(){
		int direction = 0;
		if(Input.GetKey(KeyCode.Space)){
			jump();			
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			direction = RIGHT;
		}else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			direction = LEFTH;

		}else {direction = STOP;}
		return direction;
	}
	/*generates the movement of the player can be used in the onclick method 
	  by entering the value of "right 1" and "left -1"*/
	public void moveTo(int direction)
	{
		horizontalHovement = direction * movementSpeed;
		if(direction == RIGHT || direction == LEFTH){
			front = direction;
		}
		bodyDirection();
	}
	/**jump method can be used from the onclick method*/
	private void jump(){
		playerBody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
		
	}
	/*assigns the direction that our character will see*/
	private void bodyDirection(){this.transform.localScale = new Vector3(front,1,1);}
}
