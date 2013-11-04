using UnityEngine;
using System.Collections;

public class EarthBehaviour : MonoBehaviour {
	
	public static bool PlayerDeath;
	
	public static int CometHits;
	
	public static int LittleCometHits;
	
	private int CometRawHits;
	private int LittleCometRawHits;
	
	public void OnTriggerEnter(Collider collider) {
		
		//Debug.Log("The Earth Has Collided with the player");
		//if (collider.gameObject.tag.Equals("Player")){
		//	PlayerDeath = true;
		//}
		
		if (collider.gameObject.tag.Equals("Comet")){
			CometRawHits++;
			Debug.Log("Total CometHits:"+CometRawHits);
			CometHits=CometRawHits*1000000;
			
			if (LaserBlast.CountPlayerBlastLasers <= 0 && ForceBlast.CountPlayerForceBlast <= 0) {
				Application.LoadLevel("TheEnd");
				Screen.showCursor = true;
				
			}
			
			else {
				Application.LoadLevel ("The2ndEnd");
				Screen.showCursor = true;
			}
		}
		
		else if (collider.gameObject.tag.Equals("LittleComet")){
			LittleCometRawHits++;
			Debug.Log("Total LittleCometHits:"+LittleCometRawHits);
			LittleCometHits=LittleCometHits*1000000;
			Application.LoadLevel("TheEnd");
			Screen.showCursor = true;
		}
		
		else if (collider.gameObject.tag.Equals("CollisionPlane") && LittleCometHits <= 0 && CometHits <=0){
			Debug.Log ("Earth has hit the plane. The game should finish now.");
			Application.LoadLevel("The3rdEnd");
			Screen.showCursor = true;
		}
		
	}
	
    void Update() { // Earth rotation
        transform.Translate(0, 0, -Time.deltaTime/2, Camera.main.transform);
		transform.Rotate(0.0f, 0.1f, 0.0f);
    }
}