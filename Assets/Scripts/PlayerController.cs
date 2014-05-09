using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour {
	private CharacterMotor motor;
	public float speed = 1f;
	public float turnSpeed = 1f;
	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDirection = Vector3.zero;
		if(Input.GetKey(KeyCode.UpArrow)){
			 moveDirection += transform.forward * speed;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			moveDirection += transform.forward * -speed;
		}
		motor.inputMoveDirection =moveDirection;
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(Vector3.up*turnSpeed*-1);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(Vector3.up*turnSpeed);
		}
	}

	void onTriggerEnter (Collider other) {
		Debug.Log("Collider");
	}

	void OnCollisionEnter (Collision  collision) {
		Debug.Log("collision");
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		if (hit.gameObject.tag == "treasure") {

			GameObject treasure = hit.gameObject;
			GameObject taggedTreasure = (GameObject)Instantiate(Resources.Load("MiniDog"), treasure.transform.position, treasure.transform.rotation);
			Destroy(treasure);

			taggedTreasure.AddComponent("Treasure");
			taggedTreasure.tag = "treasure";
			taggedTreasure.GetComponent<Treasure>().isTagged = true;
			taggedTreasure.GetComponent<Treasure>().whoTagged = "Player";

		}
	}
}
