using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	 void OnGUI() {
        GUIStyle myStyle = new GUIStyle();
				

		GUI.Label(new Rect((Screen.width/2),(Screen.height/2)+80,(Screen.width/2),(Screen.height/2)), System.String.Concat ("", (float)EarthBehaviour.CometHits));
		GUI.Label(new Rect((Screen.width/2),(Screen.height/2)+110,(Screen.width/2),(Screen.height/2)), System.String.Concat ("", (float)EarthBehaviour.LittleCometHits));
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
