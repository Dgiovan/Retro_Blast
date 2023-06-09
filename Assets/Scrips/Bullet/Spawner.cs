using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	private GameObject playerObject;
	public GameObject  bulletObject;
	private int 	   CreateBullets = 0;
	private float	   distanceSpawn = 1;
	private float	   totlaTime	 = 0;
	private AudioSource sound;

    // Start is called before the first frame update
    void Start()
	{
		playerObject = GameObject.FindGameObjectWithTag("Player");
		sound = GetComponent<AudioSource>();
        
	}
	
	public void setBullet(int bullets){
		CreateBullets += bullets;
	}

    // Update is called once per frame
    void Update()
    {
	    totlaTime += Time.deltaTime;
	    
	 
    }
    
	public void spawnBullet(){
		if(totlaTime > distanceSpawn){
			sound.Play();
			Instantiate(bulletObject,this.transform.position,Quaternion.Euler(0,0,90 * playerObject.transform.localScale.x));
			
			for(int countBullet=0; countBullet<CreateBullets;countBullet++ ){
				Vector3 position = this.transform.position;
				Vector3 bullet_position = new Vector3(position.x+1,position.y+.10f ,position.z);
				Instantiate(bulletObject,bullet_position,Quaternion.Euler(0,0,90 * playerObject.transform.localScale.x));
			}
			
			totlaTime =0;
			
		}
	}
	

}
