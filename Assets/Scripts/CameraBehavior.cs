using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	//Reference to curently active camera.
	private Camera active;
	
	//Six cameras in the world;
	public Camera world;
	public Camera playerFP;
	public Camera playerTP;
	public Camera npFP;
	public Camera npTP;
	//Keeps track of what camera to use.
	private int counter = 0;
	// When initializing activate only the world camera.
	void Start () {
		active = world;
		active.gameObject.SetActive(true);
		playerFP.gameObject.SetActive(false);
		playerTP.gameObject.SetActive(false);
		npFP.gameObject.SetActive(false);
		npTP.gameObject.SetActive(false);
	}
	
	
	void Update () {
		// If the 'c' key is pressed increase the counter and deactivate camera.
		if(Input.GetKeyDown("c")){
			counter++;
			active.gameObject.SetActive(false);
			//Choose new activecamera.
			switch(counter%5){
				case 0: active = world; break;
				case 1: active = playerFP; break;
				case 2: active = playerTP; break;
				case 3: active = npFP; break;
				case 4: active = npTP; break;
			}
			//Activate new camera.
			active.gameObject.SetActive(true);
		}
	}
}
