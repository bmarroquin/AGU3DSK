using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterMotor))]

public class DogMovement : MonoBehaviour {
	// Angle to turn
	public float angle = 1.0f;
	
	//Speed to move forward.
	public float speed = 1.0f;
	
	// Motor component that handles collisions and movement. 
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
		// Grab the objects forward vector (position it is facing.
		// Multiply it by speed this gives the direction to move.
		// Pass it to the motor. 
		motor.inputMoveDirection =(this.transform.forward * speed);
	}
	
	
	private void Rotate(){
	
		// give it a 4/60 chance of rating each update. 
		if(Random.Range (0,59) < 4)	{
			// 50/50 chance of going left or right. 
			if(Random.value < .5f){
				this.transform.Rotate(new Vector3(0,angle,0));
			}
			else{
				this.transform.Rotate(new Vector3(0,-angle,0));
			}
		}	
	}
	
}
