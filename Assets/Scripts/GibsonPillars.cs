using UnityEngine;
using System.Collections;

public class GibsonPillars : MonoBehaviour {

	private Object pillarPrefab ;
	private GameObject terrain;

	// Use this for initialization
	void Start () {
		pillarPrefab = Resources.Load("pillar");
		terrain =  GameObject.Find("Terrain");
		int offset = 8;

		for (int i = 0; i < 15; i++) {

			for (int j = 0; j < 15; j++) {
				float x = 160 + (offset * i);
				float z = 260 + (offset * j);

				//Grab the height and make sure pillar is above.
				terrain =  GameObject.Find("Terrain");
				float height = terrain.GetComponent<Terrain>().SampleHeight(new Vector3(x,0,z))+1.4f;
				Instantiate (pillarPrefab, new Vector3 (x, height, z), Quaternion.identity);
			}
		}
	}		
}

