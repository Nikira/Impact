using UnityEngine;
using System.Collections;

public class ForceBlast : MonoBehaviour {

	public ParticleSystem ForceBlastEffect;
	public AudioClip swoosh;
	public static int CountPlayerForceBlast;

	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse1)) {
			Fire();
			CountPlayerForceBlast++;
			
		}
	}	
	
	public void Fire(){
		
		ParticleSystem effect = (ParticleSystem)Instantiate(ForceBlastEffect, transform.position, Quaternion.identity);
		effect.enableEmission = true;
		Vector3 explosionPos = transform.position;
		bool isEnemy = GameObject.FindWithTag ("LittleComet");
        Collider[] colliders = Physics.OverlapSphere (explosionPos, 10.0f);
		audio.PlayOneShot(swoosh);
		
		
		foreach (Collider hit in colliders) {
            if (!hit)
                continue;
            
            if (hit.rigidbody && hit.tag == "LittleComet"){
				if(isEnemy == true){
                hit.rigidbody.AddExplosionForce(500.0f, explosionPos, 10.0f);
				}
        	}
		}		
		
		
	}
}