using UnityEngine;
using System.Collections;

public class ButtonSceneChange : MonoBehaviour {

	public void Switch(string sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);}
	
	public void Tutorial(string toTutorial){
		Application.LoadLevel (toTutorial);}
	
	public void Quit(){
		Application.Quit();
	}
}

