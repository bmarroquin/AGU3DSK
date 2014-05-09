using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	public bool isTagged = false;
	public string whoTagged = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Tag() {
		isTagged = true;
	}

	bool IsTagged() {
		return isTagged;
	}

}
