using UnityEngine;
using System.Collections;

public class EnemyStatusController : MonoBehaviour {
	
	public ParticleSystem EnemyExplosionEffect;
	
	public AudioClip explosion23;
	
	
	public void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Laser" || collider.gameObject.tag == "Player"){
			
			Debug.Log("the enemy has collided "+collider.gameObject.name);
			Vector3 enemy_position = collider.gameObject.transform.position;
			
			if(collider.gameObject.tag != "Player"){
				Destroy (collider.gameObject);
				
				
			}else{
				
				
			}
			Destroy (this.gameObject);
			ParticleSystem explosion = (ParticleSystem)Instantiate(EnemyExplosionEffect, enemy_position, Quaternion.identity);		
			explosion.enableEmission = true;	//creates, fires once, autodestructes
		}	
	}
}
