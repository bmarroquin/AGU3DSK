using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	private Camera active;
	public Camera world;
	public Camera playerFP;
	public Camera playerTP;
	public Camera npFP;
	public Camera npTP;
	private int counter = 0;
	// Use this for initialization
	void Start () {
		active = world;
		active.gameObject.SetActive(true);
		playerFP.gameObject.SetActive(false);
		playerTP.gameObject.SetActive(false);
		npFP.gameObject.SetActive(false);
		npTP.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("c")){
			counter++;
			active.gameObject.SetActive(false);
			switch(counter%5){
				case 0: active = world; break;
				case 1: active = playerFP; break;
				case 2: active = playerTP; break;
				case 3: active = npFP; break;
				case 4: active = npTP; break;
			}
			active.gameObject.SetActive(true);
		}
	}
}
