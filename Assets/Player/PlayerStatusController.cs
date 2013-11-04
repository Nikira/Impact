using UnityEngine;
using System.Collections;

public class PlayerStatusController : MonoBehaviour {

	public static int lives = 5;
	public static int TotalCometCount;
	public static int TotalLittleCometCount;
	
	public float distToImpact;
		
	public ParticleSystem EnemyExplosionEffect;
		
	public bool playerColEarth;
	
	public Vector3 earthPos;
	public Vector3 playerPos;
	
	public Texture2D dangerSign;
	
	
	void Start(){
		
		lives = 5;
		
		dangerSign = Resources.Load("danger") as Texture2D;
		Screen.showCursor = false; // hide cursor so it's not visible while playing
	}
	
	void FindObjects(){
		earthPos = GameObject.FindWithTag("Earth").transform.position;
		playerPos = GameObject.FindWithTag("Player").transform.position;
	}
	
	//called for each component whenever rendered
	public void OnGUI() {
		if(lives >=0){			
			GUI.Label(new Rect(0,0,(Screen.width/2),(Screen.height/2)),
			System.String.Concat (
				"<b>Lives: </b>", lives + 
				//"<b>\nPoints: </b>", LaserBeamController.hits + 
				"<b>\nBlastoff: </b>", (float)PlayerMovement.BoosterLoad +
				"<b>\nDistance to Earth: </b>", (float)distToImpact - 8.0f + " km"
				));
			FindObjects();
			distToImpact = Vector3.Distance(earthPos, playerPos);
		
			//Debug.Log("difference Vector shows:"+distToImpact+earthPos+playerPos);
		
			if (distToImpact<18.0f){
				GUI.DrawTexture(new Rect(1,55,32,32), dangerSign, ScaleMode.ScaleToFit, true, 1.0f);
			}
			
			
		
		}
		
	}
	
	public void OnTriggerEnter(Collider collider) {
		// count nr. of comets
		TotalLittleCometCount = GameObject.FindGameObjectsWithTag("LittleComet").Length;
		//Debug.Log ("Total Comet Number"+TotalLittleCometCount);
		TotalCometCount = GameObject.FindGameObjectsWithTag("Comet").Length;
		//Debug.Log ("Total Comet Number"+TotalCometCount);
		
		if (collider.gameObject.tag == "LittleComet"){
			Destroy (collider.gameObject);
			lives--;		
		
			Vector3 enemy_position = collider.transform.position;		
				
			ParticleSystem explosion = (ParticleSystem)Instantiate(EnemyExplosionEffect, enemy_position, Quaternion.identity);		
			explosion.enableEmission = true;	//creates, fires once, autodestructes
			
			gameObject.GetComponent<ForceBlast>().Fire();
			

			if (lives < 0 && TotalCometCount > 0){
				Debug.Log ("You have died and there are comets left");
				Destroy (this.gameObject);
				Application.LoadLevel("The2ndEnd");
				Screen.showCursor = true;
			}
			
			else if (lives > 0 && TotalCometCount <=0 && TotalLittleCometCount <=0 ){
				Debug.Log ("You have won the game");
				Destroy(this.gameObject);
				Application.LoadLevel("The3rdEnd");
				Screen.showCursor = true;
			}
		}
		
		else if (collider.gameObject.tag == "Earth" || collider.gameObject.tag == "Comet"){
			
			Debug.Log("Destroyed sth. big");
			playerColEarth = true;
			//yield return new WaitForSeconds(2.0f);
			//StartCoroutine(MyLoadLevel(200000.0f));
			Application.LoadLevel("The2ndEnd");
			//Invoke(nextScene(), 15);
			//Debug.Log("tried to invoke");
			Screen.showCursor = true;
		}
		
		else if (collider.gameObject.tag.Equals("CollisionPlaneTop")){
		Debug.Log ("You have fled the scene. The game should finish now.");
		Application.LoadLevel("The4thEnd");
		Screen.showCursor = true;
		}
		
	}
	
	//IEnumerator MyLoadLevel(float delay) {
	//	yield return new WaitForSeconds(delay);
		//Debug.Log("Delayed by" + delay);
		
	//}
	
	//void nextScene(){
		//Application.LoadLevel("TheEnd");
	//}
	
	void Update () {
		
		
	}
	
	
	
	
}
