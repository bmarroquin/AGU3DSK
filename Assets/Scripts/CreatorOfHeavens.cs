using UnityEngine;
using System.Collections;

public class CreatorOfHeavens : MonoBehaviour {

	public GameObject cloudPrefab;
	public int cloudCount;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < cloudCount; i++){
			Instantiate(cloudPrefab);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
