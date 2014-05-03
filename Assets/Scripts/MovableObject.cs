using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour {
	public bool canControl = false;
	public float _maxForwardSpeed = 6f;
	public float _maxBackwardsSpeed = 6f;
	
	private CollisionFlags _collisionFlags;
	private Vector3 velocity; 
	private CharacterController controller;
	
	// Use this for initialization
	void Start () {
		this.controller = (CharacterController)GetComponent("CharacterController");
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentVelicity = this.velocity;
	}
	
	
}


