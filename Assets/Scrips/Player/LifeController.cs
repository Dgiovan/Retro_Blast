using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeController : MonoBehaviour
{
	private Slider sliderLife;
    // Start is called before the first frame update
    void Start()
    {
	    sliderLife = GameObject.FindGameObjectWithTag("PlayerLife").GetComponent<Slider>();
    }
	//PlayerLife

    // Update is called once per frame
    void Update()
	{
	
	
	}
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	protected void FixedUpdate()
	{

			sliderLife.value = PlayerMoves.getPlayerLife();
		
	}
}
