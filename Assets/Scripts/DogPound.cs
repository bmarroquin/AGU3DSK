using UnityEngine;
using System.Collections;

public class DogPound : MonoBehaviour {
	// Dog prefabs
	public GameObject dogPrefab;
	public GameObject miniDogPrefab;
	
	//Terrain used for height.
	public Terrain terrain;
	public int DogsToSpawn = 10;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < DogsToSpawn; i++){
			// Generate random position
			float x = Random.Range(0,100);
			float z = Random.Range(0,100);
			//Grab the height and make sure dog is above.
			float height = terrain.SampleHeight(new Vector3(x,0,z))+1.4f;
			//  50/50 chance of having a mini dog or regular dog. 
			if(Random.Range(0,2) == 0){
				Instantiate(dogPrefab, new Vector3(x, height,z), Quaternion.identity);
			}
			else{
				Instantiate(miniDogPrefab, new Vector3(x, height,z), Quaternion.identity);
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
