using UnityEngine;
using System.Collections;

public class CloudBehavior : MonoBehaviour {
	public Vector2 rotationSpeedRange = new Vector2(1,4);
	public Vector2 positionRange = new Vector2(30,481);
	public Vector2 heightRange = new Vector2(40, 50);
	public int scaleRandomizer = 2;
	public Vector2 distnceFromCenterRange= new Vector2(10,30);
	public Vector2 orbitSpeedRange = new Vector2(1, 5);
	
	private float rotationSpeed;
	private Vector3 orbitLocation;
	private float orbitSpeed;
	
	
	// Use this for initialization
	void Start () {
		rotationSpeed = Random.Range (rotationSpeedRange.x, rotationSpeedRange.y);
		orbitSpeed = Random.Range(orbitSpeedRange.x, orbitSpeedRange.y);
		float scale = Random.value *scaleRandomizer;
		float x = Random.Range(positionRange.x, positionRange.y);
		float y = Random.Range(heightRange.x, heightRange.y);
		float z = Random.Range(positionRange.x, positionRange.y);
		orbitLocation = new Vector3(x,y,z);
		transform.position = new Vector3(x-Random.Range(distnceFromCenterRange.x, distnceFromCenterRange.y),y,z);
		transform.localScale = transform.localScale*scale;
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
	}
	
	private void Rotate(){
		this.transform.Rotate(Vector3.up * this.rotationSpeed);
		this.transform.RotateAround(orbitLocation, Vector3.up, this.orbitSpeed);
	}
}
