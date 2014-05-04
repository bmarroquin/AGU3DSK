using UnityEngine;
using System.Collections;

public class CreatorOfHeavens : MonoBehaviour {
	
	// Prefab to be cloned. 
	public GameObject cloudPrefab;
	
	// number of clouds to create.
	public int cloudCount;
	// Use this for initialization
	void Start () {
	
		// instantiates x many clouds. 
		for(int i = 0; i < cloudCount; i++){
			Instantiate(cloudPrefab);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
