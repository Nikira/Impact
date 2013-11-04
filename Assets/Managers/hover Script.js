var levelToLoad : String;
var soundhover : AudioClip;
var beep : AudioClip;
var QuitButton : boolean = false;
var initialColor : Color;


function Start()
{
	initialColor = renderer.material.color;
}

function OnMouseEnter(){
	audio.PlayOneShot(soundhover);
	renderer.material.color = Color(0,1,1,0.5);
	
}

function OnMouseUp(){
	audio.PlayOneShot(beep);
	yield new WaitForSeconds(0.35);
	if(QuitButton){
		Application.Quit();
	}
	else{
		Application.LoadLevel(levelToLoad);
	}
}

function OnMouseExit() {
	yield WaitForSeconds(0.1);
	renderer.material.color = initialColor;
}

@script RequireComponent(AudioSource)