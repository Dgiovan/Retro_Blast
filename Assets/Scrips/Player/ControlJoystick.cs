using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJoystick : MonoBehaviour
{
    // Start is called before the first frame update


	/*float horizontalMove = 0;
    float verticalMove = 0;

    public float runSpeedHorizontal = 3;
    public float runSpeedVertical = 3;
    public float runnSpeed = 0;

    private  Rigidbody2D playerBody;

    public Joystick joystick;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		
		verticalMove = joystick.Vertical * runSpeedVertical;
		horizontalMove = joystick.Horizontal * runSpeedHorizontal;
		Vector2 moveDirection= new Vector2(horizontalMove, verticalMove) * Time.deltaTime * runnSpeed;
		playerBody.velocity = moveDirection;
	}*/
	private Rigidbody2D playerBody;
	public Joystick joystick;
	public float moveSpeed = 3f;

	private void Start()
	{
		playerBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float horizontalMove =(joystick.Horizontal * moveSpeed);
		float verticalMove = joystick.Vertical * moveSpeed;
		Debug.Log("horizontal movimiento "+ joystick.Horizontal );
		playerBody.velocity = new Vector2(horizontalMove, verticalMove);
		
	}
}
