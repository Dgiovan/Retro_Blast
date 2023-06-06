using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	[SerializeField] private Vector2 movementSpeed;
	private Vector2 offset;
	private Material material;
	private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		material = GetComponent<SpriteRenderer>().material;
		//playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
	    if(PlayerMoves.life>0){
		    offset = (playerBody.velocity.x * 0.1f) * movementSpeed * Time.deltaTime;
		    material.mainTextureOffset += offset;
	    }
    }
}
