private static var instance : MusicManager;

var NewMusic: AudioClip; //Set the audio track

public static function GetInstance() : MusicManager {
	return instance;
}
    
function Awake () {
    var go = GameObject.Find("Game Music");
    go.audio.clip = NewMusic; //replace the old audio with the new one set in the inspector
    go.audio.Play(); // play the audio.
}