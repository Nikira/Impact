using UnityEngine;
using System.Collections;


// MonoBehaviour: tells Unity that this can be attached to a game object
public class PlayerMovement : MonoBehaviour {
	
	public float MovementSpeed = 0.0001f;
	public float OverSpeed = 0.0011f;
	public static float BoosterLoad = 5.0f;

	private Vector3 startPosition;	
	
	public ParticleSystem LiftoffEffect;
	public AudioClip warp;
	
	// Use this for initialization, actually constructor
	void Start () {

		startPosition = transform.localPosition;
		gameObject.active = true;
		BoosterLoad = 5.0f;
		
		//Screen.SetResolution (854, 480, true);
	}
	
	private void GameStart () {
		transform.localPosition = startPosition;
		
		Debug.Log("GameStart Method called");

	}
	
	// Update is called once per frame, handels input
	void Update () {
		 if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * MovementSpeed, touchDeltaPosition.y * MovementSpeed, 0);
			
        }
	
		else {
			float delta_x = Input.GetAxis("Mouse X");
			float delta_y = Input.GetAxis("Mouse Y");
			if (Input.GetButton ("Jump")){
				BoosterLoad -= Time.deltaTime;
					if (BoosterLoad<=0){
						rigidbody.AddForce(new Vector3(0, 20, 0));
						ParticleSystem effect = (ParticleSystem)Instantiate(LiftoffEffect, transform.position, Quaternion.identity);
						
						audio.PlayOneShot(warp);
						
						
					}
			}
			else {				
				transform.position = new Vector3(transform.position.x + (MovementSpeed * delta_x), transform.position.y + (MovementSpeed * delta_y) , 0);
			}
		}
		
	}
	
		
}
