using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {
	
	
	public GameObject LittleComet;
	
	public AudioClip explosion2;
	
	private float LastSpawnTime = 0.0f;
	
	public int EnemyNr = 20;
	
	public int EnemyLives = 3;
	
	public float SpawnRate = 0.01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0.0f, 0.0f, 0.7f);		
		
		//if ((EnemyNr > 0) && ((current_time-LastSpawnTime) > SpawnRate)) {
		//	GameObject enemy =(GameObject)Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
		//	EnemyNr-=1;
			//enemy.rigidbody.AddForce(transform.up * 500.0f);
			
		//LastSpawnTime = current_time;
		//}
		
	}
	
	public void OnTriggerEnter(Collider collider) {
	
		
		if (collider.gameObject.tag == "Laser"){
			
			audio.PlayOneShot(explosion2);
			
			
			//Debug.Log("the enemy has collided "+collider.gameObject.tag);
				
			float current_time = Time.time;
			
			if (EnemyLives <= 0){
				Destroy (this.gameObject);
			}
			
			
				
			GameObject enemy =(GameObject)Instantiate(LittleComet, transform.position, Quaternion.identity);
			GameObject enemy2 =(GameObject)Instantiate(LittleComet, transform.position, Quaternion.identity);		
			GameObject enemy3 =(GameObject)Instantiate(LittleComet, transform.position, Quaternion.identity);	
			
				
					
			enemy.rigidbody.AddForce(transform.up * 200.0f);
			//GameObject enemy =(GameObject)Instantiate(LittleComet, new Vector3(i * 2.0F, 0, 0), Quaternion.identity); AWESOME WELLEN SPAWNEN

			EnemyLives-=1;
			EnemyNr-=1;
			//enemy.rigidbody.AddForce(transform.up * 200.0f);
					
			LastSpawnTime = current_time;
			}
		}
	}
		

