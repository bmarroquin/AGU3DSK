using UnityEngine;
using System.Collections;

public class DogPound : MonoBehaviour {
	public GameObject dogPrefab;
	public GameObject miniDogPrefab;
	public Terrain terrain;
	public int DogsToSpawn = 10;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < DogsToSpawn; i++){
			float x = Random.Range(0,511);
			float z = Random.Range(0,511);
			float height = terrain.SampleHeight(new Vector3(x,0,z))+1.4f;
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
