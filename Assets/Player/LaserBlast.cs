using UnityEngine;
using System.Collections;

public class LaserBlast : MonoBehaviour {
	
	public GameObject LaserPrefab;
	public AudioClip Pew;
	public static int CountPlayerBlastLasers;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			
			Instantiate(LaserPrefab, transform.position, Quaternion.identity);
			audio.PlayOneShot(Pew);
			CountPlayerBlastLasers++;
			
		}	
	}
}
