using UnityEngine;
using System.Collections;

public class CloudBehavior : MonoBehaviour {
	public float rotationSpeed = 1f;
	public Vector3 orbitLocation = new Vector3(1000,30,1000);
	public float orbitSpeed = 1f;
	public int distanceFromCenter = 20;
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (orbitLocation.x - distanceFromCenter, orbitLocation.y, orbitLocation.z);
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
