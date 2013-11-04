using UnityEngine;
using System.Collections;

public class LaserBeamController : MonoBehaviour {
	
	//public static int hits = 0;
	
	// Use this for initialization
	void Start () {
		//hits=0;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, 0.0f);
		
	}
	
	public void OnTriggerEnter(Collider collider){
		//hits += 100;
		if(collider.gameObject.tag.Equals("Enemy")){
			Destroy(collider.gameObject);
			Destroy(gameObject);		
			
		}
	}
}

