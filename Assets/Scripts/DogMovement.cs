using UnityEngine;
using System.Collections;

public class DogMovement : MonoBehaviour {
	public float angle = 1.0f;
	public int step = 1;
	public float stepSize = 48;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rotate ();
		Move ();
	}
	
	private void Rotate(){
		if(Random.Range (0,59) < 4)	{
			if(Random.value < .5f){
				this.transform.Rotate(new Vector3(0,angle,0));
			}
			else{
				this.transform.Rotate(new Vector3(0,-angle,0));
			}
		}	
	}
	
	private void Move(){
		this.transform.Translate(Vector3.forward * step * stepSize);
		
	}
}
