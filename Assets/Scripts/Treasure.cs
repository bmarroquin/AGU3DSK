using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	public bool isTagged = false;

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

	void onTriggerEnter (Collider other) {
		Debug.Log("YOU HIT ME");
	}
}
