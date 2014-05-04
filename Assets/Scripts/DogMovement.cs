using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterMotor))]

public class DogMovement : MonoBehaviour {
	public float angle = 1.0f;
	public float speed = 1.0f;
	CharacterMotor motor;
	// Use this for initialization
	void Awake () {
		motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		Rotate ();
		Move();
	}
	
	
	private void Move(){
		motor.inputMoveDirection =(this.transform.forward * speed);
	
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
	
}
