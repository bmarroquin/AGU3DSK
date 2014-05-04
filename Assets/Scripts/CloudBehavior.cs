using UnityEngine;
using System.Collections;

public class CloudBehavior : MonoBehaviour {

	//Range of possible rotation speeds.
	public Vector2 rotationSpeedRange = new Vector2(1,4);
	
	// Range of possible x/z coordinate values or orbit center.
	public Vector2 positionRange = new Vector2(30,481);
	
	// Range of possible y value of orbit center.
	public Vector2 heightRange = new Vector2(40, 50);
	
	// Randomize the size of the cloud.
	public int scaleRandomizer = 2;
	
	// Range of distance from center. 
	public Vector2 distnceFromCenterRange= new Vector2(10,30);
	// Range of orbit speed.
	public Vector2 orbitSpeedRange = new Vector2(1, 3);
	
	//Determines how the cloud moves. 
	private float rotationSpeed;
	private Vector3 orbitLocation;
	private float orbitSpeed;
	
	
	// Use this for initialization
	void Start () {
		// Grab random speeds.
		rotationSpeed = Random.Range (rotationSpeedRange.x, rotationSpeedRange.y);
		orbitSpeed = Random.Range(orbitSpeedRange.x, orbitSpeedRange.y);
		
		// Grab random scale.
		float scale = Random.value *scaleRandomizer;
		
		// Grab random orbit position.
		float x = Random.Range(positionRange.x, positionRange.y);
		float y = Random.Range(heightRange.x, heightRange.y);
		float z = Random.Range(positionRange.x, positionRange.y);
		orbitLocation = new Vector3(x,y,z);
		
		// Move the cloud to initial position
		transform.position = new Vector3(x-Random.Range(distnceFromCenterRange.x, distnceFromCenterRange.y),y,z);
		
		//Scale the cloud.
		transform.localScale = transform.localScale*scale;
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
	}
	
	private void Rotate(){
		// Rotate around the y axis.
		this.transform.Rotate(Vector3.up * this.rotationSpeed);
		
		// Rotate around orbit location.
		this.transform.RotateAround(orbitLocation, Vector3.up, this.orbitSpeed);
	}
	
}
