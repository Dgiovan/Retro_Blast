using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
	string sceneName = "";

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
	 sceneName = SceneManager.GetActiveScene().name;
	}
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D trigger)
	{

		if(trigger.gameObject.CompareTag("Player")){
			StartCoroutine(	teleport());
		}
	}
	
	IEnumerator teleport(){
		yield return new WaitForSeconds(.7f);
		Debug.Log("scene "+sceneName);
		SceneController.changeScene(sceneName.Equals("Tutorial")?"Leve_1":"Credits",1);
	
	}
}
