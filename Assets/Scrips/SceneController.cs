using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	/* @author David & Gio
	<summary>
	The changeScene method changes the scene.
	<param name="scene"> the exact scene name is needed to be able to switch without errors</param>
	<para>the scenes available at this time are
	About, Credits, Leve_1 , Leve_2, Leve_3, MainMenu, Tutorial</para>
	</summary>
	*/
	public void changeScene(string scene){
		SceneManager.LoadScene(scene);
	}
	
	public void exitApp(){
		Application.Quit();
	}
}
