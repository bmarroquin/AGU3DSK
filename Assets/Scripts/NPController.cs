﻿using UnityEngine;
using System.Collections;

public class NPController : MonoBehaviour {
	public GameObject navNodePrefab;
	public float speed = 1f;
	public float snapDistance = 1.5f;
	Terrain terrain;
	private Path mainPath;
	Vector3 nextGoal;
	Vector3 nextTreasure;
	bool treasureMode = false;
	
	void Start () {
//		navNodePrefab = Resources.Load<GameObject>("Prefabs/NanNode");
		terrain = GameObject.FindObjectOfType<Terrain>();
		GeneratePath();
		nextGoal = mainPath.GetNextNode();
		transform.LookAt(CalculateLookAtVector(nextGoal));
	}
	
	void GeneratePath(){
		ArrayList path = new ArrayList();
		path.Add(new Vector3(10,terrain.SampleHeight(new Vector3(10,0,10)),10));
		path.Add(new Vector3(20,terrain.SampleHeight(new Vector3(20,0,15)),15));	
		path.Add(new Vector3(15,terrain.SampleHeight(new Vector3(15,0,20)),20));	
		path.Add(new Vector3(100,terrain.SampleHeight(new Vector3(100,0,10)),10));	
		path.Add(new Vector3(34,terrain.SampleHeight(new Vector3(34,0,25)),25));	
		mainPath = new Path(path, navNodePrefab);
	}
	
	private Vector3 findNearestTreasure(){
		GameObject[] treasures = GameObject.FindGameObjectsWithTag("treasure");
		Vector3 min = Vector3.zero;
		
		for(int i =0; i<treasures.Length; i++){
			//if (treasures[i].GetComponent<Treasure>().isTagged) { // distance stuff? 
			//	continue;
			//}
			if(Vector3.zero == min){
				min = treasures[i].transform.position;
			}
			if(Vector3.Distance(treasures[i].transform.position, transform.position) < Vector3.Distance(min, transform.position)){
				min = treasures[i].transform.position;
			}
		}
		return min;
	}
	
	public void SwitchToTreasureMode(){
		if(treasureMode){
			return;
		}
		treasureMode = true;
		nextTreasure = findNearestTreasure();
		if(nextTreasure==Vector3.zero){
			treasureMode = false;
			return;
		}
		transform.LookAt(CalculateLookAtVector(nextTreasure));
	}
	
	public void SwitchToPathMode(){
		treasureMode = false;
		transform.LookAt(CalculateLookAtVector(nextGoal));
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.N)){
			SwitchToTreasureMode();
		}
		if(treasureMode){
			if(Vector3.Distance(transform.position, nextTreasure)<snapDistance){
				SwitchToPathMode();
			}
		}
		else{
			if(Vector3.Distance(transform.position, nextGoal)<snapDistance){
				nextGoal = mainPath.GetNextNode();
				transform.LookAt(CalculateLookAtVector(nextGoal));
			}
		}
		Vector3 newPos= transform.position + transform.forward * speed * Time.deltaTime;
		transform.position = new Vector3(newPos.x, terrain.SampleHeight(new Vector3(newPos.x,0, newPos.z)), newPos.z);
	}
	/// <summary>
	/// Calculates the look at vector so the the body isn't rotated to weird angles and stuff.
	/// </summary>
	private Vector3 CalculateLookAtVector(Vector3 pos){
		return new Vector3(pos.x, transform.position.y, pos.z);
	}
}
