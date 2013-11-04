using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
	
	private GameObject Player;

	
	// Use this for initialization, Enemies need to be aware of the Player
	void Start () {
		
		Player = GameObject.Find ("fighter01");
				
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (PlayerStatusController.lives > 0){
		// Debug.Log("player still has" + localLives + "lives");
		
		Vector3 direction_to_player = (Player.transform.position - transform.position).normalized;
				
		rigidbody.AddForce(direction_to_player);
		
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
		}
		
	}
	
}
